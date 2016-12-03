﻿using System;
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

namespace PAO.Config.Controls.EditControls
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
        }

        #region 公共属性
        /// <summary>
        /// 当前选择的对象
        /// </summary>
        public override object SelectedObject {
            get {
                return base.SelectedObject;
            }
            set {
                if (base.SelectedObject != value) {
                    base.SelectedObject = value;
                    this.TreeListObject.Nodes.Clear();
                    CreateTreeNode(this.TreeListObject.Nodes, value);
                }
                SetControlStatus();
            }
        }
        #endregion

        #region DialogControl
        public override void SetFormState(Form form) {
            form.WindowState = FormWindowState.Maximized;
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
        public static int ImageIndex_ObjectProperty = 2;
        /// <summary>
        /// 列表图标索引号
        /// </summary>
        public static int ImageIndex_ListProperty = 3;
        /// <summary>
        /// 字典图标索引号
        /// </summary>
        public static int ImageIndex_DictionaryProperty = 4;
        /// <summary>
        /// 列表图标索引号
        /// </summary>
        public static int ImageIndex_ListElement = 5;
        /// <summary>
        /// 字典图标索引号
        /// </summary>
        public static int ImageIndex_DictionaryElement = 6;

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
                , ObjectTreeNodeType.Object
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
        private static void CreateElementNode(TreeListNode parentNode
            , PropertyDescriptor parentPropDesc
            , object obj
            , object key, object value) {
            string elementString;
            ObjectTreeNodeType nodeType;
            int imageIndex;
            if (parentPropDesc.PropertyType.IsAddonListType()) {
                elementString = String.Format("[索引：{0}]", key);
                nodeType = ObjectTreeNodeType.ListElement;
                imageIndex = ImageIndex_ListElement;
            }
            else if(parentPropDesc.PropertyType.IsAddonDictionaryType()) {
                elementString = String.Format("[键：{0}]", key);
                nodeType = ObjectTreeNodeType.DictionaryElement;
                imageIndex = ImageIndex_DictionaryElement;
            }
            else {
                throw new Exception("此类型的属性不支持增加元素节点").AddExceptionData("属性类型", parentPropDesc.PropertyType);
            }
            var elementNode = parentNode.Nodes.Add(elementString
                , GetObjectString(value)
                , GetObjectTypeString(value)
                , parentPropDesc
                , value
                , obj
                , nodeType
                , key);
            elementNode.ImageIndex = imageIndex;
            CreateChildNodesByObject(elementNode, value, null);
        }

        /// <summary>
        /// 利用属性描述创建节点
        /// </summary>
        /// <param name="parentNode">上级节点</param>
        /// <param name="obj">对象</param>
        /// <param name="propDesc">属性描述</param>
        private static void CreateTreeNodesByProperty(TreeListNode parentNode, object obj, PropertyDescriptor propDesc) {
            var propVal = propDesc.GetValue(obj);
            var displayAttribute = propDesc.Attributes.GetAttribute<DisplayNameAttribute>();
            ObjectTreeNodeType nodeType;
            int imageIndex;
            if(propDesc.PropertyType.IsAddonDictionaryType()) {
                nodeType = ObjectTreeNodeType.DictionaryProperty;
                imageIndex = ImageIndex_DictionaryProperty;
            } else if(propDesc.PropertyType.IsAddonListType()) {
                nodeType = ObjectTreeNodeType.ListProperty;
                imageIndex = ImageIndex_ListProperty;
            }
            else {
                nodeType = ObjectTreeNodeType.ObjectProperty;
                imageIndex = ImageIndex_ObjectProperty;
            }
            var propNode = parentNode.Nodes.Add(displayAttribute == null ? propDesc.Name : displayAttribute.DisplayName
                , GetObjectString(propVal)
                , GetObjectTypeString(propVal)
                , propDesc
                , propVal
                , obj
                , nodeType
                , null);
            propNode.ImageIndex = imageIndex;
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

        #region 私有方法
        private void SetControlStatus() {
            var focusNode = this.TreeListObject.FocusedNode;
            if (focusNode != null && focusNode.Id >= 0) {
                var nodeType = (ObjectTreeNodeType)focusNode.GetValue(ColumnPropertyElementType);
                var propDesc = (PropertyDescriptor)focusNode.GetValue(ColumnPropertyDescriptor);
                var propertyValue = focusNode.GetValue(ColumnPropertyValue);
                var obj = focusNode.GetValue(ColumnObject);

                this.ButtonCreate.Enabled = (nodeType != ObjectTreeNodeType.Object);
                this.ButtonAdd.Enabled = propDesc != null
                    && propertyValue != null
                    && (nodeType == ObjectTreeNodeType.ObjectProperty || nodeType == ObjectTreeNodeType.ListProperty || nodeType == ObjectTreeNodeType.DictionaryProperty)
                    && (propDesc.PropertyType.IsAddonDictionaryType() || propDesc.PropertyType.IsAddonListType());
                this.ButtonDelete.Enabled = (nodeType != ObjectTreeNodeType.Object) && propertyValue.IsNotNull() && obj != null;
                this.ButtonModifyKey.Enabled = (obj != null && nodeType == ObjectTreeNodeType.DictionaryElement);
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
            switch (nodeType) {
                case ObjectTreeNodeType.ListProperty:
                    this.ListEditControl.SelectedObject = propertyValue;
                    this.ListEditControl.ListType = propDesc.PropertyType;
                    this.TabControlObject.SelectedTabPage = TabPageList;
                    break;
                case ObjectTreeNodeType.DictionaryProperty:
                    this.DictionaryEditControl.SelectedObject = propertyValue;
                    this.DictionaryEditControl.ListType = propDesc.PropertyType;
                    this.TabControlObject.SelectedTabPage = TabPageDictionary;
                    break;
                case ObjectTreeNodeType.ObjectProperty:
                case ObjectTreeNodeType.ListElement:
                case ObjectTreeNodeType.DictionaryElement:
                case ObjectTreeNodeType.Object:
                    this.ObjectEditControl.SelectedObject = propertyValue;
                    this.TabControlObject.SelectedTabPage = TabPageObject;
                    break;
                default:
                    throw new Exception("此节点不支持显示数据");
            }
        }

        /// <summary>
        /// 根据编辑控件重置对象
        /// </summary>
        /// <param name="editControl">编辑控件</param>
        private void ResetNodeValueByEditControl(BaseEditControl editControl) {
            var focusNode = this.TreeListObject.FocusedNode;
            if (focusNode != null) {
                var propDesc = (PropertyDescriptor)focusNode.GetValue(ColumnPropertyDescriptor);
                var nodeType = (ObjectTreeNodeType)focusNode.GetValue(ColumnPropertyElementType);
                var obj = focusNode.GetValue(ColumnObject);
                var newObject = editControl.SelectedObject;

                switch (nodeType) {
                    case ObjectTreeNodeType.ListElement:
                        var index = (int)focusNode.GetValue(ColumnIndex);
                        obj.As<IList>()[index] = newObject;
                        focusNode.Nodes.Clear();
                        CreateChildNodesByObject(focusNode, newObject, propDesc);
                        break;
                    case ObjectTreeNodeType.DictionaryElement:
                        var key = focusNode.GetValue(ColumnIndex);
                        obj.As<IDictionary>()[key] = newObject;
                        focusNode.Nodes.Clear();
                        CreateChildNodesByObject(focusNode, newObject, propDesc);
                        break;
                    case ObjectTreeNodeType.ListProperty:
                    case ObjectTreeNodeType.DictionaryProperty:
                    case ObjectTreeNodeType.ObjectProperty:
                        propDesc.SetValue(obj, newObject);
                        focusNode.Nodes.Clear();
                        CreateChildNodesByObject(focusNode, newObject, propDesc);
                        break;
                    case ObjectTreeNodeType.Object:
                        throw new Exception("此节点不支持显示数据");
                }
                
                focusNode.Expanded = true;
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
            var focusNode = this.TreeListObject.FocusedNode;
            var nodeType = (ObjectTreeNodeType)focusNode.GetValue(ColumnPropertyElementType);
            var propertyName = (string)focusNode.GetValue(ColumnPropertyName);
            var propDesc = (PropertyDescriptor)focusNode.GetValue(ColumnPropertyDescriptor);
            var propertyValue = focusNode.GetValue(ColumnPropertyValue);
            object newObject = null;
            if (!propertyValue.IsNotNull() || UIPublic.ShowYesNoDialog("您需要清除对象值并创建新的对象吗？") == DialogResult.Yes) {
                if (ConfigPublic.CreateNewAddonValue(propDesc.PropertyType
                    , nodeType == ObjectTreeNodeType.ListElement || nodeType == ObjectTreeNodeType.DictionaryElement  // 如果是List或者Dictionary，则创建元素
                    , out newObject)) {
                    SetPropertNewValue(focusNode, newObject);
                }
                SetControlStatus();
            }
        }

        private void ButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusNode = this.TreeListObject.FocusedNode;
            var nodeType = (ObjectTreeNodeType)focusNode.GetValue(ColumnPropertyElementType);
            var propDesc = (PropertyDescriptor)focusNode.GetValue(ColumnPropertyDescriptor);
            var propertyValue = focusNode.GetValue(ColumnPropertyValue);
            propertyValue.CheckNotNull("属性值为空时不能添加。");
            object newObject = null;

            if (propDesc.PropertyType.IsAddonListType()) {
                if (ConfigPublic.CreateNewAddonValue(propDesc.PropertyType
                    , true
                    , out newObject)) {
                    int index = propertyValue.As<IList>().Add(newObject);
                    CreateElementNode(focusNode, propDesc, propertyValue, index, newObject);
                    focusNode.Expanded = true;
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
                        CreateElementNode(focusNode, propDesc, propertyValue, key, newObject);
                        focusNode.Expanded = true;
                    }
                }
            } else {
                throw new Exception("此属性类型不支持添加元素.").AddExceptionData("ElementType", nodeType);
            }
            SetControlStatus();
        }

        private void ButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusNode = this.TreeListObject.FocusedNode;
            var nodeType = (ObjectTreeNodeType)focusNode.GetValue(ColumnPropertyElementType);
            var propDesc = (PropertyDescriptor)focusNode.GetValue(ColumnPropertyDescriptor);
            var obj = focusNode.GetValue(ColumnObject);
            var propertyValue = focusNode.GetValue(ColumnPropertyValue);

            switch (nodeType) {
                case ObjectTreeNodeType.ObjectProperty:
                case ObjectTreeNodeType.ListProperty:
                case ObjectTreeNodeType.DictionaryProperty:
                    propDesc.SetValue(obj, null);
                    SetPropertNewValue(focusNode, null);
                    break;
                case ObjectTreeNodeType.ListElement:
                    int index = (int)focusNode.GetValue(ColumnIndex);
                    obj.As<IList>().RemoveAt(index);
                    if (focusNode.ParentNode != null)
                        focusNode.ParentNode.Nodes.Remove(focusNode);
                    break;
                case ObjectTreeNodeType.DictionaryElement:
                    var key = focusNode.GetValue(ColumnIndex);
                    obj.As<IDictionary>().Remove(key);
                    if (focusNode.ParentNode != null)
                        focusNode.ParentNode.Nodes.Remove(focusNode);
                    break;
                default:
                    throw new Exception("此属性不允许被删除").AddExceptionData("ElementType", nodeType);
            }
            SetControlStatus();
        }

        private void ButtonModifyKey_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var focusNode = this.TreeListObject.FocusedNode;
            var nodeType = (ObjectTreeNodeType)focusNode.GetValue(ColumnPropertyElementType);
            var obj = focusNode.GetValue(ColumnObject);
            var propertyValue = focusNode.GetValue(ColumnPropertyValue);

            obj.CheckNotNull("字典对象不能为空");
            (nodeType == ObjectTreeNodeType.DictionaryElement).CheckTrue("只有字典元素允许修改键值");
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

        private void ListEditControl_DataModifyStateChanged(object sender, UI.WinForm.DataModifyStateChangedEventArgs e) {
            if (e.DataModified == true) {
                ResetNodeValueByEditControl(ListEditControl);
            }
        }

        private void ObjectEditControl_DataModifyStateChanged(object sender, UI.WinForm.DataModifyStateChangedEventArgs e) {
            if (e.DataModified == true) {
                ResetNodeValueByEditControl(ObjectEditControl);
            }
        }

        private void DictionaryEditControl_DataModifyStateChanged(object sender, UI.WinForm.DataModifyStateChangedEventArgs e) {
            if (e.DataModified == true) {
                ResetNodeValueByEditControl(DictionaryEditControl);
            }
        }
        #endregion

    }
}