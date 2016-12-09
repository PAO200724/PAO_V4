using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.MVC;

namespace PAO.UI.WinForm.Controls
{
    /// <summary>
    /// 基础对话框控件
    /// 作者：刘丹
    /// </summary>
    public partial class DialogControl : DevExpress.XtraEditors.XtraUserControl, IView
    {
        public DialogControl() {
            InitializeComponent();
            ShowApplyButton = false;
            ShowCancelButton = true;
            DataModified = false;
        }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public Image Icon { get; set; }
        /// <summary>
        /// 大图标
        /// </summary>
        public Image LargeIcon { get; set; }

        /// <summary>
        /// 显示应用按钮
        /// </summary>
        public virtual bool ShowApplyButton { get; set; }
        /// <summary>
        /// 显示取消按钮
        /// </summary>
        public virtual bool ShowCancelButton { get; set; }
        /// <summary>
        /// 数据修改
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool DataModified { get; private set; }
        
        /// <summary>
        /// 设置Form状态
        /// </summary>
        public Action<Form> OnSetFormState;

        /// <summary>
        /// 数据修改状态变化
        /// </summary>
        public event EventHandler<DataModifyStateChangedEventArgs> DataModifyStateChanged;

        public virtual void FromUIItem(IUIItem uiItem) {
            ID = uiItem.ID;
            Caption = uiItem.Caption;
            Icon = uiItem.Icon;
            LargeIcon = uiItem.LargeIcon;
        }

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
