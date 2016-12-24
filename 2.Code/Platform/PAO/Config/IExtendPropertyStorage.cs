using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.Config
{
    /// <summary>
    /// 接口：IExtendPropertyStorage
    /// 扩展属性存储
    /// 扩展属性存储器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("扩展属性存储")]
    [Description("扩展属性存储器")]
    public interface IExtendPropertyStorage
    {
        /// <summary>
        /// 加载扩展属性
        /// </summary>
        /// <param name="dataTable">数据表</param>
        void LoadExtendProperties(DataSetExtendProperty.ExtendPropertyDataTable dataTable);
        /// <summary>
        /// 保存扩展属性
        /// </summary>
        /// <param name="dataTable">数据表</param>
        void SaveExtendProperties(DataSetExtendProperty.ExtendPropertyDataTable dataTable);
    }
}
