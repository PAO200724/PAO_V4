using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.Config.Controls.EditControls
{
    /// <summary>
    /// 插件扩展编辑器
    /// 作者：PAO
    /// </summary>
    public partial class AddonExtentionEditControl : BaseEditControl
    {
        public AddonExtentionEditControl() {
            InitializeComponent();
        }

        /// <summary>
        /// 插件扩展
        /// </summary>
        private AddonExtention AddonExtention;
        private List<AddonPropertyInfo> AddonPropertyList;
        private PaoObject _OriginAddon;

        public PaoObject OriginAddon {
            get {
                return _OriginAddon;
            }

            set {
                _OriginAddon = value;
            }
        }

        public override object SelectedObject {
            get {
                SetData();
                return AddonExtention; 
            }

            set {
                if(value == null) {
                    AddonExtention = new AddonExtention();
                } else if(!(value is AddonExtention)) {
                    throw new Exception("AddonExtentionEditControl只能编辑类型为AddonExtention的对象");
                } else {
                    AddonExtention = value as AddonExtention;
                }
                GetData();
            }
        }

        /// <summary>
        /// 用数据生成画面
        /// </summary>
        private void GetData() {
            AddonPropertyList = new List<EditControls.AddonPropertyInfo>();
            if(_OriginAddon != null) {
                var properties = TypeDescriptor.GetProperties(_OriginAddon.GetType());
                foreach(PropertyDescriptor propDesc in properties) {
                    if(propDesc.Attributes.GetAttribute<AddonPropertyAttribute>() != null) {
                        var displayName = propDesc.DisplayName;
                        var propertyInfo = new AddonPropertyInfo()
                        {
                            Checked = false,
                            DisplayName = displayName,
                            Property = propDesc,
                            OriginValue = propDesc.GetValue(_OriginAddon)
                        };
                        AddonPropertyList.Add(propertyInfo);
                    }
                }
            }

            if(AddonExtention.ExtendProperties == null)
                AddonExtention.ExtendProperties = new Dictionary<string, object>();
            foreach (var kv in AddonExtention.ExtendProperties) {
                var propInfo = AddonPropertyList.Where(p => p.Property.Name == kv.Key).FirstOrDefault();
                if(propInfo != null) {
                    propInfo.Checked = true;
                    propInfo.PropertyValue = kv.Value;
                }
            }

            if(AddonPropertyList.IsNotNullOrEmpty()) {
                this.BindingSourceAddonPropertyInfo.DataSource = AddonPropertyList;
            } else {
                this.BindingSourceAddonPropertyInfo.DataSource = null;
            }
        }

        /// <summary>
        /// 将数据从画面读取
        /// </summary>
        private void SetData() {
            this.GridViewAddonExtention.CloseEditor();
            if (AddonExtention == null) {
                if(_OriginAddon == null)
                    return;
                AddonExtention = new AddonExtention() { ID = _OriginAddon.ID };
            }
            AddonExtention.ExtendProperties = new Dictionary<string, object>();
            if (AddonPropertyList.IsNotNullOrEmpty()) {
                foreach(var propInfo in AddonPropertyList.Where(p=>p.Checked)) {
                    AddonExtention.ExtendProperties.Add(propInfo.Property.Name
                        , propInfo.PropertyValue ?? propInfo.OriginValue);
                }
            }
        }

        private void GridViewAddonExtention_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e) {
            ModifyData();
        }

        private void ButtonExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ExportSelectedObject();
        }

        private void ButtonImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ImportSelectedObject();
        }
    }
}
