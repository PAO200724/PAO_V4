using PAO;
using PAO.Data;
using PAO.Report.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.Report.ValueFetchers
{
    /// <summary>
    /// 类：ReportDataValueFetcher
    /// 报表数据值获取器
    /// 从报表数据源中获取数据值的获取器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("报表数据值获取器")]
    [Description("从报表数据源中获取数据值的获取器")]
    public class ReportDataValueFetcher<T> : PaoObject, IValueFetch
    {
        #region 插件属性

        #region 属性：TableName
        /// <summary>
        /// 属性：TableName
        /// 表名
        /// 报表数据源中的表名
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("表名")]
        [Description("报表数据源中的表名")]
        public string TableName {
            get;
            set;
        }
        #endregion 属性：TableName

        #region 属性：Expression
        /// <summary>
        /// 属性：Expression
        /// 表达式
        /// 用于计算值的表达式
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("表达式")]
        [Description("用于计算值的表达式")]
        public string Expression {
            get;
            set;
        }
        #endregion 属性：Expression

        #region 属性：Filter
        /// <summary>
        /// 属性：Filter
        /// 过滤器
        /// 过滤器，在表达式计算时用，默认为null
        /// </summary>
        [AddonProperty]
        [DefaultValue("TRUE")]
        [DataMember(EmitDefaultValue = false)]
        [Name("过滤器")]
        [Description("过滤器，在表达式计算时用，默认为null")]
        public string Filter {
            get;
            set;
        }
        #endregion 属性：Filter


        #region 属性：ColumnName
        /// <summary>
        /// 属性：ColumnName
        /// 列名
        /// 如果Expression未设置，则取当前行的值
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("列名")]
        [Description("如果Expression未设置，则取当前行的值")]
        public string ColumnName {
            get;
            set;
        }
        #endregion 属性：ColumnName
        #endregion
        
        /// <summary>
        /// 报表视图
        /// </summary>
        [NonSerialized]
        private ReportView _ReportView;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ReportView ReportView {
            get { return _ReportView; }
            set { _ReportView = value; }
        }

        public ReportDataValueFetcher() {
            Filter = "TRUE";
        }

        public object FetchValue() {
            if (ReportView.DataSource == null || TableName.IsNullOrEmpty() || !ReportView.DataSource.Tables.Contains(TableName))
                return default(T);

            if (Expression.IsNotNullOrEmpty()) {
                return (T)ReportView.DataSource.Tables[0].Compute(Expression, Filter);
            }

            // 获取当前行
            if (ColumnName.IsNotNullOrEmpty()) {
                var bindingContext = ReportView.BindingContext[ReportView.DataSource, TableName];
                if(bindingContext.Position >= 0) {
                    return (T)bindingContext.Current.As<DataRowView>()[ColumnName];
                }
            }

            return default(T);
        }
    }
}
