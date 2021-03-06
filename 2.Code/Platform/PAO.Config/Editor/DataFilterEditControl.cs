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
using PAO.Data.Filters;
using PAO.Data;
using DevExpress.XtraTreeList.Nodes;
using PAO.WinForm;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 数据过滤器编辑器
    /// </summary>
    public partial class DataFilterEditControl : BaseObjectEditControl
    {
        const int ImageIndex_AndFilter = 0;
        const int ImageIndex_OrFilter = 1;
        const int ImageIndex_SqlFilter = 2;

        public DataFilterEditControl() {
            InitializeComponent();
            this.ColumnFilter.ColumnEdit = new MemoExEditController().CreateRepositoryItem(typeof(string));
        }

        private DataFilter RootDataFilter;

        private List<DataFilterInfo> FilterInfoList;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                return RootDataFilter;
            }

            set {
                FilterInfoList = new List<DataFilterInfo>();
                this.BindingSourceDataFilter.DataSource = FilterInfoList;
                if (value != null) {
                    value.CheckType<DataFilter>("DataFilterEditControl只支持IDataFilter类型的编辑");
                    RootDataFilter = value as DataFilter;
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

        private static void InitByDataFilter(List<DataFilterInfo> filterInfoList, DataFilter dataFilter, string parentID) {
            if (dataFilter == null)
                return;

            int imageIndex;
            if (dataFilter is Sql)
                imageIndex = ImageIndex_SqlFilter;
            else if (dataFilter is And)
                imageIndex = ImageIndex_AndFilter;
            else if (dataFilter is Or)
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

        private DataFilter AddDataFilter(Type filterType, int imageIndex) {
            var dataFilter = filterType.CreateInstance() as DataFilter;
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

        protected override void SetControlStatus() {
            this.ButtonAnd.Enabled = true;
            this.ButtonOr.Enabled = true;
            this.ButtonSql.Enabled = true;
            var dataFilterInfo = GetCurrentData();
            if (dataFilterInfo != null) {
                var currentFilter = dataFilterInfo.DataFilter as DataFilter;
                if (currentFilter != null && currentFilter is Sql) {
                    this.ButtonAnd.Enabled = false;
                    this.ButtonOr.Enabled = false;
                    this.ButtonSql.Enabled = false;
                }
            }
            this.ButtonDelete.Enabled = this.BindingSourceDataFilter.Count > 0;
            base.SetControlStatus();
        }

        private void ButtonAnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddDataFilter(typeof(And), ImageIndex_AndFilter);
        }

        private void ButtonOr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddDataFilter(typeof(Or), ImageIndex_AndFilter);
        }

        private void ButtonSql_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            AddDataFilter(typeof(Sql), ImageIndex_SqlFilter);
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
