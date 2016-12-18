using PAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DevExpress.XtraEditors.Repository;
using PAO.WinForm;

namespace PAO.WinForm.Editors
{
    /// <summary>
    /// 类：CalcEditor
    /// 计算器式数字编辑器
    /// 计算器式数字编辑器
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Serializable]
    [DataContract(Namespace = "")]
    [Name("计算器式数字编辑器")]
    [Description("计算器式数字编辑器")]
    public class CalcEditor : BaseEditor
    {
        #region 插件属性
        #endregion
        public CalcEditor() {
        }

        protected override RepositoryItem OnCreateRepositoryItem() {
            var edit = new RepositoryItemCalcEdit();
            WinFormPublic.AddClearButton(edit);
            return edit;
        }
    }
}
