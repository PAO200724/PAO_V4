using PAO;
using PAO.UI.MVC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.App.MDI.DockViews
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
    public class TreeMenuController : BaseController
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
        public TreeMenuController() {
        }
        protected override Type ViewType {
            get {
                return typeof(TreeMenuView);
            }
        }
    }
}
