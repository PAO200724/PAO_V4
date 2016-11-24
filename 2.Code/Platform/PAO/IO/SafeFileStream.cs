using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace PAO.IO {
    /// <summary>
    /// 安全文件流
    /// 此文件流会在创建时自动创建一个临时文件，对文件的读写实际上都是对临时文件进行，关闭文件时将临时文件回写
    /// 作者：刘丹(Daniel.liu)
    /// </summary>
    public class SafeFileStream : FileStream {
        private string Path;
        private bool CreateTemp;
        private static bool IsWrite(FileMode mode, FileAccess access) {
            if (mode == FileMode.Open)
                return false;

            switch (access) {
                case FileAccess.Read:
                    return false;
                default:
                    return true;
            }
        }

        private static string GetTempFilePath(string path) {
            return path + "~";
        }

        private static string GetPath(FileMode mode, FileAccess access, string path) {
            if(!IsWrite(mode, access))
                return path;
            var tempPath = GetTempFilePath(path);

            if (File.Exists(path))
                File.Copy(path, tempPath, true);

            return tempPath;
        }

        [SecuritySafeCritical]
        public SafeFileStream(string path, FileMode mode)
            : base(GetPath(mode, FileAccess.ReadWrite, path), mode) {
            Path = path;
            CreateTemp = IsWrite(mode, FileAccess.ReadWrite);
        }

        [SecuritySafeCritical]
        public SafeFileStream(string path, FileMode mode, FileAccess access)
            : base(GetPath(mode,access,path), mode, access) {
            Path = path;
            CreateTemp = IsWrite(mode, FileAccess.ReadWrite);
        }

        [SecuritySafeCritical]
        public SafeFileStream(string path, FileMode mode, FileAccess access, FileShare share)
            : base(GetPath(mode,access,path), mode, access, share) {
            Path = path;
            CreateTemp = IsWrite(mode, FileAccess.ReadWrite);
        }
 
        [SecuritySafeCritical]
        public SafeFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
            : base(GetPath(mode,access,path), mode, access, share, bufferSize) {
            Path = path;
            CreateTemp = IsWrite(mode, FileAccess.ReadWrite);
        }

        [SecuritySafeCritical]
        public SafeFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync)
            : base(GetPath(mode,access,path), mode, access, share, bufferSize, useAsync) {
            Path = path;
            CreateTemp = IsWrite(mode, FileAccess.ReadWrite);
        }
 
        [SecuritySafeCritical]
        public SafeFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options)
            : base(GetPath(mode,access,path), mode, access, share, bufferSize, options) {
            Path = path;
            CreateTemp = IsWrite(mode, FileAccess.ReadWrite);
        }

        public override void Close() {
            base.Close(); 
            if (this.CreateTemp) {
                var tempPath = GetTempFilePath(Path);
                File.Copy(tempPath, Path, true);
                File.Delete(tempPath);
            }
        }
    }
}
