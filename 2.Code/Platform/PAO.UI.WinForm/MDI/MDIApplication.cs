using PAO;
using PAO.App;
using PAO.Trans;
using PAO.UI.WinForm.MVC;
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

        #region 属性：ExtendMenu
        /// <summary>
        /// 属性：ExtendMenuItems
        /// 扩展菜单
        /// 程序的扩展菜单
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("扩展菜单")]
        [Description("程序的扩展菜单")]
        public List<Ref<Controller>> ExtendMenuItems {
            get;
            set;
        }
        #endregion 属性：ExtendMenu

        #region 属性：AutoRunControllers
        /// <summary>
        /// 属性：AutoRunControllers
        /// 自动运行的控制器
        /// 系统启动时自动运行的控制器
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("自动运行的控制器")]
        [Description("系统启动时自动运行的控制器")]
        public List<Ref<Controller>> AutoRunControllers {
            get;
            set;
        }
        #endregion 属性：AutoRunControllers        

        #endregion
        public MDIApplication() {
        }

        private MDIMainForm MainForm;
        public override void OnPreparing() {
            MainForm = new MDIMainForm();
            MainForm.Text = Caption;
            if (ExtendMenuItems.IsNotNullOrEmpty()) {
                foreach(var extendMenuItem in ExtendMenuItems) {
                    MainForm.AddMenuItem(extendMenuItem.Value);
                }
            }

            if(AutoRunControllers.IsNotNullOrEmpty()) {
                TransactionPublic.Run("启动自动控制器", () =>
                {
                    foreach(var controller in AutoRunControllers) {
                        var ctrl = controller.Value;
                        TransactionPublic.Run(String.Format("运行自动控制器:{0}", ctrl.Caption), () =>
                        {
                            ctrl.DoCommand(MainForm);
                        });
                    }
                });
            }
        }

        public override void OnRunning() {
            Application.Run(MainForm);
        }
    }
}
