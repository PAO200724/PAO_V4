using PAO;
using PAO.Data;
using PAO.Event;
using PAO.UI;
using PAO.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

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
        public ServerForm MainForm = null;

        #region 插件属性

        #region 属性：SkinName
        /// <summary>
        /// 属性：SkinName
        /// 皮肤名称
        /// 皮肤名称
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("皮肤名称")]
        [Description("皮肤名称")]
        public string SkinName {
            get;
            set;
        }
        #endregion 属性：SkinName

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
            Application.ThreadException += Application_ThreadException;
            if (SkinName.IsNotNullOrEmpty()) {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = false;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = SkinName;
                DevExpress.Skins.SkinManager.EnableFormSkins();
            }

            MainForm = new ServerForm();
            Application.Run(MainForm);
        }

        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            EventPublic.Exception(e.Exception);
        }
    }
}
