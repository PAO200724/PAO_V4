﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.WinForm.Controls;
using PAO.WinForm;
using PAO.MVC;

namespace PAO.Config.DockViews
{
    /// <summary>
    /// 属性页视图
    /// 作者：PAO
    /// </summary>
    public partial class PropertyView : ViewControl, IDockView, IPropertyView
    {
        /// <summary>
        /// 默认视图
        /// </summary>
        public PropertyView() {
            InitializeComponent();
            WinFormPublic.DefaultPropertyView = this;
        }

        public object SelectedObject {
            get {
                return ObjectEditControl.EditValue;
            }

            set {
                ObjectEditControl.EditValue = value;
            }
        }
        
    }
}
