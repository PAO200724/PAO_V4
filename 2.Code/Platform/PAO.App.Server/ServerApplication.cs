using PAO;
using PAO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.App.Server
{
    /// <summary>
    /// 类：ServerApplication
    /// 服务应用
    /// 服务应用
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("服务应用")]
    [Description("服务应用")]
    public class ServerApplication : PaoApplication
    {
        #region 插件属性
        #region 属性：DataService
        /// <summary>
        /// 属性：DataService
        /// 数据服务
        /// 数据服务
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("数据服务")]
        [Description("数据服务")]
        public Ref<IDataService> DataService {
            get;
            set;
        }
        #endregion 属性：DataService
        #endregion

        public static new ServerApplication Default {
            get {
                return PaoApplication.Default as ServerApplication;
            }
        }

        public ServerApplication() {
        }

        public override void OnRunning() {
            base.OnRunning();
        }
    }
}
