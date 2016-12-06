using PAO;
using PAO.App;
using PAO.Trans;
using PAO.UI.MVC;
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

        #endregion
        public MDIApplication() {
        }

        MDIMainForm MainForm = null;
        public override void OnPreparing() {
            UIPublic.DefaultUserInterface = new WinFormUI();
            MainForm = new MDIMainForm();
            MVCPublic.MainForm = MainForm;
            MainForm.Text = Caption;

            if(Commands.IsNotNullOrEmpty()) {
                TransactionPublic.Run("启动自动控制器", () =>
                {
                    foreach(var controller in Commands) {
                        var ctrl = controller.Value;
                        TransactionPublic.Run(String.Format("运行自动控制器:{0}", ctrl), () =>
                        {
                            ctrl.DoCommand();
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
