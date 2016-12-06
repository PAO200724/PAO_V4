using PAO;
using PAO.App;
using PAO.Config.Controls.EditControls;
using PAO.UI.WinForm.MDI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PAO.UI.MVC;

namespace PAO.Config.Commands
{
    /// <summary>
    /// 类：ObjectConfigController
    /// 对象配置控制器
    /// 配置对象的控制器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("对象配置控制器")]
    [Description("配置对象的控制器")]
    public class ObjectConfigCommand : CommandMenuItem
    {
        #region 插件属性
        #endregion
        public ObjectConfigCommand() {
        }

        public override void DoCommand() {
            if(MVCPublic.MainForm is IDocumentContainer) {
                var docContainer = MVCPublic.MainForm as IDocumentContainer;
                var view = new ObjectTreeEditControl();
                view.ID = ID;
                view.Caption = Caption;
                view.Icon = Icon;
                view.ExtendPropertyStorageFilePath = AppPublic.GetAbsolutePath("ExtendProperties.config");
                view.SelectedObject = PaoApplication.Default;
                docContainer.OpenDocument(view);
            }
            base.DoCommand();
        }
    }
}
