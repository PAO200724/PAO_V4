using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.IO;

namespace PAO.UI.WinForm.Controls
{
    public partial class ImageControl : DialogControl
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
            ShowApplyButton = false;
            ShowCancelButton = false;
        }

        [DefaultValue(false)]
        public bool ReadOnly {
            get {
                return PictureEdit.Properties.ReadOnly;
            }

            set {
                PictureEdit.Properties.ReadOnly = value;
            }
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
                StretchScreenShot();
                SetControlStatus();
            }
        }

        private void StretchScreenShot() {
            var image = PictureEdit.Image;
            if (image != null) {
                var horzZoomPercent = (double)PictureEdit.ClientRectangle.Width / image.Width;
                var vertZoomPercent = (double)PictureEdit.ClientRectangle.Height / image.Height;
                PictureEdit.Properties.ZoomPercent = Math.Min(horzZoomPercent, vertZoomPercent) * 98f;
            }
        }

        private void ButtonFitSize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            StretchScreenShot();
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
        
        private void ButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            string fileName = "*.png";
            if(UIPublic.ShowSaveFileDialog("保存图片", ref fileName
                , FileExtentions.PNG
                , FileExtentions.JPG
                , FileExtentions.BMP
                , FileExtentions.All) == DialogResult.OK) {
                PictureEdit.Image.Save(fileName);
            }
        }
    }
}
