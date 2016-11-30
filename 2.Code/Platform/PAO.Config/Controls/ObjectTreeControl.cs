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

namespace PAO.Config.Controls
{
    /// <summary>
    /// 对象树控件
    /// </summary>
    public partial class ObjectTreeControl : DialogControl
    {
        public ObjectTreeControl() {
            InitializeComponent();
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
                , ElementType.Object);
            // 创建属性
            objNode.ImageIndex = ImageIndex_Object;
            CreateTreeNodeByObject(objNode, obj);
        }

        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="obj">对象</param>
        private static void CreateTreeNodeByObject(TreeListNode node, object obj) {
            if (obj == null)
                return;
            var objType = obj.GetType();

            if (objType.IsAddonType()) {
                // 获取对象属性并添加到树中
                foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(objType)) {
                    if (propDesc.Attributes.GetAttribute<AddonPropertyAttribute>() != null)
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
                        , key
                        , value
                        , obj
                        , ElementType.Dictionary);
                    elementNode.ImageIndex = ImageIndex_Dictionary;
                    CreateTreeNodeByObject(elementNode, value);
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
                        , i
                        , element
                        , obj
                        , ElementType.List);
                    elementNode.ImageIndex = ImageIndex_List;
                    CreateTreeNodeByObject(elementNode, element);
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
                , ElementType.Property);
            propNode.ImageIndex = ImageIndex_Property;
            CreateTreeNodeByObject(propNode, propVal);
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
    }
}
