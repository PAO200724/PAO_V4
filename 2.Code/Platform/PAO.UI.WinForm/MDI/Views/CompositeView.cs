using System;
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

namespace PAO.UI.WinForm.MDI.Views
{
    /// <summary>
    /// 组合视图
    /// 作者：PAO
    /// </summary>
    public partial class CompositeView : DialogControl, IView, IViewContainer
    {
        /// <summary>
        /// 数据格式
        /// </summary>
        private DataSet SchemaDataSet;

        public CompositeView() {
            InitializeComponent();
        }

        public void Initialize(DataSet schemaDataSet) {
            SchemaDataSet = schemaDataSet;
        }

        public void OpenView(IView view) {
            var control = view as Control;

            var group = LayoutControlGroupRoot.AddGroup();
            group.Name = String.Format("{0}_Group", ID);
            group.Text = Caption;
            group.CaptionImage = Icon;
            group.CustomizationFormText = Caption;

            var layoutControlItem = group.AddItem();
            layoutControlItem.Name = ID;
            layoutControlItem.Text = Caption;
            layoutControlItem.Image = Icon;
            layoutControlItem.CustomizationFormText = Caption;
            layoutControlItem.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItem.TextVisible = false;
        }
    }
}
