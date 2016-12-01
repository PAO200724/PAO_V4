using PAO;
using PAO.IO.Text;
using PAO.Remote.WCF;
using PAO.Trans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Remote.WCF
{
    /// <summary>
    /// 类：RemoteFactory
    /// 远程工厂
    /// 通过远程调用创建的工厂
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("远程工厂")]
    [Description("通过远程调用创建的工厂")]
    public class WCFRemoteFactory<T> : Factory<T>
    {
        #region 插件属性

        #region 属性：BaseUrl
        /// <summary>
        /// 属性：BaseUrl
        /// 地址
        /// 服务基础地址
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("地址")]
        [Description("服务基础地址")]
        public string BaseUrl {
            get;
            set;
        }
        #endregion 属性：BaseUrl

        #region 属性：ServiceName
        /// <summary>
        /// 属性：ServieName
        /// 服务名称
        /// 服务对应的名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("服务名称")]
        [Description("服务对应的名称")]
        public string ServiceName {
            get;
            set;
        }
        #endregion 属性：ServiceName

        #endregion
        public WCFRemoteFactory() {
        }
        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null, "BaseUrl", "ServiceName");
        }
        protected override T OnCreateInstance() {
            T result = default(T);
            TransactionPublic.Run("", () =>
            {
                var remoteService = new WCFFactory<IRemoteService>
                {
                    Url = BaseUrl
                };
                var proxy = new RemoteProxy(typeof(T), remoteService.Value, RemotePublic.DefaultSerializer, ServiceName);
                result = (T)proxy.GetTransparentProxy();
            });
            return result;
        }
    }
}
