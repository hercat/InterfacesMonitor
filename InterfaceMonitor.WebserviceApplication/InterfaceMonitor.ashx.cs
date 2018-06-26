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
            context.Response.ContentType = "text/plain";
            string interfaceName = context.Request.Form["interfaceName"];
            string applicationName = context.Request.Form["applicationName"];
            string server = context.Request.Form["server"];
            int stateCode = !string.IsNullOrEmpty(context.Request.Form["stateCode"]) ? Int32.Parse(context.Request.Form["stateCode"]) : 0;
            string exceptionInfo = context.Request.Form["exceptionInfo"];
            if (!string.IsNullOrEmpty(exceptionInfo))
                UpdateInterfaceRealtimeInfoWithExceptionService(interfaceName, applicationName, server, stateCode, exceptionInfo);
            else
                UpdateInterfaceRealtimeInfoService(interfaceName, applicationName, server, stateCode);
            context.Response.Write("调用ashx成功！");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 接口实时状态更新
        /// </summary>
        /// <param name="interfaceName"></param>
        /// <param name="applicationName"></param>
        /// <param name="server"></param>
        /// <param name="stateCode"></param>
        private void UpdateInterfaceRealtimeInfoService(string interfaceName, string applicationName, string server, int stateCode)
        {
            try
            {
                Log4netInit();
                GetDataBaseConfig();
                InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfo(interfaceName, applicationName, server, stateCode);
            }
            catch (Exception ex)
            {
                log.Error("");
            }
        }
        /// <summary>
        /// 接口实时状态更新（带异常信息内容）
        /// </summary>
        /// <param name="interfaceName"></param>
        /// <param name="applicationName"></param>
        /// <param name="server"></param>
        /// <param name="stateCode"></param>
        /// <param name="exceptionInfo"></param>
        private void UpdateInterfaceRealtimeInfoWithExceptionService(string interfaceName, string applicationName, string server, int stateCode, string exceptionInfo)
        {
            try
            {
                Log4netInit();
                GetDataBaseConfig();
                InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfoWithException(interfaceName, applicationName, server, stateCode, exceptionInfo);
            }
            catch(Exception ex)
            {
                log.Error("");
            }
        }
        /// <summary>
        /// 获取数据库配置信息
        /// </summary>
        private void GetDataBaseConfig()
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
        }
        private void Log4netInit()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            string log4netConfigPath = string.Format("{0}\\log4net.xml", currentPath);
            XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4netConfigPath));
        }
    }
}