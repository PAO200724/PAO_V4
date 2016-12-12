using System;
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

        private ReportDataTable _ReportDataTable;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReportDataTable ReportDataTable {
            get { return _ReportDataTable; }
            set {
                _ReportDataTable = value;
                RecreateParameterInputControls();
            }
        }

        /// <summary>
        /// 创建参数输入控件
        /// </summary>
        private void RecreateParameterInputControls() {
            LayoutControlGroupRoot.Items.Clear();
            foreach (var parameter in _ReportDataTable.QueryParameters) {
                if (parameter.UserInput) {

                    var layoutControlItem = LayoutControlGroupRoot.AddItem();
                    layoutControlItem.Name = parameter.ID;
                    layoutControlItem.Text = parameter.Caption;
                    layoutControlItem.CustomizationFormText = parameter.Caption;
                    layoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;
                    layoutControlItem.TextVisible = true;
                    layoutControlItem.ShowInCustomizationForm = true;

                    RepositoryItem editor;
                    if (parameter.Editor != null) {
                        editor = parameter.Editor.CreateEditor();
                    }
                    else {
                        Type valueType = DataPublic.GetNativeTypeByDbType(parameter.Type);
                        var edit = WinFormPublic.GetDefaultEditorByType(valueType);
                        editor = edit.CreateEditor();
                    }
                    var editorControl = editor.CreateEditor();
                    layoutControlItem.Control = editorControl;

                    if (parameter.ValueFetcher != null) {
                        editorControl.EditValue = parameter.ValueFetcher.Value.FetchValue();
                    }
                    LayoutControl.Refresh();
                }
            }
            this.Refresh();
        }
    }
}
