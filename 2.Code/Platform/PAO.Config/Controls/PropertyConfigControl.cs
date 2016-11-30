using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.Config.Controls
{
    /// <summary>
    /// 属性配置控件
    /// </summary>
    public partial class PropertyConfigControl : DevExpress.XtraEditors.XtraUserControl
    {
        public PropertyConfigControl() {
            InitializeComponent();
        }

        private object _PropertyValue;
        /// <summary>
        /// 属性值
        /// </summary>
        public object PropertyValue {
            get { return _PropertyValue; }
            set { _PropertyValue = value; }
        }

        private PropertyDescriptor _Property;
        /// <summary>
        /// 属性描述
        /// </summary>
        public PropertyDescriptor Property {
            get { return _Property; }
            set { _Property = value; }
        }

        private object _Object;
        /// <summary>
        /// 对象
        /// </summary>
        public object Object {
            get { return _Object; }
            set { _Object = value; }
        }

        private void ButtonCreateInstance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }

        private void ButtonClearInstance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }
    }
}
