﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.UI.WinForm.Controls
{
    /// <summary>
    /// 基础对话框控件
    /// </summary>
    public partial class DialogControl : DevExpress.XtraEditors.XtraUserControl
    {
        public DialogControl() {
            InitializeComponent();
            ShowApplyButton = false;
            ShowCancelButton = true;
            DataModified = false;
        }

        public virtual bool ShowApplyButton { get; set; }

        public virtual bool ShowCancelButton { get; set; }

        public virtual bool DataModified { get; private set; }

        public Action<Form> OnSetFormState;

        public event EventHandler<DataModifyStateChangedEventArgs> DataModifyStateChanged;

        protected void FileDataModifyStateChangedEvent(bool dataModifed) {
            if (DataModifyStateChanged != null)
                DataModifyStateChanged(this, new DataModifyStateChangedEventArgs() { DataModified = dataModifed });
        }
        
        public virtual void OnClosing(DialogResult dialogResult, ref bool cancel) {
        }

        public virtual void SetFormState(Form form) {
            if(OnSetFormState != null) {
                OnSetFormState(form);
            }
        }

        public virtual void ModifyData() {
            DataModified = true;
            FileDataModifyStateChangedEvent(DataModified);
        }

        public virtual void Apply() {
            DataModified = false;
            FileDataModifyStateChangedEvent(DataModified);
        }
    }
}
