using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PAO.Drawing
{
    /// <summary>
    /// 静态类：DrawingPublic
    /// 绘图公共类
    /// 作者：PAO
    /// </summary>
    public static class DrawingPublic
    {
        /// <summary>
        /// 截屏
        /// </summary>
        /// <returns>屏幕截屏</returns>
        public static Image ScreenShot(Screen screen) {
            Bitmap bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bitmap)) {
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bitmap.Size);
            }

            return bitmap;
        }

        /// <summary>
        /// 截屏（主屏幕）
        /// </summary>
        /// <returns>主屏幕图片</returns>
        public static Image ScreenShot() {
            return ScreenShot(Screen.PrimaryScreen);
        }
    }
}
