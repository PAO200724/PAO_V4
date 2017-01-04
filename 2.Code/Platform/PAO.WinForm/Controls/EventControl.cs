using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.Event;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;

namespace PAO.WinForm.Controls
{
    /// <summary>
    /// 事件控件
    /// 显示事件信息
    /// </summary>
    public partial class EventControl : DialogControl
    {
        private EventInfo _EventInfo;
        /// <summary>
        /// 事件信息
        /// </summary>
        public EventInfo EventInfo {
            get { return _EventInfo; }
            set { _EventInfo = value;
                Initialize(_EventInfo);
            }
        }

        public EventControl() {
            InitializeComponent();
            ShowApplyButton = false;
            ShowCancelButton = false;
        }

        public override void SetFormState(Form form) {
            form.TopMost = true;
            base.SetFormState(form);
        }

        public void Initialize(EventInfo eventInfo) {
            _EventInfo = eventInfo;
            this.TextEditSource.Text = _EventInfo.Source;
            this.TextEditMessage.Text = _EventInfo.Message;
            this.TextEditTime.Text = _EventInfo.Time.ToString();
            this.TextEditType.Text = _EventInfo.Type;
            this.MemoEditDetail.Text = _EventInfo.DetailMessage;
            // 数据
            if (_EventInfo.Data.IsNotNullOrEmpty()) {
                this.GridControlData.DataSource = this._EventInfo.Data.Select(p => new
                {
                    Key = p.Key,
                    Value = p.Value
                });
            }
            if (_EventInfo.ScreenShot != null) {
                this.ImageControl.Image = _EventInfo.ScreenShot;
                this.LayoutControlGroupAssetSnapshot.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else {
                this.LayoutControlGroupScreenShot.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (_EventInfo.AssetSnapshot != null) {
                this.TreeListSnapShot.Nodes.Clear();
                CreateTreeNode(this.TreeListSnapShot.Nodes, _EventInfo.AssetSnapshot);
                this.LayoutControlGroupAssetSnapshot.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else {
                this.LayoutControlGroupAssetSnapshot.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }


        /// <summary>
        /// 创建树节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="obj">对象</param>
        public static void CreateTreeNode(TreeListNodes nodes, object obj) {
            var objNode = nodes.Add(GetObjectString(obj), obj);
            // 创建属性
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
        private static TreeListNode CreateElementNode(TreeListNode parentNode
            , PropertyDescriptor parentPropDesc
            , object obj
            , object key, object value) {
            string elementString;
            if (parentPropDesc.PropertyType.IsAddonListType()) {
                elementString = String.Format("[索引：{0}] {1}", key, GetObjectString(value));
            }
            else if (parentPropDesc.PropertyType.IsAddonDictionaryType()) {
                elementString = String.Format("[键：{0}] {1}", key, GetObjectString(value));
            }
            else {
                throw new Exception("此类型的属性不支持增加元素节点").AddExceptionData("属性类型", parentPropDesc.PropertyType);
            }
            var elementNode = parentNode.Nodes.Add(elementString, value);
            CreateChildNodesByObject(elementNode, value, null);
            return elementNode;
        }

        /// <summary>
        /// 利用属性描述创建节点
        /// </summary>
        /// <param name="parentNode">上级节点</param>
        /// <param name="obj">对象</param>
        /// <param name="propDesc">属性描述</param>
        private static TreeListNode CreateTreeNodesByProperty(TreeListNode parentNode, object obj, PropertyDescriptor propDesc) {
            var propVal = propDesc.GetValue(obj);
            var displayAttribute = propDesc.Attributes.GetAttribute<DisplayNameAttribute>();
            var nodeString = String.Format("[{0}] {1}"
                , displayAttribute == null ? propDesc.Name : displayAttribute.DisplayName
                , GetObjectString(propVal));
            var propNode = parentNode.Nodes.Add(nodeString, propVal);
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

        private void TreeListSnapShot_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if(this.TreeListSnapShot.FocusedNode == null) {
                this.PropertyGridControl.SelectedObject = null;
            } else {
                this.PropertyGridControl.SelectedObject = this.TreeListSnapShot.FocusedNode.GetValue(ColumnAddon);
            }
        }
    }
}
