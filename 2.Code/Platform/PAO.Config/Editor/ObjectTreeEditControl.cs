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
using PAO.WinForm.Controls;
using System.Collections;
using PAO.App;
using PAO.UI;
using PAO;
using DevExpress.XtraSplashScreen;
using PAO.IO;
using PAO.WinForm;
using PAO.MVC;
using PAO.Config.Controls;
using static PAO.Config.DataSetExtendProperty;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 对象树控件
    /// </summary>
    public partial class ObjectTreeEditControl : BaseEditControl
    {

        public ObjectTreeEditControl() {
            InitializeComponent();
            Text = "对象编辑器";
            SetControlStatus();
            EditMode = true;
        }
        /// <summary>
        /// 扩展属性存储
        /// </summary>
        ExtendPropertyStorage ExtendPropertyStorage;

        #region 公共属性
        /// <summary>
        /// 当前选择的对象
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                return base.EditValue;
            }
            set {
                if (base.EditValue != value) {
                    base.EditValue = value;
                    this.TreeListObject.Nodes.Clear();
                    CreateTreeNode(this.TreeListObject.Nodes, value);
                }
                SetControlStatus();
            }
        }

        private bool _EditMode;

        public bool EditMode {
            get { return _EditMode; }
            set {
                _EditMode = value;
                this.BarMainTools.Visible = _EditMode;
                this.SplitContainerControlMain.Panel2.Visible = _EditMode;
            }
        }

        private string _ExtendPropertyStorageFilePath;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ExtendPropertyStorageFilePath {
            get { return _ExtendPropertyStorageFilePath; }
            set {
                _ExtendPropertyStorageFilePath = value;
                if(_ExtendPropertyStorageFilePath.IsNotNullOrEmpty() ) {
                    ExtendPropertyStorage = new ExtendPropertyStorage() { FilePath = value };
                    SplitContainerControlProperty.Panel2.Visible = true;
                    ExtendPropertyStorage = new ExtendPropertyStorage()
                    {
                        FilePath = _ExtendPropertyStorageFilePath
                    };
                    ExtendPropertyStorage.Load();
                    this.AddonExtentionEditControl.EditValue = ExtendPropertyStorage.PropertyTable;
                }
                else {
                    SplitContainerControlProperty.Panel2.Visible = false;
                }
                SetControlStatus();
            }
        }
        #endregion

        #region DialogControl
        public override void SetFormState(Form form) {
            form.WindowState = FormWindowState.Maximized;
        }

        protected override bool OnClosing(DialogReturn dialogResult) {
            /// 保存
            if(ExtendPropertyStorage != null) {
                ExtendPropertyStorage.Save();
            }
            return base.OnClosing(dialogResult);
        }
        #endregion

        #region 生成配置树
        /// <summary>
        /// 节点选择图片索引号
        /// </summary>
        public static int ImageIndex_Selected = 0;
        /// <summary>
        /// 列表图标索引号
        /// </summary>
        public static int ImageIndex_ListProperty = 1;
        /// <summary>
        /// 字典图标索引号
        /// </summary>
        public static int ImageIndex_DictionaryProperty = 2;
        /// <summary>
        /// 空对象
        /// </summary>
        public static int ImageIndex_Null = 3;
        /// <summary>
        /// 类型图标索引
        /// </summary>
        private Dictionary<string, int> TypeIconIndexList = new Dictionary<string, int>();
        /// <summary>
        /// 对象类型
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>图片索引</returns>
        private int GetImageIndex(object obj) {
            if (obj == null)
                return ImageIndex_Null;

            Type objectType = obj.GetType();
            if (objectType.IsAddonDictionaryType())
                return ImageIndex_DictionaryProperty;
            else if(objectType.IsAddonListType())
                return ImageIndex_ListProperty;
            var iconAttr = objectType.GetAttribute<IconAttribute>(true);
            if (iconAttr == null)
                return -1;

            var icon = iconAttr.GetIcon();
            if (icon == null)
                return -1;

            string iconResString = String.Format("{0}.{1}", iconAttr.ResourceType.FullName, iconAttr.Icon);
            if(TypeIconIndexList.ContainsKey(iconResString)) {
                return TypeIconIndexList[iconResString];
            }
            else {
                ImageCollectionTree.AddImage(icon.Clone() as Image);
                int imageIndex = ImageCollectionTree.Images.Count-1;
                TypeIconIndexList.Add(iconResString, imageIndex);
                return imageIndex;
            }
        }

        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="obj">对象</param>
        public void CreateTreeNode(TreeListNodes nodes, object obj) {
            var objNode = nodes.Add("对象"
                , GetObjectString(obj)
                , GetObjectTypeString(obj)
                , null
                , obj
                , obj
                , ObjectTreeNodeType.Object
                , null);
            // 创建属性
            objNode.ImageIndex = GetImageIndex(obj);
            objNode.SelectImageIndex = objNode.ImageIndex;
            CreateChildNodesByObject(objNode, obj, null);
            objNode.Expanded = true;
        }

        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="obj">对象</param>
        private void CreateChildNodesByObject(TreeListNode node, object obj, PropertyDescriptor parentPropDesc) {
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
                foreach (var key in dict.Keys) {
                    var value = dict[key];
                    if (!(value is PaoObject))
                        break;

                    CreateElementNode(node, parentPropDesc, obj, key, value);
                }
            }
            else if (objType.IsAddonListType()) {
                var list = obj as IEnumerable;
                int i = 0;
                foreach (var element in list) {
                    if (!(element is PaoObject))
                        break;

                    CreateElementNode(node, parentPropDesc, obj, i, element);
                    i++;
                }
            }
        }
        
        /// <summary>
        /// 创建字典元素节点
        /// </summary>
        /// <param name="parentNode">上级节点</param>
        /// <param name="parentPropDesc">上级属性描述</param>
        /// <param name="obj">对象</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        private TreeListNode CreateElementNode(TreeListNode parentNode
            , PropertyDescriptor parentPropDesc
            , object obj
            , object key, object value) {
            string elementString;
            ObjectTreeNodeType nodeType;
            int imageIndex = -1;
            if (parentPropDesc.PropertyType.IsAddonListType()) {
                elementString = String.Format("[索引：{0}]", key);
                nodeType = ObjectTreeNodeType.ListElement;
            }
            else if(parentPropDesc.PropertyType.IsAddonDictionaryType()) {
                elementString = String.Format("[键：{0}]", key);
                nodeType = ObjectTreeNodeType.DictionaryElement;
            }
            else {
                throw new Exception("此类型的属性不支持增加元素节点").AddExceptionData("属性类型", parentPropDesc.PropertyType);
            }
            imageIndex = GetImageIndex(value);
            var elementNode = parentNode.Nodes.Add(elementString
                , GetObjectString(value)
                , GetObjectTypeString(value)
                , parentPropDesc
                , value
                , obj
                , nodeType
                , key);
            elementNode.ImageIndex = imageIndex;
            elementNode.SelectImageIndex = elementNode.ImageIndex;

            CreateChildNodesByObject(elementNode, value, null);
            return elementNode;
        }

        /// <summary>
        /// 利用属性描述创建节点
        /// </summary>
        /// <param name="parentNode">上级节点</param>
        /// <param name="obj">对象</param>
        /// <param name="propDesc">属性描述</param>
        private TreeListNode CreateTreeNodesByProperty(TreeListNode parentNode, object obj, PropertyDescriptor propDesc) {
            var propVal = propDesc.GetValue(obj);
            var displayAttribute = propDesc.Attributes.GetAttribute<DisplayNameAttribute>();
            ObjectTreeNodeType nodeType;
            int imageIndex = -1;
            if(propDesc.PropertyType.IsAddonDictionaryType()) {
                nodeType = ObjectTreeNodeType.DictionaryProperty;
            } else if(propDesc.PropertyType.IsAddonListType()) {
                nodeType = ObjectTreeNodeType.ListProperty;
            }
            else {
                nodeType = ObjectTreeNodeType.ObjectProperty;
            }

            imageIndex = GetImageIndex(propVal);

            var propNode = parentNode.Nodes.Add(displayAttribute == null ? propDesc.Name : displayAttribute.DisplayName
                , GetObjectString(propVal)
                , GetObjectTypeString(propVal)
                , propDesc
                , propVal
                , obj
                , nodeType
                , null);
            propNode.ImageIndex = imageIndex;
            propNode.SelectImageIndex = propNode.ImageIndex;

            CreateChildNodesByObject(propNode, propVal, propDesc);
            return propNode;
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

        #region 私有方法
        protected override void SetControlStatus() {
            var focusedNode = this.TreeListObject.FocusedNode;
            if (focusedNode != null && focusedNode.Id >= 0) {
                var nodeType = (ObjectTreeNodeType)focusedNode.GetValue(ColumnPropertyElementType);
                var propDesc = (PropertyDescriptor)focusedNode.GetValue(ColumnPropertyDescriptor);
                var propertyValue = focusedNode.GetValue(ColumnPropertyValue);
                var obj = focusedNode.GetValue(ColumnObject);

                this.ButtonCreate.Enabled = (nodeType != ObjectTreeNodeType.Object);
                this.ButtonAdd.Enabled = propDesc != null
                    && propertyValue != null
                    && (nodeType == ObjectTreeNodeType.ObjectProperty || nodeType == ObjectTreeNodeType.ListProperty || nodeType == ObjectTreeNodeType.DictionaryProperty)
                    && (propDesc.PropertyType.IsAddonDictionaryType() || propDesc.PropertyType.IsAddonListType());
                this.ButtonDelete.Enabled = (nodeType != ObjectTreeNodeType.Object) && propertyValue.IsNotNull() && obj != null;
                this.ButtonModifyKey.Enabled = (obj != null && nodeType == ObjectTreeNodeType.DictionaryElement);
                this.ObjectEditControl.EditValue = propertyValue;
                this.ButtonProperty.Enabled = (propertyValue != null && ConfigPublic.GetEditControlType(propertyValue.GetType()) != null);
                this.ButtonExportExtend.Enabled = ExtendPropertyStorage.PropertyTable != null;
            }
            else {
                this.ButtonCreate.Enabled = false;
                this.ButtonAdd.Enabled = false;
                this.ButtonDelete.Enabled = false;
                this.ButtonModifyKey.Enabled = false;
                this.ButtonProperty.Enabled = false;
            }
            this.ButtonExport.Enabled = (EditValue != null);
            base.SetControlStatus();
        }

        /// <summary>
        /// 设置属性新值
        /// </summary>
        /// <param name="node">树节点</param>
        /// <param name="newObject">新对象</param>
        private void SetPropertNewValue(TreeListNode node, object newObject) {
            var obj = node.GetValue(ColumnObject);
            var propDesc = (PropertyDescriptor)node.GetValue(ColumnPropertyDescriptor);
            var elementType = (ObjectTreeNodeType)node.GetValue(ColumnPropertyElementType);
            node.SetValue(ColumnPropertyValue, newObject);
            node.SetValue(ColumnPropertyValueString, GetObjectString(newObject));
            node.SetValue(ColumnPropertyTypeString, GetObjectTypeString(newObject));
            node.ImageIndex = GetImageIndex(newObject);
            node.SelectImageIndex = node.ImageIndex;
            switch (elementType) {
                case ObjectTreeNodeType.ObjectProperty:
                case ObjectTreeNodeType.ListProperty:
                case ObjectTreeNodeType.DictionaryProperty:
                    propDesc.SetValue(obj, newObject);
                    node.Nodes.Clear();
                    CreateChildNodesByObject(node, newObject, propDesc);
                    break;
                case ObjectTreeNodeType.ListElement:
                    var index = (int)node.GetValue(ColumnIndex);
                    ((IList)obj)[index] = newObject;
                    node.Nodes.Clear();
                    CreateChildNodesByObject(node, newObject, null);
                    break;
                case ObjectTreeNodeType.DictionaryElement:
                    var key = node.GetValue(ColumnIndex);
                    ((IDictionary)obj)[key] = newObject;
                    node.Nodes.Clear();
                    CreateChildNodesByObject(node, newObject, null);
                    break;
                case ObjectTreeNodeType.Object:
                    node.Nodes.Clear();
                    CreateChildNodesByObject(node, newObject, null);
                    break;
                default:
                    throw new Exception("此节点不支持更改数据");
            }
        }
        /// <summary>
        /// 设置焦点
        /// </summary>
        /// <param name="node">节点</param>
        private void FocuseNode(TreeListNode node) {
            var propertyValue = node.GetValue(ColumnPropertyValue);
            var propDesc = (PropertyDescriptor)node.GetValue(ColumnPropertyDescriptor);

            this.LabelControlPropertyTitle.Text = node.GetValue(ColumnPropertyName) as string;
            this.SplitContainerControlMain.Panel2.Text = this.LabelControlPropertyTitle.Text;
            this.LabelControlPropertyDescription.Text = propDesc == null ? null : propDesc.Description;
            this.LabelControlPropertyType.Text = propDesc == null ? null : propDesc.PropertyType.GetTypeFullString();
            var nodeType = (ObjectTreeNodeType)node.GetValue(ColumnPropertyElementType);
            this.AddonExtentionEditControl.Enabled = false;
            switch (nodeType) {
                case ObjectTreeNodeType.ListProperty:
                    this.ListEditControl.EditValue = propertyValue;
                    this.TabControlObject.SelectedTabPage = TabPageList;
                    break;
                case ObjectTreeNodeType.DictionaryProperty:
                    this.DictionaryEditControl.EditValue = propertyValue;
                    this.TabControlObject.SelectedTabPage = TabPageDictionary;
                    break;
                case ObjectTreeNodeType.ObjectProperty:
                case ObjectTreeNodeType.ListElement:
                case ObjectTreeNodeType.DictionaryElement:
                case ObjectTreeNodeType.Object:
                    if(propertyValue is PaoObject) {
                        this.AddonExtentionEditControl.Enabled = true;
                        this.AddonExtentionEditControl.OriginAddon = propertyValue as PaoObject;
                    }
                    this.ObjectEditControl.EditValue = propertyValue;
                    this.TabControlObject.SelectedTabPage = TabPageObject;
                    break;
                default:
                    throw new Exception("此节点不支持显示数据");
            }
            ExtendPropertyStorage.Save();
        }

        /// <summary>
        /// 根据编辑控件重置对象
        /// </summary>
        /// <param name="editControl">编辑控件</param>
        private void ResetNodeValueByEditControl(BaseEditControl editControl) {
            var focusedNode = this.TreeListObject.FocusedNode;
            if (focusedNode != null) {
                var propDesc = (PropertyDescriptor)focusedNode.GetValue(ColumnPropertyDescriptor);
                var nodeType = (ObjectTreeNodeType)focusedNode.GetValue(ColumnPropertyElementType);
                var obj = focusedNode.GetValue(ColumnObject);
                var newObject = editControl.EditValue;

                switch (nodeType) {
                    case ObjectTreeNodeType.ListElement:
                        var index = (int)focusedNode.GetValue(ColumnIndex);
                        obj.As<IList>()[index] = newObject;
                        focusedNode.Nodes.Clear();
                        CreateChildNodesByObject(focusedNode, newObject, propDesc);
                        break;
                    case ObjectTreeNodeType.DictionaryElement:
                        var key = focusedNode.GetValue(ColumnIndex);
                        obj.As<IDictionary>()[key] = newObject;
                        focusedNode.Nodes.Clear();
                        CreateChildNodesByObject(focusedNode, newObject, propDesc);
                        break;
                    case ObjectTreeNodeType.ListProperty:
                    case ObjectTreeNodeType.DictionaryProperty:
                    case ObjectTreeNodeType.ObjectProperty:
                        propDesc.SetValue(obj, newObject);
                        focusedNode.Nodes.Clear();
                        CreateChildNodesByObject(focusedNode, newObject, propDesc);
                        break;
                    case ObjectTreeNodeType.Object:
                        focusedNode.Nodes.Clear();
                        CreateChildNodesByObject(focusedNode, newObject, null);
                        break;
                    default:
                        throw new Exception("此节点不支持显示数据");
                }
                
                focusedNode.Expanded = true;
            }
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
            var focusedNode = this.TreeListObject.FocusedNode;
            var nodeType = (ObjectTreeNodeType)focusedNode.GetValue(ColumnPropertyElementType);
            var propertyName = (string)focusedNode.GetValue(ColumnPropertyName);
            var propDesc = (PropertyDescriptor)focusedNode.GetValue(ColumnPropertyDescriptor);
            var propertyValue = focusedNode.GetValue(ColumnPropertyValue);
            object newObject = null;
            if (!propertyValue.IsNotNull() || UIPublic.ShowYesNoDialog("您需要清除对象值并创建新的对象吗？") == DialogReturn.Yes) {
                if (ConfigPublic.CreateNewAddonValue(propDesc.PropertyType
                    , nodeType == ObjectTreeNodeType.ListElement || nodeType == ObjectTreeNodeType.DictionaryElement  // 如果是List或者Dictionary，则创建元素
                    , out newObject)) {
                    SetPropertNewValue(focusedNode, newObject);
                }
                FocuseNode(focusedNode);
                SetControlStatus();
            }
        }

        private void ButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusedNode = this.TreeListObject.FocusedNode;
            var nodeType = (ObjectTreeNodeType)focusedNode.GetValue(ColumnPropertyElementType);
            var propDesc = (PropertyDescriptor)focusedNode.GetValue(ColumnPropertyDescriptor);
            var propertyValue = focusedNode.GetValue(ColumnPropertyValue);
            propertyValue.CheckNotNull("属性值为空时不能添加。");
            object newObject = null;

            if (propDesc.PropertyType.IsAddonListType()) {
                if (ConfigPublic.CreateNewAddonValue(propDesc.PropertyType
                    , true
                    , out newObject)) {
                    int index = propertyValue.As<IList>().Add(newObject);
                    var newNode = CreateElementNode(focusedNode, propDesc, propertyValue, index, newObject);
                    focusedNode.Expanded = true;
                    TreeListObject.FocusedNode = newNode;
                }
            }
            else if(propDesc.PropertyType.IsAddonDictionaryType()) {
                var keyInputControl = new InputKeyControl();
                if(WinFormPublic.ShowDialog(keyInputControl) == DialogReturn.OK) {
                    string key = keyInputControl.KeyValue;
                    if (ConfigPublic.CreateNewAddonValue(propDesc.PropertyType
                        , true
                        , out newObject)) {
                        propertyValue.As<IDictionary>().Add(key, newObject);
                        var newNode = CreateElementNode(focusedNode, propDesc, propertyValue, key, newObject);
                        focusedNode.Expanded = true;
                        TreeListObject.FocusedNode = newNode;
                    }
                }
            } else {
                throw new Exception("此属性类型不支持添加元素.").AddExceptionData("ElementType", nodeType);
            }
            SetControlStatus();
        }

        private void ButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusedNode = this.TreeListObject.FocusedNode;
            var nodeType = (ObjectTreeNodeType)focusedNode.GetValue(ColumnPropertyElementType);
            var propDesc = (PropertyDescriptor)focusedNode.GetValue(ColumnPropertyDescriptor);
            var obj = focusedNode.GetValue(ColumnObject);
            var propertyValue = focusedNode.GetValue(ColumnPropertyValue);

            switch (nodeType) {
                case ObjectTreeNodeType.ObjectProperty:
                case ObjectTreeNodeType.ListProperty:
                case ObjectTreeNodeType.DictionaryProperty:
                    propDesc.SetValue(obj, null);
                    SetPropertNewValue(focusedNode, null);
                    break;
                case ObjectTreeNodeType.ListElement:
                    int index = (int)focusedNode.GetValue(ColumnIndex);
                    obj.As<IList>().RemoveAt(index);
                    if (focusedNode.ParentNode != null)
                        focusedNode.ParentNode.Nodes.Remove(focusedNode);
                    break;
                case ObjectTreeNodeType.DictionaryElement:
                    var key = focusedNode.GetValue(ColumnIndex);
                    obj.As<IDictionary>().Remove(key);
                    if (focusedNode.ParentNode != null)
                        focusedNode.ParentNode.Nodes.Remove(focusedNode);
                    break;
                default:
                    throw new Exception("此属性不允许被删除").AddExceptionData("ElementType", nodeType);
            }
            SetControlStatus();
        }

        private void ButtonModifyKey_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusedNode = this.TreeListObject.FocusedNode;
            var nodeType = (ObjectTreeNodeType)focusedNode.GetValue(ColumnPropertyElementType);
            var obj = focusedNode.GetValue(ColumnObject);
            var propertyValue = focusedNode.GetValue(ColumnPropertyValue);

            obj.CheckNotNull("字典对象不能为空");
            (nodeType == ObjectTreeNodeType.DictionaryElement).CheckTrue("只有字典元素允许修改键值");
            string oldKey = (string)focusedNode.GetValue(ColumnIndex);

            var keyInputControl = new InputKeyControl();
            keyInputControl.KeyValue = oldKey;
            if (WinFormPublic.ShowDialog(keyInputControl) == DialogReturn.OK) {
                string newKey = keyInputControl.KeyValue;
                var dict = obj.As<IDictionary>();
                dict.Remove(oldKey);
                dict.Add(newKey, propertyValue);
                focusedNode.SetValue(ColumnIndex, newKey);
                string elementString = String.Format("[键：{0}]", newKey);
                focusedNode.SetValue(ColumnPropertyTypeString, newKey);
                FocuseNode(focusedNode);
                SetControlStatus();
            }
        }

        private void ListEditControl_DataModifyStateChanged(object sender, WinForm.DataModifyStateChangedEventArgs e) {
            if (e.DataModified == true) {
                ResetNodeValueByEditControl(ListEditControl);
            }
        }

        private void ObjectEditControl_DataModifyStateChanged(object sender, WinForm.DataModifyStateChangedEventArgs e) {
            if (e.DataModified == true) {
                ResetNodeValueByEditControl(ObjectEditControl);
            }
        }

        private void DictionaryEditControl_DataModifyStateChanged(object sender, WinForm.DataModifyStateChangedEventArgs e) {
            if (e.DataModified == true) {
                ResetNodeValueByEditControl(DictionaryEditControl);
            }
        }

        private void ObjectTreeEditControl_Enter(object sender, EventArgs e) {
            ConfigPublic.RootEditingObject = this.EditValue;
        }

        private void ButtonExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ExportSelectedObject();
        }
        
        private void ButtonProperty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            UIPublic.ShowWaitingForm();
            var focusedNode = this.TreeListObject.FocusedNode;
            var propertyValue = focusedNode.GetValue(ColumnPropertyValue);
            Type editControlType = ConfigPublic.GetEditControlType(propertyValue.GetType());
            var editControl = editControlType.CreateInstance() as BaseEditControl;
            editControl.EditValue = propertyValue;
            UIPublic.CloseWaitingForm();
            if (WinFormPublic.ShowDialog(editControl) == DialogReturn.OK) {
                SetPropertNewValue(focusedNode, editControl.EditValue);
            }
            FocuseNode(focusedNode);
            SetControlStatus();
        }

        private void AddonExtentionEditControl_DataModifyStateChanged(object sender, DataModifyStateChangedEventArgs e) {
            // 保存到扩展存储中
            this.AddonExtentionEditControl.GetDataFromControl();
        }

        private void ButtonImportExtend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            IOPublic.ImportObject((obj) =>
            {
                ExtendPropertyStorage.PropertyTable = obj as ExtendPropertyDataTable;
                this.AddonExtentionEditControl.EditValue = ExtendPropertyStorage.PropertyTable;
                SetControlStatus();
            });
        }

        private void ButtonExportExtend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            IOPublic.ExportObject(ExtendPropertyStorage.PropertyTable);
        }
        #endregion
    }
}
