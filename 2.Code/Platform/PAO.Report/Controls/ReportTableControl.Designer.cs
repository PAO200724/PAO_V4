namespace PAO.Report.Controls
{
    partial class ReportTableControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProgressBarControlFetch = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.ButtonEditTableRowCount = new DevExpress.XtraEditors.ButtonEdit();
            this.LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.LayoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl)).BeginInit();
            this.GroupControl.SuspendLayout();
            this.TableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarControlFetch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditTableRowCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupControl
            // 
            this.GroupControl.AutoSize = true;
            this.GroupControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GroupControl.Controls.Add(this.TableLayoutPanel);
            this.GroupControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl.Location = new System.Drawing.Point(0, 0);
            this.GroupControl.Name = "GroupControl";
            this.GroupControl.Size = new System.Drawing.Size(513, 125);
            this.GroupControl.TabIndex = 0;
            this.GroupControl.Text = "表名";
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.AutoSize = true;
            this.TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel.ColumnCount = 1;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Controls.Add(this.ProgressBarControlFetch, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.ButtonEditTableRowCount, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.LayoutControl, 0, 1);
            this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel.Location = new System.Drawing.Point(2, 21);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 3;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.Size = new System.Drawing.Size(509, 102);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // ProgressBarControlFetch
            // 
            this.ProgressBarControlFetch.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProgressBarControlFetch.EditValue = 0;
            this.ProgressBarControlFetch.Location = new System.Drawing.Point(3, 81);
            this.ProgressBarControlFetch.Name = "ProgressBarControlFetch";
            this.ProgressBarControlFetch.Size = new System.Drawing.Size(503, 18);
            this.ProgressBarControlFetch.TabIndex = 1;
            // 
            // ButtonEditTableRowCount
            // 
            this.ButtonEditTableRowCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonEditTableRowCount.Location = new System.Drawing.Point(3, 3);
            this.ButtonEditTableRowCount.Name = "ButtonEditTableRowCount";
            this.ButtonEditTableRowCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::PAO.Report.Properties.Resources.doublenext_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::PAO.Report.Properties.Resources.last_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.ButtonEditTableRowCount.Size = new System.Drawing.Size(503, 22);
            this.ButtonEditTableRowCount.TabIndex = 2;
            // 
            // LayoutControl
            // 
            this.LayoutControl.AutoSize = true;
            this.LayoutControl.Controls.Add(this.textBox1);
            this.LayoutControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.LayoutControl.Location = new System.Drawing.Point(3, 31);
            this.LayoutControl.Name = "LayoutControl";
            this.LayoutControl.Root = this.LayoutControlGroupRoot;
            this.LayoutControl.Size = new System.Drawing.Size(503, 44);
            this.LayoutControl.TabIndex = 3;
            this.LayoutControl.Text = "布局控件";
            // 
            // LayoutControlGroupRoot
            // 
            this.LayoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroupRoot.GroupBordersVisible = false;
            this.LayoutControlGroupRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.LayoutControlGroupRoot.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlGroupRoot.Name = "LayoutControlGroupRoot";
            this.LayoutControlGroupRoot.Size = new System.Drawing.Size(503, 44);
            this.LayoutControlGroupRoot.Text = "根";
            this.LayoutControlGroupRoot.TextVisible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(371, 20);
            this.textBox1.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textBox1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(483, 24);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(105, 14);
            // 
            // ReportTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.GroupControl);
            this.Name = "ReportTableControl";
            this.Size = new System.Drawing.Size(513, 129);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl)).EndInit();
            this.GroupControl.ResumeLayout(false);
            this.GroupControl.PerformLayout();
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarControlFetch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonEditTableRowCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GroupControl;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private DevExpress.XtraEditors.MarqueeProgressBarControl ProgressBarControlFetch;
        private DevExpress.XtraEditors.ButtonEdit ButtonEditTableRowCount;
        private DevExpress.XtraLayout.LayoutControl LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroupRoot;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
