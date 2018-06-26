using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Dal;
using InterfaceMonitor.Frameworks.Utility;
using InterfaceMonitor.Frameworks.BizProcess;
using log4net;
using log4net.Config;
using System.Reflection;

namespace InterfaceMonitor.WebserviceApplication
{
    /// <summary>
    /// InterfaceMonitor1 的摘要说明
    /// </summary>
    public class InterfaceMonitor1 : IHttpHandler
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// ashx程序入口方法
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                Log4netInit();
                context.Response.ContentType = "text/plain";
                string interfaceName = context.Request.Form["interfaceName"];
                string applicationName = context.Request.Form["applicationName"];
                string server = context.Request.Form["server"];
                int stateCode = !string.IsNullOrEmpty(context.Request.Form["stateCode"]) ? Int32.Parse(context.Request.Form["stateCode"]) : 0;
                string exceptionInfo = context.Request.Form["exceptionInfo"];
                InterfaceMonitor client = new InterfaceMonitor();
                if (!string.IsNullOrEmpty(exceptionInfo))
                {
                    client.UpdateInterfaceRealtimeInfoWithExceptionService(interfaceName, applicationName, server, stateCode, exceptionInfo);
                    context.Response.Write("调用InterfaceMonitor.ashx成功！");
                    log.Info(string.Format("InterfaceMonitor.ashx   UpdateInterfaceRealtimeInfoWithExceptionService({0},{1},{2},{3},{4})调用成功！", interfaceName, applicationName, server, stateCode, exceptionInfo));
                }
                else
                {
                    client.UpdateInterfaceRealtimeInfoService(interfaceName, applicationName, server, stateCode);                    
                    context.Response.Write("调用InterfaceMonitor.ashx成功！");
                    log.Info(string.Format("InterfaceMonitor.ashx   UpdateInterfaceRealtimeInfoService({0},{1},{2},{3})调用成功！", interfaceName, applicationName, server, stateCode));
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("InterfaceMonitor.ashx接口调用发生异常,异常信息为:{0}", ex));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }        
        private void Log4netInit()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            string log4netConfigPath = string.Format("{0}\\log4net.xml", currentPath);
            XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4netConfigPath));
        }
    }
}