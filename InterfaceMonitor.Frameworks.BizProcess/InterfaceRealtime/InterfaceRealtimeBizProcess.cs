using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;

namespace InterfaceMonitor.Frameworks.BizProcess
{
    /// <summary>
    /// Description:
    /// Author:WUWEI
    /// Date:2018/05/29
    /// </summary>
    public class InterfaceRealtimeBizProcess
    {
        /// <summary>
        /// 更新接口实时状态信息业务逻辑
        /// </summary>
        /// <param name="interfaceName">接口名</param>
        /// <param name="applicationName">应用系统名</param>
        /// <param name="server">服务器地址</param>
        /// <param name="stateCode">状态码</param>
        public static void UpdateInterfaceRealtimeInfo(string interfaceName, string applicationName, string server, int stateCode)
        {
            InterfaceRealtimeInfo info = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfo(interfaceName, applicationName, server);
            if (null != info)
            {
                info.StateCode = stateCode;
                info.UpdateTime = DateTime.Now;
                InterfaceRealtimeInfoOperation.AddOrUpdateInterceRealtimeInfo(info, ModifierType.Update);
            }
        }
        /// <summary>
        /// 更新接口实时状态信息、接口异常日志信息业务逻辑
        /// </summary>
        /// <param name="interfaceName">接口名</param>
        /// <param name="applicationName">应用系统名</param>
        /// <param name="server">服务器地址</param>
        /// <param name="stateCode">状态码</param>
        /// <param name="exceptionInfo">接口异常信息内容</param>
        public static void UpdateInterfaceRealtimeInfoWithException(string interfaceName, string applicationName, string server, int stateCode, string exceptionInfo)
        {
            InterfaceRealtimeInfo realtime = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfo(interfaceName, applicationName, server);
            InterfaceConfigInfo config = InterfaceConfigInfoOperation.GetInterfaceConfigInfo(interfaceName, server);
            if (null != realtime)
            {
                realtime.StateCode = stateCode;
                realtime.UpdateTime = DateTime.Now;
                InterfaceRealtimeInfoOperation.AddOrUpdateInterceRealtimeInfo(realtime, ModifierType.Update);
            }
            if (!string.IsNullOrEmpty(exceptionInfo))
            {
                InterfaceExceptionlog log = new InterfaceExceptionlog();
                log.ConfigId = config.Id;
                log.StateCode = stateCode;
                log.ExceptionInfo = exceptionInfo;
                log.CreateTime = DateTime.Now;
                InterfaceExceptionlogOperation.AddInterfaceExceptionlogInfo(log);
            }            
        }
    }
}
