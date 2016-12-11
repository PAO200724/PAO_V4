﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.WinForm.Controls;
using PAO.UI.MVC;
using PAO.App;
using PAO.IO.Text;

namespace PAO.Config.Views
{
    /// <summary>
    /// 对象配置视图
    /// 作者：PAO
    /// </summary>
    public partial class ObjectConfigView : ViewControl
    {
        public ObjectConfigView() {
            InitializeComponent();
        }

        protected override void OnSetController(BaseController value) {
            var controller = value as ObjectConfigController;
            if (controller.ExtendPropertyConfigFile.IsNullOrEmpty()) {
                this.ObjectTreeEditControl.ExtendPropertyStorageFilePath = AppPublic.GetAbsolutePath(ObjectConfigController.DefaultExtendPropertyConfigFile);
            }
            else {
                this.ObjectTreeEditControl.ExtendPropertyStorageFilePath = AppPublic.GetAbsolutePath(controller.ExtendPropertyConfigFile);
            }
            object addon;
            if (controller.ConfigFile.IsNullOrEmpty()) {
                addon = PaoApplication.Default;
            }
            else {
                addon = TextPublic.ReadObjectFromFile(controller.ConfigFile);
            }
            ObjectTreeEditControl.SelectedObject = addon;
        }
    }
}