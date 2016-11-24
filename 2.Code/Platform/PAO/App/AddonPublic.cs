using PAO.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PAO.App {
    /// <summary>
    /// 静态类：AddonPublic
    /// 插件公共类
    /// 作者：PAO
    /// </summary>
    public static class AddonPublic {
        const string AssemblyPattern = "PAO.*.dll";

        /// <summary>
        /// 程序集过滤器
        /// </summary>
        public static Func<Assembly, bool> AssemblyFilter = (p) =>
        {
            return p.FullName.StartsWith("PAO");
        };

        /// <summary>
        /// 添加文件的元件集到插件类型列表
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="includeSubDir">是否包含子目录，默认为True</param>
        public static Assembly AddFile(string file) {
            // 此处不能使用LoadFrom，因为KF.Base冲突
            LogPublic.LogInformation("开始加载插件文件:{0}", file);
            try {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(file);
                var assembly = AppDomain.CurrentDomain.Load(assemblyName);
                LogPublic.LogInformation("插件文件加载完毕:{0}", file);
                return assembly;
            } catch (Exception err) {
                // 加载文件时记录异常，不报错
                LogPublic.LogException(err);
                return null;
            }
        }

        /// <summary>
        /// 添加目录中的元件集到插件类型列表
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="includeSubDir">是否包含子目录，默认为True</param>
        public static void AddDirectory(string dir, bool includeSubDir = true) {
            LogPublic.LogInformation("开始加载插件目录:{0}", dir);
            var files = Directory.GetFiles(dir, AssemblyPattern, includeSubDir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (var file in files) {
                AddFile(file);
            }
            LogPublic.LogInformation("插件目录加载完毕:{0}", dir);
        }
    }
}
