using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Part
{
    /// <summary>
    /// 类:BaseStatus
    /// 状态
    /// 状态基类
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("状态")]
    [Description("状态基类")]
    public abstract class Status : Object
    {
        private static Dictionary<Type, Status> DefaultStatusList = new Dictionary<Type, Status>();

        /// <summary>
        /// 获取默认状态对象
        /// </summary>
        /// <typeparam name="T">状态类型</typeparam>
        /// <returns>默认状态对象</returns>
        public static T Default<T>() where T : Status, new() {
            if(DefaultStatusList.ContainsKey(typeof(T))) {
                return (T)DefaultStatusList[typeof(T)];
            } else {
                T status = new T();
                DefaultStatusList.Add(typeof(T), status);
                return status;
            }
        }

        public Status()
        {
        }

        public override string ToString()
        {
            return this.GetType().GetAttribute<DisplayNameAttribute>(false).DisplayName;
        }
    }
}
