using PAO.Event;
using PAO.IO.Serializers;
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

        #region BackupFile
        /// <summary>
        /// 获取备份文件路径
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>备份文件路径</returns>
        public static string GetBackupFilePath(string path) {
            var dirName = Path.GetDirectoryName(path);
            var fileName = Path.GetFileName(path);
            return Path.Combine(dirName, DateTime.Now.ToString("yyyy-MM-dd.hh-mm-ss.ffff") + "." + fileName);
        }

        /// <summary>
        /// 移动到备份文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>备份文件路径</returns>
        public static string MoveToBackupFile(string path) {
            if (path.IsNullOrEmpty())
                return null;

            if (File.Exists(path))
                return null;

            var backupFilePath = GetBackupFilePath(path);

            File.Move(path, backupFilePath);
            return backupFilePath;
        }

        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>备份文件路径</returns>
        public static string BackupFile(string path) {
            if (path.IsNullOrEmpty())
                return null;

            if (File.Exists(path))
                return null;

            var backupFilePath = GetBackupFilePath(path);

            File.Copy(path, backupFilePath, true);
            return backupFilePath;
        }
        #endregion
        #region Export/Import
        /// <summary>
        /// 导出当前对象
        /// </summary>
        public static void ExportObject(object obj
            , string defaultFileName = null
            , params string[] defaultFileExtentions) {
            string fileName = defaultFileName;
            string[] fileExtentions;
            if (defaultFileExtentions.IsNotNullOrEmpty()) {
                fileExtentions = defaultFileExtentions;
            } else {
                fileExtentions = new string[]
                {
                    FileExtentions.CONFIG
                    , FileExtentions.XML
                    , FileExtentions.All
                };
            }
            if (UIPublic.ShowSaveFileDialog("导出", ref fileName
                , fileExtentions) == DialogReturn.OK) {
                if (fileName.IsNullOrEmpty())
                    UIPublic.ShowErrorDialog("输入了错误的文件名");
                else {
                    IOPublic.WriteObjectToFile(fileName, obj);
                }
            }
        }

        /// <summary>
        /// 导入对象
        /// </summary>
        public static void ImportObject(Action<object> action
            , string defaultFileName = null
            , params string[] defaultFileExtentions) {
            string fileName = defaultFileName;
            string[] fileExtentions;
            if (defaultFileExtentions.IsNotNullOrEmpty()) {
                fileExtentions = defaultFileExtentions;
            }
            else {
                fileExtentions = new string[]
                {
                    FileExtentions.CONFIG
                    , FileExtentions.XML
                    , FileExtentions.All
                };
            }
            if (UIPublic.ShowOpenFileDialog("导入", ref fileName
                , fileExtentions) == DialogReturn.OK) {
                if (!File.Exists(fileName))
                    UIPublic.ShowErrorDialog("选择的文件不存在");
                else {
                    var obj = IOPublic.ReadObjectFromFile(fileName);
                    try {
                        action(obj);
                    }
                    catch (Exception err) {
                        UIPublic.ShowErrorDialog(err.Message);
                    }
                }
            }
        }
        #endregion

        #region 序列化(Serialize)
        public static ISerialize DefaultSerializer = new XmlSerializer();

        /// <summary>
        /// 将文本转换为对象
        /// </summary>
        /// <param name="text">文本字符串</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public static object Deserialize<T>(T text) {
            if (!(DefaultSerializer is ISerialize<T>))
                throw new Exception("默认的序列化器不支持此类型的反序列化").AddExceptionData("Type",typeof(T));
            return DefaultSerializer.As<ISerialize<T>>().Deserialize(text);
        }

        /// <summary>
        /// 将对象转换为文本
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>文本字符串</returns>
        public static T Serialize<T>(object obj) {
            if (!(DefaultSerializer is ISerialize<T>))
                throw new Exception("默认的序列化器不支持此类型的序列化").AddExceptionData("Type", typeof(T));
            return DefaultSerializer.As<ISerialize<T>>().Serialize(obj);
        }

        /// <summary>
        /// 将对象以Xml的方式写入流
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="obj">对象</param>
        /// <param name="types">需要用到的对象类型</param>
        public static void WriteObjectToStream(Stream stream, object obj) {
            DefaultSerializer.WriteObjectToStream(stream, obj);
        }

        /// <summary>
        /// 保存对象到文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="obj">对象</param>
        public static void WriteObjectToFile(string fileName, object obj) {
            using (SafeFileStream fileStream = new SafeFileStream(fileName, FileMode.Create, FileAccess.Write)) {
                WriteObjectToStream(fileStream, obj);
            }
        }
        /// <summary>
        /// 从Xml流中读取对象
        /// </summary>
        /// <param name="stream">Xml字符流</param>
        /// <param name="types">需要用到的对象类型</param>
        /// <returns>对象</returns>
        public static object ReadObjectFromStream(Stream stream) {
            return DefaultSerializer.ReadObjectFromStream(stream);
        }

        /// <summary>
        /// 从文件读取对象
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <return>对象</return>
        public static object ReadObjectFromFile(string fileName) {
            if (!File.Exists(fileName))
                return null;

            using (SafeFileStream fileStream = new SafeFileStream(fileName, FileMode.Open, FileAccess.Read)) {
                object obj = ReadObjectFromStream(fileStream);
                return obj;
            }
        }
        /// <summary>
        /// 通过Xml克隆对象
        /// </summary>
        /// <param name="sourceObject">源对象</param>
        /// <returns>克隆后的对象</returns>
        public static object ObjectClone(this object sourceObject) {
            if (sourceObject == null)
                return null;
            using (MemoryStream buffer = new MemoryStream()) {
                WriteObjectToStream(buffer, sourceObject);
                buffer.Seek(0, SeekOrigin.Begin);
                return ReadObjectFromStream(buffer);
            }
        }
        #endregion
    }
}
