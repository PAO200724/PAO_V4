using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO;
using PAO.Security;
using PAO.Properties;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 类：BaseController
    /// 控制器
    /// 视图控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Icon(typeof(Resources), "controller")]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("控制器")]
    [Description("视图控制器")]
    public abstract class BaseController : UIItem
    {
        const string Permission_DoCommand = "DoCommand";
        #region 插件属性

        #region 属性：Surface
        /// <summary>
        /// 属性：Surface
        /// 外观
        /// 视图的外观样式
        /// </summary>
        [AddonProperty]
        [DataMember(EmitDefaultValue = false)]
        [Name("外观")]
        [Description("视图的外观样式")]
        public Surface Surface {
            get;
            set;
        }
        #endregion 属性：Surface

        #endregion
        public BaseController() {
        }

        /// <summary>
        /// 创建并打开视图
        /// </summary>
        /// <param name="viewContainer">视图容器</param>
        public virtual IView CreateAndOpenView(IViewContainer viewContainer) {
            SecurityPublic.CheckPermission(ID, Permission_DoCommand).CheckTrue("当前用户不拥有执行此命令的权限.");

            var View = ViewType.CreateInstance() as IView;
            if (View == null)
                throw new Exception("视图创建失败.");

            View.ID = ID;
            View.Caption = Caption;
            View.Icon = Icon;
            View.LargeIcon = LargeIcon;
            View.ViewContainer = viewContainer;
            View.Controller = this;

            viewContainer.OpenView(View);
            return View;
        }

        protected abstract Type ViewType {
            get; 
        }
        
        /// <summary>
        /// 许可
        /// </summary>
        [Browsable(false)]
        public virtual IDictionary<string, string> Permissions {
            get {
                return new Dictionary<string, string>()
                    .Append(Permission_DoCommand, "执行命令");
            }
        }
    }
}
