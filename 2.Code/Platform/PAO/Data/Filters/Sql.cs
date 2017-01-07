using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace PAO.Data.Filters
{
    /// <summary>
    /// Sql语句过滤器
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    /// <remarks>
    /// 通过Sql语句生成过滤字符串
    /// </remarks>
    [DataContract(Namespace = "")]
    [Serializable]
    [Name("Sql语句过滤器")]
    [Description("通过Sql语句生成过滤字符串")]
    public class Sql : DataFilter
    {
        #region 插件属性
        #region 属性:Sql
        /// <summary>
        /// 属性:Filter
        /// Sql语句
        /// 用于过滤语法的Sql语句
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue=false)]
        [Name("Sql语句")]
        [Description("用于过滤语法的Sql语句")]
        public string Filter {
            get;
            set;
        }
        #endregion 属性:Sql
        #endregion
        /// <summary>
        /// 构造方法
        /// </summary>
        public Sql() {
        }

        public Sql( string sql) {
            Filter = sql;
        }

        public override string GetFilterString(DataParameter[] paramValues, bool ignoreNullValue) {
            if (ignoreNullValue && paramValues == null)
                return null;

            var parameters = GetParameters();

            if (ignoreNullValue 
                && !paramValues.Any(p => (parameters.Any(q=>q.Name == p.Name) && p.Value.IsNotNullOrEmpty())))
                return null;

            return Filter;
        }

        private DataField[] GetParameters() {
            if (Filter.IsNull())
                return null;

            List<DataField> dataFields = new List<Data.DataField>();
            var parameters = DataPublic.FindParameters(Filter);
            foreach(var parameter in parameters) {
                var dataField = new DataField(parameter);
                dataFields.Add(dataField);
            }
            return dataFields.ToArray();
        }

        #region IDataFilter 成员
        
        #endregion
      
    }
}
