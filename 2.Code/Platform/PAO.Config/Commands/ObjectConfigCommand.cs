using PAO;
using PAO.App;
using PAO.Config.Controls.EditControls;
using PAO.UI.WinForm.MDI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO.UI.MVC;
using PAO.IO.Text;

namespace PAO.Config.Commands
{
    /// <summary>
    /// 类：ObjectConfigController
    /// 对象配置控制器
    /// 配置对象的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("对象配置控制器")]
    [Description("配置对象的控制器")]
    public class ObjectConfigCommand : BaseController
    {
        #region 插件属性

        #region 属性：ConfigFile
        /// <summary>
        /// 属性：ConfigFile
        /// 配置文件
        /// 配置文件路径
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("配置文件")]
        [Description("配置文件路径")]
        public string ConfigFile {
            get;
            set;
        }
        #endregion 属性：ConfigFile


        #region 属性：ExtendPropertyConfigFile
        /// <summary>
        /// 属性：ExtendPropertyConfigFile
        /// 扩展属性配置文件
        /// 扩展属性配置文件路径
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("扩展属性配置文件")]
        [Description("扩展属性配置文件路径")]
        public string ExtendPropertyConfigFile {
            get;
            set;
        }
        #endregion 属性：ExtendPropertyConfigFile
        #endregion
        public ObjectConfigCommand() {
        }

        const string DefaultExtendPropertyConfigFile = "ExtendProperties.config";
        protected override void OnDoCommand() {
            var view = new ObjectTreeEditControl();
            view.FromUIItem(this);

            if (ExtendPropertyConfigFile.IsNullOrEmpty()) {
                view.ExtendPropertyStorageFilePath = AppPublic.GetAbsolutePath(DefaultExtendPropertyConfigFile);
            }
            else {
                view.ExtendPropertyStorageFilePath = AppPublic.GetAbsolutePath(ExtendPropertyConfigFile);
            }
            object addon;
            if (ConfigFile.IsNullOrEmpty()) {
                addon = PaoApplication.Default;
            }
            else {
                addon = TextPublic.ReadObjectFromFile(ConfigFile);
            }
            view.SelectedObject = addon;
            MVCPublic.MainForm.OpenView(view);
        }
    }
}
