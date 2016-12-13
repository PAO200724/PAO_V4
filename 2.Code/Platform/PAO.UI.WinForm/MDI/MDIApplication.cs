﻿using DevExpress.Skins;
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
using PAO.Time;
using DevExpress.XtraSplashScreen;

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
        /// 控制器列表
        /// 系统中的视图控制器列表
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("控制器列表")]
        [Description("系统中的视图控制器列表")]
        public List<Ref<BaseController>> Controllers {
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

        #region 属性：MenuItems
        /// <summary>
        /// 属性：MenuItems
        /// 功能菜单
        /// 功能菜单项
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("功能菜单")]
        [Description("功能菜单项")]
        public List<Ref<UIItem>> MenuItems {
            get;
            set;
        }
        #endregion 属性：MenuItems

        #region 属性：DateTimeService
        /// <summary>
        /// 属性：DateTimeService
        /// 日期时间服务
        /// 日期时间服务
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("日期时间服务")]
        [Description("日期时间服务")]
        public Ref<IDateTime> DateTimeService {
            get;
            set;
        }
        #endregion 属性：DateTimeService

        #endregion
        public MDIApplication() {
        }
        public static new MDIApplication Default {
            get {
                return PaoApplication.Default as MDIApplication;
            }
        }
        public MDIMainForm MainForm = null;
        public override void OnPreparing() {
            UIPublic.DefaultUserInterface = new WinFormUI();
        }

        public bool Login() {
            SecurityPublic.ApplicationUser = null;
            SecurityPublic.ThreadUser = null;

            var loginControl = new LoginControl();
            loginControl.SecurtiyService = SecurityService.Value;
            if (WinFormPublic.ShowDialog(loginControl) == DialogReturn.OK) {
                return true;
            }

            return false;
        }
        
        public override void OnRunning() {
            if (SkinName.IsNotNullOrEmpty()) { 
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = false;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = false;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = SkinName;
                DevExpress.Skins.SkinManager.EnableFormSkins();
            }

            if (!Login())
                return;

            MainForm = new MDIMainForm();
            MVCPublic.MainForm = MainForm;
            MainForm.Initialize(this);
            Application.Run(MainForm);
        }
    }
}
