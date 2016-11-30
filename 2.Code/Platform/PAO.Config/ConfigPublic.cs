using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Config
{
    /// <summary>
    /// 静态类：ConfigPublic
    /// 配置公共类
    /// 作者：PAO
    /// </summary>
    public static class ConfigPublic
    {

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
            string propString = String.Format("{0}"
                , GetObjectString(obj));
            var objNode = nodes.Add(propString, null, null, obj, ElementType.Object);
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

            if (obj is PaoObject) {
                // 获取对象属性并添加到树中
                foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(objType)) {
                    if (propDesc.Attributes.GetAttribute<AddonPropertyAttribute>() != null)
                        CreateTreeNodesByProperty(node, obj, propDesc);
                }
            }
            else if (obj is IDictionary) {
                var dict = obj as IDictionary;
                foreach (var key in dict) {
                    var keyString = key.ToString();
                    var value = dict[key];
                    if (!(value is PaoObject))
                        break;

                    string elementString = String.Format("[键：{0}]{1}"
                        , key
                        , value == null ? null : String.Format(" = {0}", GetObjectString(value)));
                    var elementNode = node.Nodes.Add(elementString, key, value, obj, ElementType.Dictionary);
                    elementNode.ImageIndex = ImageIndex_Dictionary;
                    CreateTreeNodeByObject(elementNode, value);
                }
            }
            else if (obj is IEnumerable) {
                var list = obj as IEnumerable;
                int i = 0;
                foreach (var element in list) {
                    if (!(element is PaoObject))
                        break;

                    string elementString = String.Format("[索引：{0}]{1}"
                        , i
                        , element == null ? null : String.Format(" = {0}", GetObjectString(element)));
                    var elementNode = node.Nodes.Add(elementString, i, element, obj, ElementType.List);
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
            var propType = propDesc.GetType();
            var displayAttribute = propDesc.Attributes.GetAttribute<DisplayNameAttribute>();
            string propString = String.Format("[{0}]{1}"
                , displayAttribute == null ? propDesc.Name : displayAttribute.DisplayName
                , propVal == null ? null : String.Format(" = {0}", GetObjectString(propVal)));
            var propNode = node.Nodes.Add(propString, propDesc, propVal, obj, ElementType.Property);
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
                return null;

            var objType = obj.GetType();
            var typeName = objType.Name;

            string objString = null;
            var displayAttribute = obj.GetType().GetAttribute<DisplayNameAttribute>(false);
            if (displayAttribute != null)
                objString = displayAttribute.DisplayName;
            else if (objType.IsDerivedFrom(typeof(IDictionary)))
                objString = "树";
            else if (objType.IsDerivedFrom(typeof(List<>)) || objType.IsArray)
                objString = "列表";
            else
                objString = obj.ToString();
            return String.Format("{0}:{1}", typeName, objString);
        }
        #endregion
    }
}
