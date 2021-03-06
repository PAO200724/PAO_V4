﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace PAO.Remote
{
    /// <summary>
    /// 接口：IRemoteService
    /// 远程服务
    /// 作者：PAO
    /// </summary>
    [Addon]
    [ServiceContract]
    public interface IRemote
    {
        /// <summary>
        /// 调用服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="header">服务头信息</param>
        /// <param name="inputParameters">输入参数</param>
        /// <returns>输出结果</returns>
        [OperationContract]
        byte[] CallService(byte[] serviceName, byte[] functionName, byte[] header, byte[] inputParameters);
    }
}
