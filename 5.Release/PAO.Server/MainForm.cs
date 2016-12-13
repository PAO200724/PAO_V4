using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.Server
{
    public partial class MainForm : Form
    {
        public MainForm() {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }
        
        protected override void OnSizeChanged(EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
            }
            base.OnSizeChanged(e);
        }

        protected override void OnClosing(CancelEventArgs e) {
            if(DialogResult != DialogResult.OK) {
                e.Cancel = true;
                this.Hide();
            }
            base.OnClosing(e);
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void ButtonExit_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
