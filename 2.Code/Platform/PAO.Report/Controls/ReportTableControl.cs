﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.WinForm.Editors;
using DevExpress.XtraEditors.Repository;
using PAO.Data;
using PAO.UI.WinForm;
using DevExpress.XtraLayout;

namespace PAO.Report.Controls
{
    /// <summary>
    /// 报表数据表控件
    /// 作者：PAO
    /// </summary>
    public partial class ReportTableControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ReportTableControl() {
            InitializeComponent();
        }

        public event EventHandler QueryMore;
        public event EventHandler QueryAll;

        private ReportDataTable _ReportDataTable;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReportDataTable ReportDataTable {
            get {
                return _ReportDataTable;
            }
            set {
                _ReportDataTable = value;
                if (_ReportDataTable == null)
                    return;
                
                RecreateParameterInputControls();
            }
        }

        public string TableName {
            get {
                if (_ReportDataTable == null)
                    return null;
                return _ReportDataTable.TableName;
            }
        }

        public void StartQuery() {
            this.BarProgress.Visible = true;
            this.EditItemProgress.Stopped = false;
            this.Refresh();
        }

        public void EndQuery() {
            this.BarProgress.Visible = false;
            this.EditItemProgress.Stopped = true;
            this.Refresh();
        }

        public int RowCount {
            get {
                if (this.BarItemCount.EditValue == null)
                    return 0;
                return (int)this.BarItemCount.EditValue;
            }

            set {
                this.BarItemCount.EditValue = value;
            }
        }

        /// <summary>
        /// 创建参数输入控件
        /// </summary>
        private void RecreateParameterInputControls() {
            LayoutControlGroupRoot.Items.Clear();
            foreach (var parameter in _ReportDataTable.QueryParameters) {
                if (parameter.UserInput) {
                    // 创建编辑控件
                    RepositoryItem repositoryItem;
                    if (parameter.Editor != null) {
                        repositoryItem = parameter.Editor.CreateEditor();
                    }
                    else {
                        Type valueType = DataPublic.GetNativeTypeByDbType(parameter.Type);
                        var repositoryItemCreator = WinFormPublic.GetDefaultEditorByType(valueType);
                        repositoryItem = repositoryItemCreator.CreateEditor();
                    }
                    var editor = repositoryItem.CreateEditor();
                    editor.Name = parameter.ID;
                    editor.Properties.Assign(repositoryItem);

                    if (parameter.ValueFetcher != null) {
                        editor.EditValue = parameter.ValueFetcher.Value.FetchValue();
                    }
                    else {
                        editor.EditValue = null;
                    }

                    // 创建LayoutItem
                    var layoutControlItem = LayoutControlGroupRoot.AddItem();
                    layoutControlItem.Name = parameter.ID;
                    layoutControlItem.Text = parameter.Caption;
                    layoutControlItem.CustomizationFormText = parameter.Caption;
                    layoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;
                    layoutControlItem.TextVisible = true;
                    layoutControlItem.ShowInCustomizationForm = true;
                    layoutControlItem.Control = editor;
                    LayoutControl.Refresh();
                }
            }
            this.Refresh();
        }

        private void ButtonMore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (QueryMore != null)
                QueryMore(this, new EventArgs());
        }

        private void ButtonAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (QueryAll != null)
                QueryAll(this, new EventArgs());
        }
    }
}
