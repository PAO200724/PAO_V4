using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using PAO.UI.WinForm.Controls;
using System.Collections;
using PAO.App;
using PAO.UI;
using PAO;
using DevExpress.XtraSplashScreen;

namespace PAO.Config.Controls
{
    /// <summary>
    /// 对象树控件
    /// </summary>
    public partial class ObjectTreeControl : DialogControl
    {
        public ObjectTreeControl() {
            InitializeComponent();
            Text = "对象编辑器";
            SetControlStatus();
        }

        #region 公共属性
        private object _SelectedObject;
        /// <summary>
        /// 当前选择的对象
        /// </summary>
        public object SelectedObject {
            get {
                return _SelectedObject;
            }
            set {
                if (_SelectedObject != value) {
                    _SelectedObject = value;
                    this.TreeListObject.Nodes.Clear();
                    CreateTreeNode(this.TreeListObject.Nodes, _SelectedObject);
                }
                SetControlStatus();
            }
        }
        #endregion

        public override void SetFormState(Form form) {
            form.WindowState = FormWindowState.Maximized;
        }

        private void SetControlStatus() {
            var focusNode = this.TreeListObject.FocusedNode;
            if (focusNode != null && focusNode.Id >= 0) {
                var elementType = (ElementType)focusNode.GetValue(ColumnPropertyElementType);
                var propDesc = (PropertyDescriptor)focusNode.GetValue(ColumnPropertyDescriptor);
                var propertyValue = focusNode.GetValue(ColumnPropertyValue);
                var obj = focusNode.GetValue(ColumnObject);

                this.ButtonCreate.Enabled = (elementType != ElementType.Object);
                this.ButtonAdd.Enabled = propDesc != null
                    && propertyValue != null
                    && elementType == ElementType.Property
                    && (propDesc.PropertyType.IsAddonDictionaryType() || propDesc.PropertyType.IsAddonListType());
                this.ButtonDelete.Enabled = (elementType != ElementType.Object) && propertyValue.IsNotNull() && obj != null;
                this.ButtonModifyKey.Enabled = obj != null && elementType == ElementType.Dictionary;
                this.ObjectEditControl.SelectedObject = propertyValue;
            }
            else {
                this.ButtonCreate.Enabled = false;
                this.ButtonAdd.Enabled = false;
                this.ButtonDelete.Enabled = false;
                this.ButtonModifyKey.Enabled = false;
            }
            this.ButtonSave.Enabled = (SelectedObject != null);
        }

        private void FocuseNode(TreeListNode node) {
            var propertyValue = node.GetValue(ColumnPropertyValue);

            this.LabelControlPropertyTitle.Text = node.GetValue(ColumnPropertyName) as string;
            this.SplitContainerControlMain.Panel2.Text = this.LabelControlPropertyTitle.Text;
            this.LabelControlValue.Text = node.GetValue(ColumnPropertyValueString) as string;
            this.LabelControlPropertyType.Text = String.Format("值类型: {0}", node.GetValue(ColumnPropertyTypeString));
            var elementType = (ElementType)node.GetValue(ColumnPropertyElementType);
            var propDesc = (PropertyDescriptor)node.GetValue(ColumnPropertyDescriptor);
            switch (elementType) {
                case ElementType.Property:
                    this.LabelControlObjectType.Text = String.Format("属性类型: {0}", propDesc.PropertyType.GetTypeString());
                    break;
                case ElementType.List:
                    this.LabelControlObjectType.Text = "列表元素";
                    break;
                case ElementType.Dictionary:
                    this.LabelControlObjectType.Text = "字典值";
                    break;
                case ElementType.Object:
                    this.LabelControlObjectType.Text = "object";
                    break;
                default:
                    throw new Exception("此节点不支持显示数据");
            }

            this.ObjectEditControl.SelectedObject = propertyValue;
        }
        #region 对属性的操作
        /// <summary>
        /// 设置属性新值
        /// </summary>
        /// <param name="node">树节点</param>
        /// <param name="newObject">新对象</param>
        /// <returns></returns>
        public void SetPropertNewValue(TreeListNode node, object newObject) {
            var obj = node.GetValue(ColumnObject);
            var propDesc = (PropertyDescriptor)node.GetValue(ColumnPropertyDescriptor);
            var elementType = (ElementType)node.GetValue(ColumnPropertyElementType);
            node.SetValue(ColumnPropertyValue, newObject);
            node.SetValue(ColumnPropertyValueString, GetObjectString(newObject));
            node.SetValue(ColumnPropertyTypeString, GetObjectTypeString(newObject));
            switch (elementType) {
                case ElementType.Property:
                    propDesc.SetValue(obj, newObject);
                    node.Nodes.Clear();
                    CreateChildNodesByObject(node, newObject, propDesc);
                    break;
                case ElementType.List:
                    var index = (int)node.GetValue(ColumnIndex);
                    ((IList)obj)[index] = newObject;
                    node.Nodes.Clear();
                    CreateChildNodesByObject(node, newObject, null);
                    break;
                case ElementType.Dictionary:
                    var key = node.GetValue(ColumnIndex);
                    ((IDictionary)obj)[key] = newObject;
                    node.Nodes.Clear();
                    CreateChildNodesByObject(node, newObject, null);
                    break;
                case ElementType.Object:
                    node.Nodes.Clear();
                    CreateChildNodesByObject(node, newObject, null);
                    break;
                default:
                    throw new Exception("此节点不支持更改数据");
            }
        }
        #endregion


        #region 生成配置树
        /// <summary>
        /// 节点选择图片索引号
        /// </summary>
        public static int ImageIndex_Selected = 0;
        /// <summary>
        /// 对象图标索引号
        /// </summary>
        public static int ImageIndex_Object = 1;
        /// <summary>
        /// 属性图标索引号
        /// </summary>
        public static int ImageIndex_Property = 2;
        /// <summary>
        /// 列表图标索引号
        /// </summary>
        public static int ImageIndex_List = 3;
        /// <summary>
        /// 字典图标索引号
        /// </summary>
        public static int ImageIndex_Dictionary = 4;

        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="obj">对象</param>
        public static void CreateTreeNode(TreeListNodes nodes, object obj) {
            var objNode = nodes.Add("对象"
                , GetObjectString(obj)
                , GetObjectTypeString(obj)
                , null
                , obj
                , obj
                , ElementType.Object
                , null);
            // 创建属性
            objNode.ImageIndex = ImageIndex_Object;
            CreateChildNodesByObject(objNode, obj, null);
            objNode.Expanded = true;
        }

        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="obj">对象</param>
        private static void CreateChildNodesByObject(TreeListNode node, object obj, PropertyDescriptor parentPropDesc) {
            if (obj == null)
                return;
            var objType = obj.GetType();

            if (obj is PaoObject) {
                // 获取对象属性并添加到树中
                foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(objType)) {
                    var addonPropertyAttr = propDesc.Attributes.GetAttribute<AddonPropertyAttribute>();
                    if (addonPropertyAttr != null  
                        && addonPropertyAttr.ShowInEditor
                        && (propDesc.PropertyType.IsAddon()))
                        CreateTreeNodesByProperty(node, obj, propDesc);
                }
            }
            else if (objType.IsAddonDictionaryType()) {
                var dict = obj as IDictionary;
                foreach (var key in dict) {
                    var keyString = key.ToString();
                    var value = dict[key];
                    if (!(value is PaoObject))
                        break;

                    CreateDictionaryNode(node, parentPropDesc, obj, key, value);
                }
            }
            else if (objType.IsAddonListType()) {
                var list = obj as IEnumerable;
                int i = 0;
                foreach (var element in list) {
                    if (!(element is PaoObject))
                        break;

                    CreateListNode(node, parentPropDesc, obj, i, element);
                    i++;
                }
            }
        }

        private static void CreateDictionaryNode(TreeListNode node
            , PropertyDescriptor parentPropDesc
            , object obj
            , object key, object value) {
            string elementString = String.Format("[键：{0}]", key);
            var elementNode = node.Nodes.Add(elementString
                , GetObjectString(value)
                , GetObjectTypeString(value)
                , parentPropDesc
                , value
                , obj
                , ElementType.Dictionary
                , key);
            elementNode.ImageIndex = ImageIndex_Dictionary;
            CreateChildNodesByObject(elementNode, value, null);
        }

        private static void CreateListNode(TreeListNode node
            , PropertyDescriptor parentPropDesc
            , object obj
            , int index, object element) {
            string elementString = String.Format("[索引：{0}]", index);
            var elementNode = node.Nodes.Add(elementString
                , GetObjectString(element)
                , GetObjectTypeString(element)
                , parentPropDesc
                , element
                , obj
                , ElementType.List
                , index);
            elementNode.ImageIndex = ImageIndex_List;
            CreateChildNodesByObject(elementNode, element, null);
        }
        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="propDesc">属性描述</param>
        /// <param name="obj">对象</param>
        private static void CreateTreeNodesByProperty(TreeListNode node, object obj, PropertyDescriptor propDesc) {
            var propVal = propDesc.GetValue(obj);
            var displayAttribute = propDesc.Attributes.GetAttribute<DisplayNameAttribute>();
            var propNode = node.Nodes.Add(displayAttribute == null ? propDesc.Name : displayAttribute.DisplayName
                , GetObjectString(propVal)
                , GetObjectTypeString(propVal)
                , propDesc
                , propVal
                , obj
                , ElementType.Property
                , null);
            propNode.ImageIndex = ImageIndex_Property;
            CreateChildNodesByObject(propNode, propVal, propDesc);
        }

        /// <summary>
        /// 获取对象字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>对象字符串</returns>
        private static string GetObjectString(object obj) {
            if (obj == null)
                return "<空>";

            var objType = obj.GetType();

            string objString = null;
            var displayAttribute = obj.GetType().GetAttribute<DisplayNameAttribute>(false);
            if (objType.IsAddonDictionaryType())
                objString = "字典";
            else if (objType.IsAddonListType())
                objString = "列表";
            else
                objString = obj.ToString();
            return objString;
        }

        private static string GetObjectTypeString(object obj) {
            if (obj == null)
                return null;
            return obj.GetType().GetTypeString();
        }
        #endregion


        #region 事件
        private void TreeListObject_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e) {
            if (e.Node != null && e.Node.Id >= 0) {
                FocuseNode(e.Node);
            }

            SetControlStatus();
        }

        private void ButtonCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusNode = this.TreeListObject.FocusedNode;
            var elementType = (ElementType)focusNode.GetValue(ColumnPropertyElementType);
            var propertyName = (string)focusNode.GetValue(ColumnPropertyName);
            var propDesc = (PropertyDescriptor)focusNode.GetValue(ColumnPropertyDescriptor);
            var propertyValue = focusNode.GetValue(ColumnPropertyValue);
            object newObject = null;
            if (!propertyValue.IsNotNull() || UIPublic.ShowYesNoDialog("您需要清除对象值并创建新的对象吗？") == DialogResult.Yes) {
                if (ConfigPublic.CreateNewAddonValue(propDesc.PropertyType
                    , elementType == ElementType.List || elementType == ElementType.Dictionary  // 如果是List或者Dictionary，则创建元素
                    , out newObject)) {
                    SetPropertNewValue(focusNode, newObject);
                }
                SetControlStatus();
            }
        }

        private void ButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusNode = this.TreeListObject.FocusedNode;
            var elementType = (ElementType)focusNode.GetValue(ColumnPropertyElementType);
            var propDesc = (PropertyDescriptor)focusNode.GetValue(ColumnPropertyDescriptor);
            var propertyValue = focusNode.GetValue(ColumnPropertyValue);
            propertyValue.CheckNotNull("属性值为空时不能添加。");
            object newObject = null;

            if (propDesc.PropertyType.IsAddonListType()) {
                if (ConfigPublic.CreateNewAddonValue(propDesc.PropertyType
                    , true
                    , out newObject)) {
                    int index = propertyValue.As<IList>().Add(newObject);
                    CreateListNode(focusNode, propDesc, propertyValue, index, newObject);
                }
            }
            else if(propDesc.PropertyType.IsAddonDictionaryType()) {
                var keyInputControl = new InputKeyControl();
                if(UIPublic.ShowDialog(keyInputControl) == DialogResult.OK) {
                    string key = keyInputControl.KeyValue;
                    if (ConfigPublic.CreateNewAddonValue(propDesc.PropertyType
                        , true
                        , out newObject)) {
                        propertyValue.As<IDictionary>().Add(key, newObject);
                        CreateDictionaryNode(focusNode, propDesc, propertyValue, key, newObject);
                    }
                }
            } else {
                throw new Exception("此属性类型不支持添加元素.").AddExceptionData("ElementType", elementType);
            }
            SetControlStatus();
        }

        private void ButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusNode = this.TreeListObject.FocusedNode;
            var elementType = (ElementType)focusNode.GetValue(ColumnPropertyElementType);
            var propDesc = (PropertyDescriptor)focusNode.GetValue(ColumnPropertyDescriptor);
            var obj = focusNode.GetValue(ColumnObject);
            var propertyValue = focusNode.GetValue(ColumnPropertyValue);

            switch (elementType) {
                case ElementType.Property:
                    propDesc.SetValue(obj, null);
                    SetPropertNewValue(focusNode, null);
                    break;
                case ElementType.List:
                    int index = (int)focusNode.GetValue(ColumnIndex);
                    obj.As<IList>().RemoveAt(index);
                    if (focusNode.ParentNode != null)
                        focusNode.ParentNode.Nodes.Remove(focusNode);
                    break;
                case ElementType.Dictionary:
                    var key = focusNode.GetValue(ColumnIndex);
                    obj.As<IDictionary>().Remove(key);
                    if (focusNode.ParentNode != null)
                        focusNode.ParentNode.Nodes.Remove(focusNode);
                    break;
                default:
                    throw new Exception("此属性不允许被删除").AddExceptionData("ElementType", elementType);
            }
            SetControlStatus();
        }

        private void ButtonModifyKey_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusNode = this.TreeListObject.FocusedNode;
            var elementType = (ElementType)focusNode.GetValue(ColumnPropertyElementType);
            var obj = focusNode.GetValue(ColumnObject);
            var propertyValue = focusNode.GetValue(ColumnPropertyValue);

            obj.CheckNotNull("字典对象不能为空");
            (elementType == ElementType.Dictionary).CheckTrue("只有字典元素允许修改键值");
            string oldKey = (string)focusNode.GetValue(ColumnIndex);

            var keyInputControl = new InputKeyControl();
            keyInputControl.KeyValue = oldKey;
            if (UIPublic.ShowDialog(keyInputControl) == DialogResult.OK) {
                string newKey = keyInputControl.KeyValue;
                var dict = obj.As<IDictionary>();
                dict.Remove(oldKey);
                dict.Add(newKey, propertyValue);
                focusNode.SetValue(ColumnIndex, newKey);
                string elementString = String.Format("[键：{0}]", newKey);
                focusNode.SetValue(ColumnPropertyTypeString, newKey);
            }
        }
        #endregion
    }
}
