﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.Config.Editor;
using PAO.Data;
using PAO.WinForm;
using PAO.Data.Filters;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 数据命令信息编辑器
    /// 作者：PAO
    /// </summary>
    public partial class DataCommandInfoEditControl : BaseObjectEditControl
    {
        public DataCommandInfoEditControl() {
            InitializeComponent();
        }
        DataCommandInfo DataCommandInfo;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                DataCommandInfo.DataFilter = this.DataFilterEditControl.EditValue as DataFilter;
                return DataCommandInfo;
            }

            set {
                if(value == null) {
                    DataCommandInfo = null;
                    this.DataFilterEditControl.EditValue = null;
                    this.DataFilterEditControl.Enabled = false;
                    this.BindingSourceDataCommandInfo.DataSource = null;
                } else if(value is DataCommandInfo) {
                    DataCommandInfo = value as DataCommandInfo;
                    this.BindingSourceDataCommandInfo.DataSource = typeof(DataCommandInfo);
                    this.BindingSourceDataCommandInfo.Add(DataCommandInfo);
                    this.DataFilterEditControl.Enabled = true;
                    this.DataFilterEditControl.EditValue = DataCommandInfo.DataFilter;
                }
                else {
                    throw new Exception("DataCommandInfoEditControl只支持编辑DataCommandInfo类型的数据")
                        .AddExceptionData("数据类型", value);
                }
                Apply();
            }
        }

        private void DataFilterEditControl_DataModifyStateChanged(object sender, WinForm.DataModifyStateChangedEventArgs e) {
            if(e.DataModified) {
                ModifyData();
            }
        }

        private void BindingSourceDataCommandInfo_CurrentItemChanged(object sender, EventArgs e) {
            ModifyData();
        }
    }
}
