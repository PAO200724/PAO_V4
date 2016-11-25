using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PAO.Remote{
    /// <summary>
    /// 类：WCFFactory
    /// WCF工厂
    /// 通过WCF方式创建对象的工厂
    /// 作者：PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [DisplayName("WCF工厂")]
    [Description("通过WCF方式创建对象的工厂")]
    public class WCFFactory<T> : Factory<T> {
        #region 插件属性
        #region 属性：Url
        /// <summary>
        /// 属性：Url
        /// Url
        /// WCF服务地址
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [DisplayName("Url")]
        [Description("WCF服务地址")]
        public string Url {
            get;
            set;
        }
        #endregion 属性：Url
        #endregion

        public WCFFactory() {

        }

        public override string ToString() {
            return ObjectPublic.ObjectToString(this, null, "Url");
        }

        protected override T OnCreateInstance() {
            var factory = new ChannelFactory<T>();
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(Url);
            factory.Endpoint.Binding = binding;
            return factory.CreateChannel(address);
        }
    }
}
