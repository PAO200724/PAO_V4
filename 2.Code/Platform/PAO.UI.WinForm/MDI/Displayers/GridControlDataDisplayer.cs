﻿using System;
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
using GridView = DevExpress.XtraGrid.Views.Base;
using PAO.IO;

namespace PAO.UI.WinForm.MDI.Displayers
{
    /// <summary>
    /// 表格控件视图
    /// 作者：PAO
    /// </summary>
    public partial class GridControlDataDisplayer : BaseDataDisplayer, IDataView, IParameterProvide
    {
        public GridControlDataDisplayer() {
            InitializeComponent();
        }

        public string DataMember {
            get {
                return this.GridControl.DataMember;
            }

            set {
                this.GridControl.DataMember = value;
            }
        }

        public object DataSource {
            get {
                return this.GridControl.DataSource;
            }

            set {
                this.GridControl.DataSource = value;
            }
        }

        public string ParameterTableName {
            get {
                return DataMember;
            }
        }

        private GridView.BaseView MainView {
            get {
                return this.GridControl.MainView;
            }
        }
        
        private GridViewType _GridViewType;

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


        public IEnumerable<DataField> ParameterValues {
            get {
                if(this.GridView.FocusedRowHandle != GridControl.InvalidRowHandle) {
                    var dataRow = GridView.GetDataRow(this.GridView.FocusedRowHandle);
                    var dataFields = new List<DataField>();
                    foreach (DataColumn dataColumn in dataRow.Table.Columns) {
                        if(!dataRow.IsNull(dataColumn)) {
                            dataFields.Add(new DataField()
                            {
                                Name = dataColumn.ColumnName,
                                Value = dataRow[dataColumn]
                            });
                        }
                    }
                    return dataFields;
                }

                return null;
            }
        }

        public void SetDataSource(DataSet dataSet) {
            DataSource = dataSet;
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

        public byte[] LayoutData {
            get {
                return MainView.GetLayoutData();
            }

            set {
                MainView.SetLayoutData(value);
            }
        }

    }
}
