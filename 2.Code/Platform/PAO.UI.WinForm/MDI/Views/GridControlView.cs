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

namespace PAO.UI.WinForm.MDI.Views
{
    /// <summary>
    /// 表格控件视图
    /// 作者：PAO
    /// </summary>
    public partial class GridControlView : DialogControl, IDataView, IParameterProvide
    {
        public GridControlView() {
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

        public IViewContainer ViewContainer {
            get; set;
        }

        public void SetDataSource(DataSet dataSet) {
            DataSource = dataSet;
        }
    }
}
