namespace PAO.WinForm.Controls
{
    partial class ImageControl
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
            this.components = new System.ComponentModel.Container();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.BarTools = new DevExpress.XtraBars.Bar();
            this.ButtonFitSize = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonOriginalSize = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.PictureEdit = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BarManager
            // 
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BarTools});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonFitSize,
            this.ButtonOriginalSize,
            this.ButtonZoomOut,
            this.ButtonZoomIn,
            this.ButtonSave});
            this.BarManager.MaxItemId = 10;
            // 
            // BarTools
            // 
            this.BarTools.BarName = "工具条";
            this.BarTools.DockCol = 0;
            this.BarTools.DockRow = 0;
            this.BarTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BarTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonFitSize),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonOriginalSize),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonZoomOut, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonZoomIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonSave, true)});
            this.BarTools.Text = "工具条";
            // 
            // ButtonFitSize
            // 
            this.ButtonFitSize.Caption = "适合(&F)";
            this.ButtonFitSize.Glyph = global::PAO.WinForm.Properties.Resources.zoom2_32x32;
            this.ButtonFitSize.Id = 4;
            this.ButtonFitSize.Name = "ButtonFitSize";
            this.ButtonFitSize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonFitSize_ItemClick);
            // 
            // ButtonOriginalSize
            // 
            this.ButtonOriginalSize.Caption = "原图(&R)";
            this.ButtonOriginalSize.Glyph = global::PAO.WinForm.Properties.Resources.zoom100_32x32;
            this.ButtonOriginalSize.Id = 5;
            this.ButtonOriginalSize.Name = "ButtonOriginalSize";
            this.ButtonOriginalSize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonOriginalSize_ItemClick);
            // 
            // ButtonZoomOut
            // 
            this.ButtonZoomOut.Caption = "放大(&O)";
            this.ButtonZoomOut.Glyph = global::PAO.WinForm.Properties.Resources.zoomin_32x32;
            this.ButtonZoomOut.Id = 6;
            this.ButtonZoomOut.Name = "ButtonZoomOut";
            this.ButtonZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonZoomOut_ItemClick);
            // 
            // ButtonZoomIn
            // 
            this.ButtonZoomIn.Caption = "缩小(&I)";
            this.ButtonZoomIn.Glyph = global::PAO.WinForm.Properties.Resources.zoomout_32x32;
            this.ButtonZoomIn.Id = 7;
            this.ButtonZoomIn.Name = "ButtonZoomIn";
            this.ButtonZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonZoomIn_ItemClick);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Caption = "保存(&S)";
            this.ButtonSave.Glyph = global::PAO.WinForm.Properties.Resources.save_32x32;
            this.ButtonSave.Id = 9;
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonSave_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(667, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 537);
            this.barDockControlBottom.Size = new System.Drawing.Size(667, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 490);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(667, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 490);
            // 
            // PictureEdit
            // 
            this.PictureEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureEdit.Location = new System.Drawing.Point(0, 47);
            this.PictureEdit.MenuManager = this.BarManager;
            this.PictureEdit.Name = "PictureEdit";
            this.PictureEdit.Properties.NullText = "[无图像]";
            this.PictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.PictureEdit.Properties.ShowScrollBars = true;
            this.PictureEdit.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.PictureEdit.Size = new System.Drawing.Size(667, 490);
            this.PictureEdit.TabIndex = 4;
            // 
            // ImageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PictureEdit);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ImageControl";
            this.Size = new System.Drawing.Size(667, 537);
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar BarTools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PictureEdit PictureEdit;
        private DevExpress.XtraBars.BarButtonItem ButtonFitSize;
        private DevExpress.XtraBars.BarButtonItem ButtonOriginalSize;
        private DevExpress.XtraBars.BarButtonItem ButtonZoomOut;
        private DevExpress.XtraBars.BarButtonItem ButtonZoomIn;
        private DevExpress.XtraBars.BarButtonItem ButtonSave;
    }
}
