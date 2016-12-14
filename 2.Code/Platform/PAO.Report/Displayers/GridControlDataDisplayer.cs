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

namespace PAO.Report.Displayers
{
    /// <summary>
    /// 表格控件视图
    /// 作者：PAO
    /// </summary>
    public partial class GridControlDataDisplayer : BaseDataDisplayer, IDataView
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
                        break;
                    case GridViewType.LayoutView:
                        this.GridControl.MainView = this.LayoutView;
                        break;
                    case GridViewType.BandedView:
                        this.GridControl.MainView = this.BandedGridView;
                        break;
                    case GridViewType.AdvancedBandedView:
                        this.GridControl.MainView = this.AdvBandedGridView;
                        break;
                    case GridViewType.CardView:
                        this.GridControl.MainView = this.CardView;
                        break;
                    case GridViewType.TileView:
                        this.GridControl.MainView = this.TileView;
                        break;
                    default:
                        throw new Exception("不支持的表格类型");
                }
            }
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
            GridViewType = GridViewType;
            controller.LayoutData = MainView.GetLayoutData();
            AddonPublic.SaveAddonExtendProperties(controller, "LayoutData");
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

        protected override void OnExport(string fileName, string ext) {
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

        private void GridView_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                var hitTest = GridView.CalcHitInfo(e.X, e.Y);
                object selectedObject = null;
                if(hitTest.InColumn) {
                    selectedObject = hitTest.Column;
                } else {
                    selectedObject = GridView;
                }

                if(selectedObject != null) {
                    PropertyView.SetSelectedObject(selectedObject);
                }
            }
        }
    }
}
