using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace PAO.Data
{
    /// <summary>
    /// 类：DataCommandInfo
    /// 数据命令信息
    /// 用于保存数据命令属性的对象
    /// 作者：刘丹(Daniel.liu)
    /// </summary>
    [DataContract(Namespace = "")]
	[Serializable]
    [DisplayName("数据命令信息")]
    [Description("用于保存数据命令属性的对象")]
    public class DataCommandInfo : PaoObject
    {
        #region 插件属性

        #region 属性：Name
        /// <summary>
        /// 属性：Name
        /// 名称
        /// 数据命令名称
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("名称")]
        [Description("数据命令名称")]
        public string Name {
            get;
            set;
        }
        #endregion 属性：Name

        #region 属性：Sql
        /// <summary>
        /// 属性：Sql
        /// SQL语句
        /// 数据查询语句
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("SQL语句")]
        [Description("数据查询语句")]
        public string Sql {
            get;
            set;
        }
        #endregion 属性：Sql

        #region 属性：DataFilter
        /// <summary>
        /// 属性：DataFilter
        /// 数据过滤器
        /// 用于过滤数据的过滤器
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("数据过滤器")]
        [Description("用于过滤数据的过滤器")]
        public IDataFilter DataFilter {
            get;
            set;
        }
        #endregion 属性：DataFilter

        #endregion

        const string TrueFilter = "1=1";
        /// <summary>
        /// 构造方法
        /// </summary>
        public DataCommandInfo() {
        }

        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "Name");
        }

        public virtual string GetCommandText(params DataField[] parameterList) {
            string filterString;
            if (DataFilter == null) {
                return Sql;
            }

            filterString = DataFilter.GetFilterString(parameterList);
            if (filterString.IsNullOrEmpty())
                filterString = TrueFilter;
            
            return String.Format(Sql, filterString);
        }

        public virtual DataField[] GetParameters() {
            if (DataFilter == null)
                return new DataField[0];
            return DataFilter.GetParameters();
        }

    }
}
