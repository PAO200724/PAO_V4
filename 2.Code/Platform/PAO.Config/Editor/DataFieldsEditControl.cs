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
using PAO.WinForm.Editor;
using PAO.UI;
using System.Collections;
using PAO.Data;
using PAOData = PAO.Data;
using SysData = System.Data;
using DevExpress.Utils.Menu;

namespace PAO.Config.Editor
{
    /// <summary>
    /// 对象布局式编辑控件
    /// 作者：PAO
    /// </summary>
    public partial class DataFieldsEditControl : BaseObjectEditControl
    {
        internal DataFieldsEditControl() {
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
        private IEnumerable<PAOData.DataField> DataFields;
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
                foreach(var dataColumn in DataFields) {
                    dynamic editControl = EditControls[dataColumn.Name];
                    if(editControl != null) {
                        dataColumn.Value = editControl.EditValue;
                    }
                }
                return DataFields; 
            }

            set {
                var valueString = "[未设置对象]";
                DataFields = value as IEnumerable<PAOData.DataField>;

                if (!DataFields.IsNull()) {
                    valueString = value.ToString();
                    DataTable = DataPublic.GetTableByFields(DataFields);
                } else {
                    DataTable = null;
                }

                Text = String.Format("属性: {0}", valueString);

                DataTable.Clear();
                this.BindingSource.DataSource = DataTable;
                if (DataFields != null) {
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
            var controller = Controller as DataFieldsEditController;
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
            EditControls.Clear();
            this.DataLayoutControl.Clear(true, true);
            var controller = Controller as DataFieldsEditController;

            if (DataFields == null)
                return;

            foreach (var dataField in DataFields) {
                Control editControl = null;
                if (controller != null) {
                    var editController = controller.GetPredefinedEditController(dataField.ObjectType, dataField.Name);
                    if(editController != null) {
                        editControl = editController.CreateEditControl(dataField.ObjectType);
                    }
                }

                if(editControl == null) {
                    editControl = ConfigPublic.CreateEditControl(dataField.ObjectType);
                }
                if (editControl == null) {
                    var editController = new CommonObjectEditController();
                    editController.StartEditObject(dataField.ObjectType);
                    editControl = editController.CreateEditControl(dataField.ObjectType);
                }

                if (editControl.GetType().GetProperty("EditValue") == null)
                    throw new Exception("编辑控件必须实现EditValue属性");

                LayoutControlItem layoutControlItem = null;
                layoutControlItem = groupItem.AddItem();
                layoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;

                EditControls.Add(dataField.Name, editControl);

                editControl.Tag = dataField;
                editControl.Name = dataField.Name;

                dynamic dynamicControl = editControl;
                if(dataField.ValueFetcher.IsNotNull()){
                    editControl.DataBindings.Add(new Binding("EditValue", dataField.ValueFetcher.Value, "Value", true));
                    dynamicControl.Enabled = false;
                } else {
                    if (this.BindingSource != null) {
                        editControl.DataBindings.Add(new Binding("EditValue", this.BindingSource, dataField.Name, true));
                    }
                }

                layoutControlItem.Control = editControl;
                layoutControlItem.Name = dataField.Name;
                layoutControlItem.Text = dataField.Name;
                layoutControlItem.CustomizationFormText = dataField.Name;

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
        }

        private void DataLayoutControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e) {
            if(e.HitInfo.Item != null) {
                var controller = Controller as DataFieldsEditController;
                if (controller == null)
                    return;

                var layoutItem = e.HitInfo.Item as LayoutControlItem;
                var editControl = layoutItem.Control;
                var dataField = editControl.Tag as DataField;

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
                    };
                    e.Menu.Items.Add(menuChangeDbType);

                    // 增加更改编辑器菜单
                    var menuChangeEditor = new DXMenuItem("更改编辑器(&E)..."
                        , (s, a) => {
                            Type editControllerType;
                            if (ConfigPublic.SelectEditControllerType(dataField.ObjectType, out editControllerType) == DialogReturn.OK) {
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
