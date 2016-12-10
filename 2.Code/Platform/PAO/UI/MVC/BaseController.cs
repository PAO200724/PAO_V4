using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.Security;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 类：BaseController
    /// 基础控制器
    /// 可以执行命令的菜单项
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("基础控制器")]
    [Description("可以执行命令的菜单项")]
    public abstract class BaseController : UIItem
    {
        const string Permission_DoCommand = "DoCommand";
        #region 插件属性
        #endregion
        public BaseController() {
        }

        protected IView View;
        /// <summary>
        /// 创建并打开视图
        /// </summary>
        /// <param name="viewContainer">视图容器</param>
        public virtual void CreateAndOpenView(IViewContainer viewContainer) {
            SecurityPublic.CheckPermission(ID, Permission_DoCommand).CheckTrue("当前用户不拥有执行此命令的权限.");

            View = OnCreateView();
            if (View == null)
                throw new Exception("视图创建失败.");

            View.ID = ID;
            View.Caption = Caption;
            View.Icon = Icon;
            View.LargeIcon = LargeIcon;

            viewContainer.OpenView(View);
        }

        protected abstract IView OnCreateView();
        
        /// <summary>
        /// 许可
        /// </summary>
        public virtual IDictionary<string, string> Permissions {
            get {
                return new Dictionary<string, string>()
                    .Append(Permission_DoCommand, "执行命令");
            }
        }
    }
}
