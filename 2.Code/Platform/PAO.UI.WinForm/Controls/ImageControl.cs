using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PAO.UI.WinForm.Controls
{
    public partial class ImageControl : DevExpress.XtraEditors.XtraUserControl
    {
        [DefaultValue(50f)]
        public double MinZoomPercent { get; set; }
        [DefaultValue(100f)]
        public double MaxZoomPercent { get; set; }
        public ImageControl() {
            InitializeComponent();
            MinZoomPercent = 50f;
            MaxZoomPercent = 200f;
            SetControlStatus();
        }


        private void SetControlStatus() {
            var imageNull = (Image == null);
            this.ButtonFitSize.Enabled = !imageNull;
            this.ButtonOriginalSize.Enabled = !imageNull;
            this.ButtonZoomIn.Enabled = !imageNull && (MinZoomPercent<0 || PictureEdit.Properties.ZoomPercent > MinZoomPercent);
            this.ButtonZoomOut.Enabled = !imageNull && (MaxZoomPercent<0 || PictureEdit.Properties.ZoomPercent < MaxZoomPercent);
            this.ButtonFitSize.Enabled = !imageNull;
        }

        public Image Image {
            get { return PictureEdit.Image; }
            set { PictureEdit.Image = value;
                SetControlStatus();
            }
        }


        private void ButtonFitSize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var image = PictureEdit.Image;
            if(image != null) {
                var horzZoomPercent = (double)PictureEdit.ClientRectangle.Width / image.Width;
                var vertZoomPercent = (double)PictureEdit.ClientRectangle.Height / image.Height;
                PictureEdit.Properties.ZoomPercent = Math.Min(horzZoomPercent, vertZoomPercent) * 98f;
            }

            SetControlStatus();
        }

        private void ButtonOriginalSize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            PictureEdit.Properties.ZoomPercent = 100f;

            SetControlStatus();
        }

        private void ButtonZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (MaxZoomPercent < 0 || PictureEdit.Properties.ZoomPercent < MaxZoomPercent)
                PictureEdit.Properties.ZoomPercent *= 1.2f;

            SetControlStatus();
        }

        private void ButtonZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (MinZoomPercent < 0 || PictureEdit.Properties.ZoomPercent > MinZoomPercent)
                PictureEdit.Properties.ZoomPercent *= 0.8f;

            SetControlStatus();
        }

        private void ButtonTakePicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            // TODO: PAO, 此处实现拍照功能
        }

        private void ButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            // TODO: PAO, 此处实现保存功能
        }
    }
}
