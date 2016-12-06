using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.UI.MVC;

namespace PAO.UI.WinForm.MDI.DockPanels
{
    /// <summary>
    /// 类：MenuCommand
    /// 菜单命令
    /// 用于向主窗体添加菜单的命令
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("菜单控制器")]
    [Description("用于向主窗体添加菜单的控制器")]
    public class MenuCommand : PaoObject, ICommand
    {
        #region 插件属性
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
        #endregion
        public MenuCommand() {
        }

        public void DoCommand() {
            if (MVCPublic.MainForm is IUIItemContainer) {
                var uiItemContainer = MVCPublic.MainForm as IUIItemContainer;
                if(MenuItems.IsNotNullOrEmpty()) {
                    foreach(var menuItem in MenuItems) {
                        uiItemContainer.OpenUIItem(menuItem.Value);
                    }
                }
            }
        }
    }
}
