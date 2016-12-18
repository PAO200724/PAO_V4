using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm;

namespace PAO.Config.EditControls
{
    /// <summary>
    /// 对属性进行编辑的控件
    /// 作者：PAO
    /// </summary>
    public partial class AddonTypeEditControl : BaseEditControl
    {
        public AddonTypeEditControl() {
            InitializeComponent();
        }
        
        protected override object OnCreateNewObject() {
            PropertyType.CheckNotNull("创建新对象前必须设置PropertyType");
            object newObject;
            if (ConfigPublic.CreateNewAddonValue(PropertyType
                , false
                , out newObject)) {
                return newObject;
            }

            return null;
        }
    }
}
