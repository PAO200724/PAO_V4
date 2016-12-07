using DevExpress.Skins;
using PAO;
using PAO.App;
using PAO.Security;
using PAO.Trans;
using PAO.UI.MVC;
using PAO.UI.WinForm.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace PAO.UI.WinForm.MDI
{
    /// <summary>
    /// 类：MDIApplication
    /// MDI应用主程序
    /// 多文档类型的应用主程序
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("MDI应用主程序")]
    [Description("多文档类型的应用主程序")]
    public class MDIApplication : PaoApplication
    {
        #region 插件属性

        #region 属性：Caption
        /// <summary>
        /// 属性：Caption
        /// 应用程序标题
        /// 主窗体标题
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("应用程序标题")]
        [Description("主窗体标题")]
        public string Caption {
            get;
            set;
        }
        #endregion 属性：Caption

        #region 属性：Controllers
        /// <summary>
        /// 属性：Controllers
        /// 命令列表
        /// 系统启动时自动运行的命令列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("命令列表")]
        [Description("系统启动时自动运行的命令列表")]
        public List<Ref<ICommand>> Commands {
            get;
            set;
        }
        #endregion 属性：Controllers        

        #region 属性：LayoutData
        /// <summary>
        /// 属性：LayoutData
        /// 布局数据
        /// 布局数据
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("布局数据")]
        [Description("布局数据")]
        public byte[] LayoutData {
            get;
            set;
        }
        #endregion 属性：LayoutData

        #region 属性：SecurityService
        /// <summary>
        /// 属性：SecurityService
        /// 安全服务
        /// 提供用户登录以及获取用户信息等的服务
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("用户服务")]
        [Description("提供用户登录以及获取用户信息等的服务")]
        public Ref<ISecurity> SecurityService {
            get;
            set;
        }
        #endregion 属性：SecurityService

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

        #endregion
        public MDIApplication() {
        }
        public static new MDIApplication Default {
            get {
                return PaoApplication.Default as MDIApplication;
            }
        }
        MDIMainForm MainForm = null;
        public override void OnPreparing() {
            UIPublic.DefaultUserInterface = new WinFormUI();
        }

        public override void OnRunning() {
            if (SkinName.IsNotNullOrEmpty()) { 
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = false;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = SkinName;
                DevExpress.Skins.SkinManager.EnableFormSkins();
            }
            var loginControl = new LoginControl();
            loginControl.SecurtiyService = SecurityService.Value;
            if (WinFormPublic.ShowDialog(loginControl) != DialogReturn.OK) {
                return;
            }

            MainForm = new MDIMainForm();
            MVCPublic.MainForm = MainForm;
            MainForm.Text = Caption;

            if (Commands.IsNotNullOrEmpty()) {
                TransactionPublic.Run("启动自动控制器", () =>
                {
                    foreach (var command in Commands) {
                        var ctrl = command.Value;
                        TransactionPublic.Run(String.Format("运行自动控制器:{0}", ctrl), () =>
                        {
                            ctrl.DoCommand(MVCPublic.MainForm);
                        });
                    }
                });
            }

            Application.Run(MainForm);
        }
    }
}
