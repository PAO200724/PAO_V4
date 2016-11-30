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
        }

        private object _SelectedObject;
        public object SelectedObject {
            get {
                return _SelectedObject;
            } 
            set {
                if(_SelectedObject != value) {
                    _SelectedObject = value;
                    this.TreeListObject.Nodes.Clear();
                    CreateTreeNode(this.TreeListObject.Nodes, _SelectedObject);
                }
            }
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

        private void SetElementInfomation(TreeListNode node) {
            this.LabelControlPropertyTitle.Text = node.GetValue(ColumnPropertyName) as string;
            this.GroupControlObject.Text = this.LabelControlPropertyTitle.Text;
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
        }

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
        public static int ImageIndex_Dictionary = 3;

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
                , null
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
                    if (propDesc.Attributes.GetAttribute<AddonPropertyAttribute>() != null 
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
            }
            else if (objType.IsAddonEnumerableType()) {
                var list = obj as IEnumerable;
                int i = 0;
                foreach (var element in list) {
                    if (!(element is PaoObject))
                        break;

                    string elementString = String.Format("[索引：{0}]", i);
                    var elementNode = node.Nodes.Add(elementString
                        , GetObjectString(element)
                        , GetObjectTypeString(element)
                        , parentPropDesc
                        , element
                        , obj
                        , ElementType.List
                        , i);
                    elementNode.ImageIndex = ImageIndex_List;
                    CreateChildNodesByObject(elementNode, element, null);
                    i++;
                }
            }
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
            else if (objType.IsAddonEnumerableType())
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

        private void SetControlStatus() {
            var focusNode = this.TreeListObject.FocusedNode;
            var elementType = (ElementType)focusNode.GetValue(ColumnPropertyElementType);
            var propertyValue = focusNode.GetValue(ColumnPropertyValue);

            this.ButtonCreate.Enabled = (elementType != ElementType.Object);
            this.ButtonDelete.Enabled = (propertyValue.IsNotNull());
        }

        private void TreeListObject_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e) {
            if(e.Node != null) {
                SetElementInfomation(e.Node);
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

        }
        
        private void ButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }

        public override void SetFormState(Form form) {
            form.WindowState = FormWindowState.Maximized;
        }
    }
}