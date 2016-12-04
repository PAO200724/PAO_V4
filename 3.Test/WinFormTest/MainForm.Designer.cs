namespace WinFormTest
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.BarManager = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.MenuEventTest = new DevExpress.XtraBars.BarSubItem();
            this.ButtonTestInformation = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonTestException = new DevExpress.XtraBars.BarButtonItem();
            this.MenuConfigTest = new DevExpress.XtraBars.BarSubItem();
            this.ButtonConfigTools = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonAddonSelect = new DevExpress.XtraBars.BarButtonItem();
            this.MenuRemoteTest = new DevExpress.XtraBars.BarSubItem();
            this.ButtonCallRemote = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonRemoteException = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.DefaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // BarManager
            // 
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonTestInformation,
            this.MenuEventTest,
            this.ButtonTestException,
            this.MenuConfigTest,
            this.ButtonConfigTools,
            this.ButtonAddonSelect,
            this.MenuRemoteTest,
            this.ButtonCallRemote,
            this.ButtonRemoteException});
            this.BarManager.MaxItemId = 9;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuEventTest),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuConfigTest),
            new DevExpress.XtraBars.LinkPersistInfo(this.MenuRemoteTest)});
            this.bar1.Text = "Tools";
            // 
            // MenuEventTest
            // 
            this.MenuEventTest.Caption = "事件测试";
            this.MenuEventTest.Id = 1;
            this.MenuEventTest.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonTestInformation),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonTestException)});
            this.MenuEventTest.Name = "MenuEventTest";
            // 
            // ButtonTestInformation
            // 
            this.ButtonTestInformation.Caption = "消息";
            this.ButtonTestInformation.Id = 0;
            this.ButtonTestInformation.Name = "ButtonTestInformation";
            this.ButtonTestInformation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonTestInformation_ItemClick);
            // 
            // ButtonTestException
            // 
            this.ButtonTestException.Caption = "异常";
            this.ButtonTestException.Id = 2;
            this.ButtonTestException.Name = "ButtonTestException";
            this.ButtonTestException.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonTestException_ItemClick);
            // 
            // MenuConfigTest
            // 
            this.MenuConfigTest.Caption = "配置测试";
            this.MenuConfigTest.Id = 3;
            this.MenuConfigTest.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonConfigTools),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonAddonSelect)});
            this.MenuConfigTest.Name = "MenuConfigTest";
            // 
            // ButtonConfigTools
            // 
            this.ButtonConfigTools.Caption = "配置工具";
            this.ButtonConfigTools.Id = 4;
            this.ButtonConfigTools.Name = "ButtonConfigTools";
            this.ButtonConfigTools.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonConfigTools_ItemClick);
            // 
            // ButtonAddonSelect
            // 
            this.ButtonAddonSelect.Caption = "插件选择";
            this.ButtonAddonSelect.Id = 5;
            this.ButtonAddonSelect.Name = "ButtonAddonSelect";
            this.ButtonAddonSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonAddonSelect_ItemClick);
            // 
            // MenuRemoteTest
            // 
            this.MenuRemoteTest.Caption = "远程测试(&R)";
            this.MenuRemoteTest.Id = 6;
            this.MenuRemoteTest.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonCallRemote),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonRemoteException)});
            this.MenuRemoteTest.Name = "MenuRemoteTest";
            // 
            // ButtonCallRemote
            // 
            this.ButtonCallRemote.Caption = "调用远程服务";
            this.ButtonCallRemote.Id = 7;
            this.ButtonCallRemote.Name = "ButtonCallRemote";
            this.ButtonCallRemote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonCallRemote_ItemClick);
            // 
            // ButtonRemoteException
            // 
            this.ButtonRemoteException.Caption = "调用异常";
            this.ButtonRemoteException.Id = 8;
            this.ButtonRemoteException.Name = "ButtonRemoteException";
            this.ButtonRemoteException.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonRemoteException_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1028, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 671);
            this.barDockControlBottom.Size = new System.Drawing.Size(1028, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 642);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1028, 29);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 642);
            // 
            // DefaultLookAndFeel
            // 
            this.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 671);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MainForm";
            this.Text = "测试窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager BarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ButtonTestInformation;
        private DevExpress.XtraBars.BarSubItem MenuEventTest;
        private DevExpress.XtraBars.BarButtonItem ButtonTestException;
        private DevExpress.LookAndFeel.DefaultLookAndFeel DefaultLookAndFeel;
        private DevExpress.XtraBars.BarSubItem MenuConfigTest;
        private DevExpress.XtraBars.BarButtonItem ButtonConfigTools;
        private DevExpress.XtraBars.BarButtonItem ButtonAddonSelect;
        private DevExpress.XtraBars.BarSubItem MenuRemoteTest;
        private DevExpress.XtraBars.BarButtonItem ButtonCallRemote;
        private DevExpress.XtraBars.BarButtonItem ButtonRemoteException;
    }
}

