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
    public class SqlFilter : DataField, IDataFilter
    {
        #region 插件属性
        #region 属性:Sql
        /// <summary>
        /// 属性:Sql
        /// Sql语句
        /// 用于过滤语法的Sql语句
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue=false)]
        [Name("Sql语句")]
        [Description("用于过滤语法的Sql语句")]
        public string Sql {
            get;
            set;
        }
        #endregion 属性:Sql
        #endregion
        /// <summary>
        /// 构造方法
        /// </summary>
        public SqlFilter() {
        }

        public SqlFilter( string sql, string paramterName, DbType parameterType= DbType.String) {
            Name = paramterName;
            Type = parameterType;
            Sql = sql;
        }

        public virtual string GetFilterString(DataField[] paramValues) {
            if (paramValues == null)
                return null;

            if (!paramValues.Any(p => (p.Name == Name && p.Value != null)))
                return null;

            return Sql;
        }

        public virtual DataField[] GetParameters() {
            return new DataField[] { this };
        }

        #region IDataFilter 成员
        
        #endregion

        /// <summary>
        /// 逻辑Anad
        /// </summary>
        /// <param name="dataFilter1">查询条件1</param>
        /// <param name="dataFilter2">查询条件2</param>
        /// <returns>组合条件</returns>
        public static AndLogicFilter operator &(SqlFilter dataFilter1, IDataFilter dataFilter2) {
            return new AndLogicFilter() { ChildFilters = new List<IDataFilter>().Append(dataFilter1).Append(dataFilter2) };
        }

        /// <summary>s
        /// 逻辑Anad
        /// </summary>
        /// <param name="dataFilter1">查询条件1</param>
        /// <param name="dataFilter2">查询条件2</param>
        /// <returns>组合条件</returns>
        public static OrLogicFilter operator |(SqlFilter dataFilter1, IDataFilter dataFilter2) {
            return new OrLogicFilter() { ChildFilters = new List<IDataFilter>().Append(dataFilter1).Append(dataFilter2) };
        }
    }
}
