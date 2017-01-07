using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;
using PAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAO.Data;
using System.Data;

namespace PAO.Report.ValueFetchers
{
    /// <summary>
    /// 类：DataSourceValueFetcher
    /// 数据源值获取器
    /// 从数据源获取值的获取器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("数据源值获取器")]
    [Description("从数据源获取值的获取器")]
    public class BindingSourceValueFetcher : PaoObject, IValueFetch
    {
        #region 插件属性

        #region 属性：FieldName
        /// <summary>
        /// 属性：FieldName
        /// 数据字段名称
        /// 数据字段名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据字段名称")]
        [Description("数据字段名称")]
        public string FieldName {
            get;
            set;
        }
        #endregion 属性：FieldName

        #endregion

        #region 属性：DataSource
        [NonSerialized]
        private BindingManagerBase _DataBinding;

        public BindingManagerBase DataBinding {
            get { return _DataBinding; }
            set { _DataBinding = value; }
        }

        public object Value {
            get {
                if (DataBinding == null || DataBinding.Position == -1 || FieldName.IsNullOrEmpty())
                    return null;

                var dataRowView = DataBinding.Current as DataRowView;
                if (dataRowView == null)
                    return null;

                return dataRowView[FieldName];
            }
        }

        #endregion 属性：DataSource

        public BindingSourceValueFetcher() {
        }
    }
}
