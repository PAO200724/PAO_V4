using PAO.IO.Text;
using PAO.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAO.IO
{
    /// <summary>
    /// 静态类：IOPublic
    /// IO公共类
    /// 作者：PAO
    /// </summary>
    public static class IOPublic
    {
        /// <summary>
        /// 默认编码
        /// </summary>
        public static Encoding DefaultEncoding = Encoding.UTF8;


        /// <summary>
        /// 导出当前对象
        /// </summary>
        public static void ExportObject(object obj) {
            string fileName = null;
            if (UIPublic.ShowSaveFileDialog("导出", ref fileName
                , FileExtentions.CONFIG
                , FileExtentions.XML
                , FileExtentions.All) == DialogReturn.OK) {
                if (fileName.IsNullOrEmpty())
                    UIPublic.ShowErrorDialog("输入了错误的文件名");
                else {
                    TextPublic.WriteObjectToFile(fileName, obj);
                }
            }
        }

        /// <summary>
        /// 导入对象
        /// </summary>
        public static void ImportObject(Action<object> action) {
            string fileName = null;
            if (UIPublic.ShowOpenFileDialog("导入", ref fileName
                , FileExtentions.CONFIG
                , FileExtentions.XML
                , FileExtentions.All) == DialogReturn.OK) {
                if (!File.Exists(fileName))
                    UIPublic.ShowErrorDialog("选择的文件不存在");
                else {
                    var obj = TextPublic.ReadObjectFromFile(fileName);
                    try {
                        action(obj);
                    }
                    catch (Exception err) {
                        UIPublic.ShowErrorDialog(err.Message);
                    }
                }
            }
        }
    }
}
