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
using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using PAO.UI;
using System.Collections;
using PAO.Data;
using PAOData = PAO.Data;
using SysData = System.Data;
using DevExpress.Utils.Menu;
using PAO.Config;
using PAO.Config.Editor;

namespace PAO.Report.Controls
{
    /// <summary>
    /// 对象布局式编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class DataParametersEditControl : BaseObjectEditControl
    {
        internal DataParametersEditControl() {
            InitializeComponent();
            this.DataLayoutControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        /// <summary>
        /// 编辑控件列表
        /// </summary>
        private Dictionary<string, Control> EditControls = new Dictionary<string, Control>();
        /// <summary>
        /// 数据列
        /// </summary>
        private IEnumerable<DataParameter> DataParameters;
        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DataTable;

        public override bool AutoSize {
            get {
                return base.AutoSize;
            }

            set {
                base.AutoSize = value;
                this.DataLayoutControl.AutoSize = value;
            }
        }

        public override DockStyle Dock {
            get {
                return base.Dock;   
            }

            set {
                base.Dock = value;
                this.DataLayoutControl.Dock = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue {
            get {
                // 从SchemaTable中获取值
                this.BindingSource.EndEdit();
                foreach (var dataColumn in DataParameters) {
                    dynamic editControl = EditControls[dataColumn.Name];
                    if (editControl != null) {
                        dataColumn.Value = editControl.EditValue;
                    }
                }
                return DataParameters; 
            }

            set {
                var valueString = "[未设置对象]";
                DataParameters = value as IEnumerable<DataParameter>;

                if (!DataParameters.IsNull()) {
                    valueString = value.ToString();
                    DataTable = DataPublic.GetTableByDataItems(DataParameters);
                }
                else {
                    DataTable = null;
                }

                Text = String.Format("属性: {0}", valueString);

                DataTable.Clear();
                this.BindingSource.DataSource = DataTable;
                if (DataParameters != null) {
                    this.BindingSource.DataSource = DataTable;
                    this.BindingSource.AddNew();
                }
                RetrieveFields(this.LayoutControlGroupRoot);
            }
        }

        public void EndEdit() {
            this.BindingSource.EndEdit();
        }

        protected override void OnClose() {
            var controller = Controller as DataParametersEditController;
            controller.LayoutData = this.DataLayoutControl.GetLayoutData();
            base.OnClose();
        }


        /// <summary> 
        /// 根据对象填充属性字段
        /// </summary>
        /// <param name="groupItem">组项目</param>
        /// <param name="objType">对象类型</param>
        private void RetrieveFields(LayoutControlGroup groupItem) {
            this.DataLayoutControl.CloseControl();
            this.DataLayoutControl.SuspendLayout();
            EditControls.Clear();
            this.DataLayoutControl.Clear(true, true);
            var controller = Controller as DataParametersEditController;

            if (DataParameters == null)
                return;

            foreach (var dataParameter in DataParameters) {
                Control editControl = CreateEditControl(dataParameter);

                LayoutControlItem layoutControlItem = null;
                layoutControlItem = groupItem.AddItem();
                layoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;

                layoutControlItem.Control = editControl;
                var parameterName = DataPublic.GetParameterName(dataParameter.Name);
                layoutControlItem.Name = parameterName;
                layoutControlItem.Text = parameterName;
                layoutControlItem.CustomizationFormText = dataParameter.Name;

                if (editControl is BaseObjectEditControl) {
                    layoutControlItem.TextVisible = false;
                }
                else {
                    layoutControlItem.TextVisible = true;
                }
            }
            this.DataLayoutControl.Refresh();
            this.DataLayoutControl.SetDefaultLayout();

            /// 读取布局数据
            if (controller.LayoutData.IsNotNull()) {
                this.DataLayoutControl.SetLayoutData(controller.LayoutData);
            }
            this.DataLayoutControl.ResumeLayout();
        }

        /// <summary>
        /// 设置LayoutItemDataField
        /// </summary>
        /// <param name="layoutControlItem">LayoutControlItem</param>
        /// <param name="dataParameter">数据字段</param>
        private Control CreateEditControl(DataParameter dataParameter) {
            var controller = Controller as DataParametersEditController;
            Control editControl = null;
            if (controller != null) {
                var editController = controller.GetPredefinedEditController(dataParameter.ObjectType, dataParameter.Name);
                if (editController != null) {
                    editControl = editController.CreateEditControl(dataParameter.ObjectType);
                }
            }

            if (editControl == null) {
                editControl = EditorPublic.CreateEditControl(dataParameter.ObjectType);
            }
            if (editControl == null) {
                var editController = new CommonObjectEditController();
                editController.StartEditObject(dataParameter.ObjectType);
                editControl = editController.CreateEditControl(dataParameter.ObjectType);
            }

            if (editControl.GetType().GetProperty("EditValue") == null)
                throw new Exception("编辑控件必须实现EditValue属性");

            editControl.Tag = dataParameter;
            editControl.Name = dataParameter.Name;
            dynamic dynamicControl = editControl;
            if (dataParameter.ValueFetcher.IsNotNull()) {
                editControl.DataBindings.Add(new Binding("EditValue", dataParameter.ValueFetcher, "Value", true));
                dynamicControl.Enabled = false;
            }
            else {
                if (this.BindingSource != null) {
                    editControl.DataBindings.Add(new Binding("EditValue", this.BindingSource, dataParameter.Name, true));
                }
            }
            EditControls.Add(dataParameter.Name, editControl);

            return editControl;
        }

        private void DataLayoutControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e) {
            if(e.HitInfo.Item != null) {
                var controller = Controller as DataParametersEditController;
                if (controller == null)
                    return;

                var layoutItem = e.HitInfo.Item as LayoutControlItem;
                if (layoutItem == null)
                    return;

                var editControl = layoutItem.Control;
                var dataField = editControl.Tag as DataParameter;

                if (dataField != null) {

                    // 修改字段标题
                    var menuChangeCaption = new DXEditMenuItem("标题(&C)"
                        , new TextEditController().CreateRepositoryItem(typeof(string)));
                    menuChangeCaption.Width = 100;
                    menuChangeCaption.EditValue = layoutItem.Text;
                    menuChangeCaption.BeginGroup = true;
                    menuChangeCaption.EditValueChanged += (s, a) =>
                    {
                        if (menuChangeCaption.EditValue.IsNull())
                            layoutItem.Text = dataField.Name;
                        else
                            layoutItem.Text = (string)menuChangeCaption.EditValue;
                    };
                    menuChangeCaption.BeginGroup = true;
                    e.Menu.Items.Add(menuChangeCaption);

                    // 修改字段类型
                    var menuChangeDbType = new DXEditMenuItem("类型(&T)"
                        , new EnumEditController().CreateRepositoryItem(typeof(DbType)));
                    menuChangeDbType.Width = 100;
                    menuChangeDbType.EditValue = dataField.DbType;
                    menuChangeDbType.EditValueChanged += (s, a) =>
                    {
                        if (menuChangeDbType.EditValue.IsNull())
                            dataField.DbType = DbType.String;
                        else
                            dataField.DbType = (DbType)menuChangeDbType.EditValue;
                        EditValue = EditValue;
                    };
                    e.Menu.Items.Add(menuChangeDbType);
                    
                    // 增加更改编辑器菜单
                    var menuChangeEditor = new DXMenuItem("更改编辑器(&E)..."
                        , (s, a) => {
                            Type editControllerType;
                            if (EditorPublic.SelectEditControllerType(dataField.ObjectType, out editControllerType) == DialogReturn.OK) {
                                if (editControllerType != null) {
                                    var editController = editControllerType.CreateInstance() as BaseEditController;
                                    // 清除前保存配置
                                    controller.LayoutData = this.DataLayoutControl.GetLayoutData();
                                    controller.SetPredfinedEditController(dataField.Name, editController.GetType());
                                    EditValue = EditValue;
                                }
                            }
                        }
                        , Properties.Resources.renamedatasource_16x16);
                    menuChangeEditor.BeginGroup = true;
                    e.Menu.Items.Add(menuChangeEditor);

                    // 增加恢复编辑器菜单
                    var menuRecoverEditor = new DXMenuItem("恢复编辑器(&R)"
                        , (s, a) => {
                            if (UIPublic.ShowYesNoDialog("您确定要恢复默认的编辑器吗？") == DialogReturn.Yes) {
                                // 清除前保存配置
                                controller.LayoutData = this.DataLayoutControl.GetLayoutData();
                                controller.RemovePredefinedEditController(dataField.Name);
                                EditValue = EditValue;
                            }
                        }
                        , Properties.Resources.clearformatting_16x16);
                    e.Menu.Items.Add(menuRecoverEditor);

                    // 增加恢复编辑器菜单
                    var menuEditField = new DXMenuItem("字段属性(&P)..."
                        , (s, a) => {
                            EditorPublic.ShowObjectLayoutEditControl(dataField);
                            EditValue = EditValue;
                        });
                    menuEditField.BeginGroup = true;
                    e.Menu.Items.Add(menuEditField);
                }

                // 恢复所有编辑器
                var menuClearEditors = new DXMenuItem("恢复所有编辑器(&C)"
                    , (s, a) => {
                        if (UIPublic.ShowYesNoDialog("您确定要恢复所有默认的编辑器吗？") == DialogReturn.Yes) {
                            // 清除前保存配置
                            controller.LayoutData = this.DataLayoutControl.GetLayoutData();
                            controller.ClearPredefinedEditControllers();
                            EditValue = EditValue;
                        }
                    }
                    , Properties.Resources.clear_16x16);
                menuClearEditors.BeginGroup = true;
                e.Menu.Items.Add(menuClearEditors);

            }
        }
    }
}
