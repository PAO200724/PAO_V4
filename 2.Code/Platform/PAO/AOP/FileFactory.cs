using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO.IO;
using PAO.Properties;

namespace PAO {
    /// <summary>
    /// 类:FileFactory
    /// 文件工厂
    /// 从配置文件创建对象的工厂
    /// 作者:PAO
    /// </summary>
    [Serializable]
    [Icon(typeof(Resources), "file_factory")]
    [DataContract(Namespace = "")]
    [Name("文件工厂")]
    [Description("从配置文件创建对象的工厂")]
    public class FileFactory<T> : Factory<T> {
        #region 插件属性
        #region 属性:FilePath
        /// <summary>
        /// 属性:FilePath
        /// 文件路径
        /// 保存对象配置的文件路径
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("文件路径")]
        [Description("保存对象配置的文件路径")]
        public string FilePath {
            get;
            set;
        }
        #endregion 属性:FilePath
        #endregion
        public FileFactory() {
        }
        public override string ToString() {
            // 将对象转换为字符串
            return ObjectPublic.ObjectToString(this, null, "FilePath");
        }
        protected override T OnCreateInstance() {
            return IOPublic.ReadObjectFromFile(FilePath).As<T>();
        }
    }
}
