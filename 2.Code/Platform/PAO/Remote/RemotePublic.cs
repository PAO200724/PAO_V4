using PAO;
using PAO.IO;
using PAO.IO.Serializers;
using PAO.Security;
using PAO.Trans;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace PAO.Remote
{
    /// <summary>
    /// 静态类：RemotePublic
    /// 远程公共类
    /// 作者：PAO
    /// </summary>
    public static class RemotePublic
    {
        /// <summary>
        /// 表示成功的字符串（用于返回参数）
        /// </summary>
        public const string SuccessString = "Success";
        /// <summary>
        /// 表示失败的字符串（用于返回参数）
        /// </summary>
        public const string FailedString = "Failed";

        #region 序列化
        /// <summary>
        /// 默认的序列化器
        /// </summary>
        private static ISerialize<byte[]> DefaultSerializer = new IO.Serializers.XmlSerializer();

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">原始对象类型</typeparam>
        /// <param name="binary">二进制数据</param>
        /// <returns>原始对象</returns>
        public static T Deserialize<T>(byte[] binary) {
            return (T)DefaultSerializer.Deserialize(binary);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">原始对象类型</typeparam>
        /// <param name="origionObject">原始对象</param>
        /// <returns>二进制数据</returns>
        public static byte[] Serialize<T>(T origionObject) {
            return DefaultSerializer.Serialize(origionObject);
        }
        #endregion

        #region 调用服务
        /// <summary>
        /// 调用服务方法
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="functionName">方法名称</param>
        /// <param name="header">协议头</param>
        /// <param name="inputParameters">输入参数</param>
        /// <returns></returns>
        public static byte[] CallService(Dictionary<string, Ref<PaoObject>> serviceList, byte[] serviceName, byte[] functionName, byte[] header, byte[] inputParameters) {
            // 获取头信息
            Header head = null;
            header.CheckNotNullOrEmpty("协议头读取错误!");

            head = Deserialize<Header>(header);

            // 设置线程用户
            SecurityPublic.ThreadUser = head.UserToken;
            // 获取服务对象
            var serviceNameString = Deserialize<string>(serviceName);
            var functionNameString = Deserialize<string>(functionName);

            byte[] result = null;
            Action callService = () =>
            {
                if (!serviceList.ContainsKey(serviceNameString)) {
                    throw new Exception("找不到指定的服务").AddExceptionData("服务名称", serviceNameString);
                }
                var serviceObject = serviceList[serviceNameString].Value;
                if(serviceObject == null)
                    throw new Exception("找不到指定的服务").AddExceptionData("服务名称", serviceNameString);

                // 获取参数信息
                object[] inputParamList = null;
                if (!inputParameters.IsNullOrEmpty()) {
                    inputParamList = Deserialize<object[]>(inputParameters);
                }

                // 获取方法
                var method = serviceObject.GetType().GetMethod(functionNameString
                    , BindingFlags.Public | BindingFlags.Instance);
                if (method == null)
                    throw new Exception("找不到指定的服务方法")
                        .AddExceptionData("服务名称", serviceNameString)
                        .AddExceptionData("方法名称", functionNameString);

                // 调用方法
                var resultObj = method.Invoke(serviceObject, inputParamList);
                result = Serialize<object>(resultObj);
            };

            // 在事务中调用服务
            var transName = String.Format("{0}.{1}", serviceNameString, functionNameString);
            if (head != null && head.Transaction != null) {
                TransactionPublic.RunService(head.Transaction, transName, callService);
            }
            else {
                TransactionPublic.Run(transName, callService);
            }

            return result;
        }
        #endregion

        #region 传递数据
        /// <summary>
        /// 从网络读取字符串（考虑空字符串）
        /// </summary>
        /// <param name="reader">读取器</param>
        /// <returns>字符串</returns>
        public static byte[] NetReadBinary(this BinaryReader reader) {
            int count = reader.ReadInt32();
            if (count == 0)
                return null;

            var result = reader.ReadBytes(count);
            return result;
        }
        /// <summary>
        /// 写网络字符串（考虑空字符串）
        /// </summary>
        /// <param name="writer">写入器</param>
        /// <param name="data">字符串</param>
        public static void NetWriteBinary(this BinaryWriter writer, byte[] data) {
            if (data == null) {
                writer.Write(0);
            }
            else {
                writer.Write(data.Length);
                writer.Write(data);
            }
        }

        /// <summary>
        /// 从网络读取对象并反序列化
        /// </summary>
        /// <typeparam name="T">原始对象类型</typeparam>
        /// <param name="reader">读取器</param>
        /// <returns>原始对象</returns>
        public static T NetReadObject<T>(this BinaryReader reader) {
            return Deserialize<T>(NetReadBinary(reader));
        }

        /// <summary>
        /// 将对象序列化后传送到流中
        /// </summary>
        /// <typeparam name="T">原始对象类型</typeparam>
        /// <param name="writer">写入器</param>
        /// <param name="origionObject">原始对象</param>
        public static void NetWriteObject<T>(this BinaryWriter writer, T origionObject) {
            NetWriteBinary(writer, Serialize<T>(origionObject));
        }
        #endregion
    }
}
