using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.Config.Controls.EditControls;
using PAO.Data.Filters;
using PAO.Data;
using PAO.Config.Editors;
using DevExpress.XtraTreeList.Nodes;

namespace PAO.Config.PaoConfig
{
    /// <summary>
    /// 数据过滤器编辑器
    /// </summary>
    public partial class DataFilterEditControl : BaseEditControl
    {
        const int ImageIndex_AndFilter = 0;
        const int ImageIndex_OrFilter = 1;
        const int ImageIndex_SqlFilter = 2;

        public DataFilterEditControl() {
            InitializeComponent();
            this.ColumnFilter.ColumnEdit = new MemoExEditor().CreateEditor();
            this.ColumnDataType.ColumnEdit = new EnumEditor()
            {
                PropertyDescriptor = typeof(DataFilterInfo).GetPropertyDescriptor("DataType")
            }.CreateEditor();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private IDataFilter RootDataFilter;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private List<DataFilterInfo> FilterInfoList;

        public override object SelectedObject {
            get {
                return RootDataFilter;
            }

            set {
                FilterInfoList = new List<DataFilterInfo>();
                this.BindingSourceDataFilter.DataSource = FilterInfoList;
                if (value != null) {
                    value.CheckType<IDataFilter>("DataFilterEditControl只支持IDataFilter类型的编辑");
                    RootDataFilter = value as IDataFilter;
                    InitByDataFilter(FilterInfoList, RootDataFilter, null);
                    this.TreeListDataFilter.ExpandAll();
                }
                else {
                    RootDataFilter = null;
                }
                SetControlStatus();
            }
        }

        private DataFilterInfo GetCurrentData() {
            if (this.TreeListDataFilter.Nodes.Count == 0)
                return null;
            
            var focusedNode = this.TreeListDataFilter.FocusedNode;
            if (focusedNode == null)
                focusedNode = this.TreeListDataFilter.Nodes[0];
            
            return this.TreeListDataFilter.GetDataRecordByNode(focusedNode) as DataFilterInfo;
        }

        private static void InitByDataFilter(List<DataFilterInfo> filterInfoList, IDataFilter dataFilter, string parentID) {
            if (dataFilter == null)
                return;

            int imageIndex;
            if (dataFilter is SqlFilter)
                imageIndex = ImageIndex_SqlFilter;
            else if (dataFilter is AndLogicFilter)
                imageIndex = ImageIndex_AndFilter;
            else if (dataFilter is OrLogicFilter)
                imageIndex = ImageIndex_OrFilter;
            else
                throw new Exception("不支持的过滤器类型").AddExceptionData("过滤器", dataFilter);
            filterInfoList.Add(new DataFilterInfo()
            {
                ParentID = parentID,
                ImageIndex = imageIndex,
                DataFilter = dataFilter
            });

            if (dataFilter is CompositeLogicFilter) {
                var childFilters = dataFilter.As<CompositeLogicFilter>().ChildFilters;
                if (childFilters.IsNotNullOrEmpty()) {
                    foreach (var childFilter in childFilters) {
                        InitByDataFilter(filterInfoList, childFilter, dataFilter.As<PaoObject>().ID);
                    }
                }
            }
        }

        private IDataFilter AddDataFilter(Type filterType, int imageIndex) {
            var dataFilter = filterType.CreateInstance() as IDataFilter;
            var dataFilterInfo = GetCurrentData();
            if (dataFilterInfo == null) {
                RootDataFilter = dataFilter;
                FilterInfoList.Add(new DataFilterInfo()
                {
                    ParentID = null,
                    ImageIndex = imageIndex,
                    DataFilter = dataFilter
                });
            }
            else {
                var currentFilter = dataFilterInfo.DataFilter as CompositeLogicFilter;
                FilterInfoList.Add(new DataFilterInfo()
                {
                    ParentID = currentFilter.ID,
                    ImageIndex = imageIndex,
                    DataFilter = dataFilter
                });
                currentFilter.ChildFilters.Add(dataFilter);
            }
            ModifyData();
            this.TreeListDataFilter.RefreshDataSource();
            this.TreeListDataFilter.ExpandAll();
            SetControlStatus();
            return dataFilter;
        }

        private void DeleteFilter(string dataFilterID) {
            var filter = FilterInfoList.Where(p => p.ID == dataFilterID).FirstOrDefault();
            if (filter == null)
                return;
            FilterInfoList.Remove(filter);

            var childFilters = FilterInfoList.Where(p => p.ParentID == dataFilterID).ToList();
            foreach(var childFilter in childFilters) {
                DeleteFilter(childFilter.ID);
            }
        }

        private void SetControlStatus() {
            this.ButtonAnd.Enabled = true;
            this.ButtonOr.Enabled = true;
            this.ButtonSql.Enabled = true;
            var dataFilterInfo = GetCurrentData();
            if (dataFilterInfo != null) {
                var currentFilter = dataFilterInfo.DataFilter as IDataFilter;
                if (currentFilter != null && currentFilter is SqlFilter) {
                    this.ButtonAnd.Enabled = false;
                    this.ButtonOr.Enabled = false;
                    this.ButtonSql.Enabled = false;
                }
            }
            this.ButtonDelete.Enabled = this.BindingSourceDataFilter.Count > 0;
        }

        private void ButtonAnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddDataFilter(typeof(AndLogicFilter), ImageIndex_AndFilter);
        }

        private void ButtonOr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddDataFilter(typeof(OrLogicFilter), ImageIndex_AndFilter);
        }

        private void ButtonSql_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddDataFilter(typeof(SqlFilter), ImageIndex_SqlFilter);
        }

        private void ButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var currentFilter = GetCurrentData().DataFilter;
            if (currentFilter != null) {
                DeleteFilter(currentFilter.ID);
                ModifyData();
                this.TreeListDataFilter.RefreshDataSource();
                this.TreeListDataFilter.ExpandAll();
                SetControlStatus();
            }
        }

        private void TreeListDataFilter_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            this.TreeListDataFilter.FocusedNodeChanged -= TreeListDataFilter_FocusedNodeChanged;
            SetControlStatus();
            this.TreeListDataFilter.FocusedNodeChanged += TreeListDataFilter_FocusedNodeChanged;
        }

        private void TreeListDataFilter_GetNodeDisplayValue(object sender, DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs e) {
            var dataFilterInfo = GetCurrentData();
            if (dataFilterInfo != null && dataFilterInfo.DataFilter is CompositeLogicFilter) {
                if(e.Column != ColumnName) {
                    e.Value = null;
                }
            }
        }

        private void TreeListDataFilter_ShowingEditor(object sender, CancelEventArgs e) {
            var dataFilterInfo = GetCurrentData();
            if (dataFilterInfo != null && dataFilterInfo.DataFilter is CompositeLogicFilter) {
                e.Cancel = true;
            }
        }

        private void TreeListDataFilter_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e) {
            ModifyData();
        }
    }
}
