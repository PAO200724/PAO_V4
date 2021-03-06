﻿using PAO.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Data.Filters
{
    /// <summary>
    /// 基础数据过滤器
    /// 作者:刘丹(Daniel.liu)
    /// </summary>
    /// <remarks>
    /// 数据过滤器基类，过滤器是用于生成Sql中的Where子句的，有过滤器的Sql语句写成: SELECT * FROM [TABLE_NAME] WHERE {0}
    /// </remarks>
    [DataContract(Namespace="")]
    [Icon(typeof(Resources), "filter")]
    [Serializable]
    [Name("基础数据过滤器")]
    [Description("数据过滤器基类，过滤器是用于生成Sql中的Where子句的，有过滤器的Sql语句写成: SELECT * FROM [TABLE_NAME] WHERE {0}")]
    [EditorType("PAO.Config.Editor.DataFilterEditController")]
    public abstract class DataFilter : PaoObject
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public DataFilter() {
        }


        #region IDataFilter 成员

        public abstract string GetFilterString(DataParameter[] paramValues, bool ignoreNullValue);
        
        #endregion

        /// <summary>
        /// 逻辑Anad
        /// </summary>
        /// <param name="dataFilter1">查询条件1</param>
        /// <param name="dataFilter2">查询条件2</param>
        /// <returns>组合条件</returns>
        public static And operator &(DataFilter dataFilter1, DataFilter dataFilter2) {
            if(dataFilter1 is And) {
                var and = dataFilter1 as And;
                and.ChildFilters.Append(dataFilter2);
                return and;
            }
            return new And() { ChildFilters = new List<DataFilter>().Append(dataFilter1).Append(dataFilter2) };
        }

        /// <summary>s
        /// 逻辑Anad
        /// </summary>
        /// <param name="dataFilter1">查询条件1</param>
        /// <param name="dataFilter2">查询条件2</param>
        /// <returns>组合条件</returns>
        public static Or operator |(DataFilter dataFilter1, DataFilter dataFilter2) {
            if (dataFilter1 is Or) {
                var or = dataFilter1 as Or;
                or.ChildFilters.Append(dataFilter2);
                return or;
            }
            return new Or() { ChildFilters = new List<DataFilter>().Append(dataFilter1).Append(dataFilter2) };
        }
    }
}
