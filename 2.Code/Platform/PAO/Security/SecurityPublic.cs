using PAO.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PAO.Security
{
    /// <summary>
    /// 静态类：SecurityPublic
    /// 安全公共类
    /// 作者：PAO
    /// </summary>
    public static class SecurityPublic
    {
        /// <summary>
        /// 当前应用系统用户
        /// </summary>
        public static UserToken ApplicationUser;
        /// <summary>
        /// 当前线程用户
        /// </summary>
        [ThreadStatic]
        public static UserToken ThreadUser;

        /// <summary>
        /// 当前用户，如果线程用户存在，则试用线程用户，否则使用应用系统用户
        /// </summary>
        public static UserToken CurrentUser {
            get {
                if(!ThreadUser.IsNull()) {
                    return ThreadUser;
                }
                return ApplicationUser;
            }

        }

        #region 哈希(Hash)
        /// <summary>
        /// 默认Hash算法
        /// </summary>
        public static HashAlgorithm DefaultHashAlgorithm = MD5.Create();

        /// <summary>
        /// 计算Hash文本值
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns>二进制字符串</returns>
        public static string ComputeHashString(String text) {
            if (text.IsNullOrEmpty())
                return null;

            return Convert.ToBase64String(ComputeHash(text));
        }

        /// <summary>
        /// 计算Hash值
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns>二进制数组</returns>
        public static byte[] ComputeHash(String text) {
            if (text.IsNullOrEmpty())
                return null;

            return ComputeHash(IOPublic.DefaultEncoding.GetBytes(text));
        }

        /// <summary>
        /// 计算Hash值
        /// </summary>
        /// <param name="stream">流</param>
        /// <returns>二进制数组</returns>
        public static byte[] ComputeHash(byte[] binary) {
            if (binary.IsNullOrEmpty())
                return null;

            return DefaultHashAlgorithm.ComputeHash(binary);
        }

        /// <summary>
        /// 计算Hash值
        /// </summary>
        /// <param name="stream">流</param>
        /// <returns>Hash值</returns>
        public static byte[] ComputeHash(Stream stream) {
            return DefaultHashAlgorithm.ComputeHash(stream);
        }
        #endregion 哈希(Hash)

        /// <summary>
        /// 检查权限
        /// </summary>
        /// <param name="commandID">命令ID</param>
        /// <param name="permission">许可</param>
        /// <returns>当前用户是否拥有某个权限</returns>
        public static bool CheckPermission(string commandID, string permission) {
            return true;
        }
    }
}
