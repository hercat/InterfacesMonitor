using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.BizProcess;
using InterfaceMonitor.Frameworks.Utility;
using log4net;
using log4net.Config;
using System.Reflection;

namespace InterfaceMonitor.WebserviceApplication
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class InterfaceMonitor : System.Web.Services.WebService
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        [WebMethod]
        public void UpdateInterfaceRealtimeInfoService(string interfaceName, string applicationName, string server, int stateCode)
        {
            try
            {
                Log4netInit();
                GetDataBaseConfig();
                InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfo(interfaceName, applicationName, server, stateCode);
                log.Info(string.Format("UpdateInterfaceRealtimeInfoService({0},{1},{2},{3})调用成功！", interfaceName, applicationName, server, stateCode));
            }
            catch (Exception ex)
            {
                log.Error(string.Format("UpdateInterfaceRealtimeInfoService({0},{1},{2},{3})调用异常，异常信息如下：{4}", interfaceName, applicationName, server, stateCode, ex));
            }
        }
        [WebMethod]
        public void UpdateInterfaceRealtimeInfoWithExceptionService(string interfaceName, string applicationName, string server, int stateCode, string exceptionInfo)
        {
            try
            {
                Log4netInit();
                GetDataBaseConfig();
                InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfoWithException(interfaceName, applicationName, server, stateCode, exceptionInfo);
                log.Info(string.Format("UpdateInterfaceRealtimeInfoWithExceptionService({0},{1},{2},{3},{4})调用成功！", interfaceName, applicationName, server, stateCode, exceptionInfo));
            }
            catch (Exception ex)
            {
                log.Error(string.Format("UpdateInterfaceRealtimeInfoWithExceptionService({0},{1},{2},{3},{4})调用异常，异常信息如下：{5}", interfaceName, applicationName, server, stateCode, exceptionInfo, ex));
            }
        }
        private void GetDataBaseConfig()
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
            }
            catch (Exception ex)
            {
                log.Error("GetDataBaseConfig()发生异常,异常信息如下:{0}", ex);
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
