using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.Config.EditControls;
using PAO.App;
using PAO.Config;
using PAO.WinForm;

namespace PAO.Controls
{
    /// <summary>
    /// 插件选择控件
    /// </summary>
    public partial class AddonSelectControl : BaseEditControl
    {
        public AddonSelectControl() {
            InitializeComponent();
            ShowApplyButton = false;
        }

        /// <summary>
        /// 插件过滤器
        /// </summary>
        private Func<PaoObject, bool> _AddonFilter = (obj) =>
        {
            return true;
        };


        public Func<PaoObject, bool> AddonFilter {
            set {
                Dictionary<string, PaoObject> editingAddonList = new Dictionary<string, PaoObject>();
                AddonPublic.TraverseAddon(editingAddonList, ConfigPublic.RootEditingObject);
                _AddonFilter = value;
                var addonList = editingAddonList.Values.Where(_AddonFilter).Select(p =>
                {
                    return new AddonInfo()
                    {
                        ID = p.ID,
                        Type = p.GetType().GetTypeString(),
                        Object = p.ObjectToString()
                    };
                }).ToList();
                if (addonList.Count == 0)
                    this.BindingSourceAddon.DataSource = null;
                else
                    this.BindingSourceAddon.DataSource = addonList;
            }
        }
        
        public override object EditValue {
            get {
                if (this.BindingSourceAddon.Position < 0)
                    return null;

                return this.BindingSourceAddon.Current.As<AddonInfo>().ID; 
            }

            set {
                base.EditValue = value;
                if(value.IsNotNullOrEmpty()) {
                    for(int i=0;i<this.BindingSourceAddon.Count;i++) {
                        if(this.BindingSourceAddon[i].As<AddonInfo>().ID == (string)value) {
                            this.BindingSourceAddon.Position = i;
                            break;
                        }
                    }
                }
            }
        }
    }
}
