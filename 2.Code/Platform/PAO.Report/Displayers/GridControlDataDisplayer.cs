using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.WinForm.Controls;
using PAO.UI.MVC;
using PAO.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using PAO.IO;
using PAO.UI.WinForm;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using PAO.Config.DockViews;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.BandedGrid;
using PAO.UI;
using System.IO;
using PAO.Report.Properties;
using PAO.Config;

namespace PAO.Report.Displayers
{
    /// <summary>
    /// 表格控件视图
    /// 作者：PAO
    /// </summary>
    [Icon(typeof(Resources), "table")]
    public partial class GridControlDataDisplayer : BaseDataDisplayer, IDataView, IBarSupport
    {
        public GridControlDataDisplayer() {
            InitializeComponent();
        }
        
        private BaseView MainView {
            get {
                return this.GridControl.MainView;
            }
        }
        
        private GridViewType _GridViewType;
        /// <summary>
        /// 视图类型
        /// </summary>
        public GridViewType GridViewType {
            get { return _GridViewType; }
            set { _GridViewType = value;
                switch (_GridViewType) {
                    case GridViewType.GridView:
                        this.GridControl.MainView = this.GridView;
                        this.ButtonViewType.ItemIndex = 0;
                        break;
                    case GridViewType.AdvancedBandedView:
                        this.GridControl.MainView = this.AdvBandedGridView;
                        this.ButtonViewType.ItemIndex = 1;
                        break;
                    case GridViewType.LayoutView:
                        this.GridControl.MainView = this.LayoutView;
                        this.ButtonViewType.ItemIndex = 2;
                        break;
                    case GridViewType.CardView:
                        this.GridControl.MainView = this.CardView;
                        this.ButtonViewType.ItemIndex = 3;
                        break;
                    default:
                        throw new Exception("不支持的表格类型");
                }
                RecoverLayout();
            }
        }

        protected override string[] ExportFileFilters {
            get {
                return new string[]
                {
                    FileExtentions.CSV,
                    FileExtentions.XLS,
                    FileExtentions.XLSX,
                    FileExtentions.HTML,
                    FileExtentions.MHT,
                    FileExtentions.PDF,
                    FileExtentions.TXT,
                };
            }
        }

        public IEnumerable<Bar> ExtendBars {
            get {
                return new Bar[]
                {
                    BarTools
                };
            }
        }

        private void RecoverLayout() {
            if (MainView is ColumnView) {
                var view = MainView as ColumnView;
                view.Columns.Clear();
            }
            MainView.PopulateColumns();
        }

        public void SetDataSource(DataSet dataSet) {
            var controller = Controller as GridControlController;

            if(dataSet.Tables.Contains(controller.DataMember)) {
                this.GridControl.DataMember = controller.DataMember;
            }
            this.GridControl.DataSource = dataSet;
            this.GridControl.RefreshDataSource();
        }

        protected override void OnSetController(BaseController value) {
            var controller = value as GridControlController;

            AddonPublic.LoadAddonExtendProperties(controller);
            GridViewType = controller.GridViewType;
            MainView.SetLayoutData(controller.LayoutData);
        }

        protected override void OnClosing() {
            var controller = Controller as GridControlController;
            controller.GridViewType = GridViewType;
            controller.LayoutData = MainView.GetLayoutData();
            AddonPublic.SaveAddonExtendProperties(controller, "GridViewType", "LayoutData");
        }
        
        protected override void OnExport(string fileName) {
            if (fileName == null)
                return;

            string ext = Path.GetExtension(fileName);
            switch(ext.ToUpper()) {
                case "CSV":
                    this.MainView.ExportToCsv(fileName);
                    break;
                case "XLS":
                    this.MainView.ExportToXls(fileName);
                    break;
                case "XLSX":
                    this.MainView.ExportToXlsx(fileName);
                    break;
                case "HTML":
                    this.MainView.ExportToHtml(fileName);
                    break;
                case "MHT":
                    this.MainView.ExportToMht(fileName);
                    break;
                case "PDF":
                    this.MainView.ExportToPdf(fileName);
                    break;
                case "TXT":
                    this.MainView.ExportToText(fileName);
                    break;
            }
        }
        
        private void ButtonRecoverLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if(UIPublic.ShowYesNoDialog("您是否要恢复表格的默认格式？") == DialogReturn.Yes) {
                RecoverLayout();
            }
        }
        
        private void ButtonViewType_ListItemClick(object sender, ListItemClickEventArgs e) {
            switch (e.Index) {
                case 0:
                    GridViewType = GridViewType.GridView;
                    break;
                case 1:
                    GridViewType = GridViewType.AdvancedBandedView;
                    break;
                case 2:
                    GridViewType = GridViewType.LayoutView;
                    break;
                case 3:
                    GridViewType = GridViewType.CardView;
                    break;
            }
        }
        
        private void ButtonExport_ItemClick(object sender, ItemClickEventArgs e) {
            string fileName = null;
            if(UIPublic.ShowSaveFileDialog("导出",ref fileName, ExportFileFilters) == DialogReturn.OK) {
                Export();
            }
        }

        private void ButtonPrint_ItemClick(object sender, ItemClickEventArgs e) {
            MainView.ShowPrintPreview();
        }

        private void ButtonProperty_ItemClick(object sender, ItemClickEventArgs e) {
            ConfigForm.ShowConfigForm(MainView);
        }
    }
}
