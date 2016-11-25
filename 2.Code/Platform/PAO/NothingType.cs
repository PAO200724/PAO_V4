using System;
using System.Collections.Generic;
using System.Text;

namespace PAO {
    /// <summary>
    /// 类:NothingType
    /// 空值类型
    /// 作者:PAO
    /// </summary>
    [Flags]
    public enum NothingType {
        /// <summary>
        /// 引用
        /// </summary>
        Reference = 1,
        /// <summary>
        /// Convert.DBNull
        /// </summary>
        DBNull = 2,
        /// <summary>
        /// IList类型
        /// </summary>
        List = 4,
        /// <summary>
        /// 字符串
        /// </summary>
        String = 8,
        /// <summary>
        /// 可空的类型
        /// </summary>
        Nullable = Reference | DBNull,
        /// <summary>
        /// 空类型
        /// </summary>
        Empty = List | String,
        /// <summary>
        /// 所有类型
        /// </summary>
        All = Nullable | Empty
    }
}
