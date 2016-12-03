using PAO;
using PAO.App;
using PAO.Remote.WCF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Remote.WCF
{
    /// <summary>
    /// 类：WebApplication
    /// Web应用程序
    /// Web应用程序
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("Web应用程序")]
    [Description("Web应用程序")]
    public class WCFRemoteApplication : PaoApplication
    {
        #region 插件属性

        #region 属性：ServiceList
        /// <summary>
        /// 属性：ServiceList
        /// 服务列表
        /// 远程服务列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("服务列表")]
        [Description("远程服务列表")]
        public Dictionary<string, Ref<PaoObject>> ServiceList {
            get;
            set;
        }
        #endregion

        #endregion
        public WCFRemoteApplication() {
            OnStart = OnAppliationStart;
        }

        private void OnAppliationStart() {
            WCFRemoteService.ServiceList = ServiceList;
        }
    }
}
