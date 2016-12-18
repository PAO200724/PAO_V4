using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using static PAO.DataSetExtendProperty;
using PAO.IO;
using PAO.WinForm;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 插件扩展编辑器
    /// 作者：PAO
    /// </summary>
    public partial class AddonExtentionEditControl : TypeEditControl
    {
        public AddonExtentionEditControl() {
            InitializeComponent();
        }

        /// <summary>
        /// 扩展属性表
        /// </summary>
        ExtendPropertyDataTable _ExtendPropertyDataTable;
        private List<AddonPropertyInfo> AddonPropertyList;
        /// <summary>
        /// 原始对象
        /// </summary>
        private PaoObject _OriginAddon;

        public PaoObject OriginAddon {
            get { return _OriginAddon; }
            set { _OriginAddon = value;
                SetDataToControl();
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object SelectedObject {
            get {
                GetDataFromControl();
                return _ExtendPropertyDataTable; 
            }

            set {
                if(value == null) {
                    _ExtendPropertyDataTable = null;
                } else if(!(value is ExtendPropertyDataTable)) {
                    throw new Exception("AddonExtentionEditControl只能编辑类型为ExtendPropertyDataTable的对象");
                } else {
                    _ExtendPropertyDataTable = value as ExtendPropertyDataTable;
                }
                SetDataToControl();
            }
        }

        /// <summary>
        /// 用数据生成画面
        /// </summary>
        public void SetDataToControl() {
            if(OriginAddon != null) {
                AddonPropertyList = new List<EditControls.AddonPropertyInfo>();
                var properties = TypeDescriptor.GetProperties(OriginAddon.GetType());
                foreach(PropertyDescriptor propDesc in properties) {
                    if(propDesc.Attributes.GetAttribute<AddonPropertyAttribute>() != null) {
                        var displayName = propDesc.DisplayName;
                        var propertyInfo = new AddonPropertyInfo()
                        {
                            Checked = false,
                            DisplayName = displayName,
                            Property = propDesc,
                            OriginValue = propDesc.GetValue(OriginAddon)
                        };
                        AddonPropertyList.Add(propertyInfo);
                    }
                }

                if (_ExtendPropertyDataTable != null) {
                    var extendPropertyRows = _ExtendPropertyDataTable.AsEnumerable<ExtendPropertyRow>().Where(p => p.AddonID == OriginAddon.ID);
                    foreach(var extendPropertyRow in extendPropertyRows) {
                        var propInfo = AddonPropertyList.Where(p => p.Property.Name == extendPropertyRow.PropertyName).FirstOrDefault();
                        if (propInfo != null) {
                            propInfo.Checked = true;
                            propInfo.PropertyValue = IOPublic.Deserialize<string>(extendPropertyRow.PropertyValue);
                        }
                    }
                }
                this.BindingSourceAddonPropertyInfo.DataSource = AddonPropertyList;
            }
            else {
                AddonPropertyList = null;
                this.BindingSourceAddonPropertyInfo.DataSource = null;
            }
            this.GridViewAddonExtention.RefreshData();
        }

        /// <summary>
        /// 将数据从画面读取
        /// </summary>
        public void GetDataFromControl() {
            this.GridViewAddonExtention.CloseEditor();
            if (OriginAddon != null && _ExtendPropertyDataTable != null) {
                var extendPropertyRows = _ExtendPropertyDataTable.AsEnumerable<ExtendPropertyRow>().Where(p => p.AddonID == OriginAddon.ID).ToList();
                foreach (var extendPropertyRow in extendPropertyRows) {
                    extendPropertyRow.Delete();
                }
                if (AddonPropertyList.IsNotNullOrEmpty()) {
                    foreach (var propInfo in AddonPropertyList.Where(p => p.Checked)) {
                        var newRow = _ExtendPropertyDataTable.AddExtendPropertyRow(OriginAddon.ID
                            , propInfo.Property.Name
                            , IOPublic.Serialize<string>(propInfo.PropertyValue??propInfo.OriginValue));
                    }
                }
                _ExtendPropertyDataTable.AcceptChanges();
            }
        }

        private void GridViewAddonExtention_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e) {
            ModifyData();
        }

        private void GridControlAddonExtention_Leave(object sender, EventArgs e) {
            this.GridViewAddonExtention.CloseEditor();
        }
    }
}
