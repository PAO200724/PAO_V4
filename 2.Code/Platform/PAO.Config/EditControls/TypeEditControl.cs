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
    public partial class TypeEditControl : BaseEditControl
    {
        public TypeEditControl() {
            InitializeComponent();
        }

        private Type _PropertyType;

        /// <summary>
        /// 属性类型
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Type PropertyType {
            get { return _PropertyType; }
            set {
                _PropertyType = value;
                SetControlStatus();
            }
        }

        public override bool Newable {
            get {
                if (PropertyType == null)
                    return false;

                return base.Newable;
            }
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            ObjectCreateMethod = CreateObjectByType;
        }

        protected virtual object CreateObjectByType() {
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
