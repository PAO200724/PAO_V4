using PAO;
using PAO.UI.WinForm.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.UI.WinForm.MDI.DockPanels
{
    /// <summary>
    /// 类：MenuController
    /// 树形菜单控制器
    /// 树型菜单控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("树形菜单控制器")]
    [Description("树型菜单控制器")]
    public class TreeMenuController : Controller
    {
        #region 插件属性


        #region 属性：DockPanelID
        /// <summary>
        /// 属性：DockPanelID
        /// DockPanelID
        /// DockPanelID
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("DockPanelID")]
        [Description("DockPanelID")]
        public Guid DockPanelID {
            get;
            set;
        }
        #endregion 属性：DockPanelID

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
        public List<Ref<Controller>> MenuItems {
            get;
            set;
        }
        #endregion 属性：MenuItems
        #endregion
        public TreeMenuController() {
        }

        public override void DoCommand(IMainForm mainForm) {
            var treeMenuView = new TreeMenuView();
            if(MenuItems.IsNotNullOrEmpty()) {
                treeMenuView.Initialize(mainForm, MenuItems.Select(p=>p.Value));
            }
            mainForm.ShowDockPanel(DockPanelID, treeMenuView, DevExpress.XtraBars.Docking.DockingStyle.Right, Caption, Icon);
        }
    }
}
