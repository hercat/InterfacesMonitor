using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.BizProcess;
using InterfaceMonitor.Frameworks.Utility;

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
        [WebMethod]
        public void UpdateInterfaceRealtimeInfoService(string interfaceName, string applicationName, string server, int stateCode)
        {
            GetDataBaseConfig();
            InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfo(interfaceName, applicationName, server, stateCode);
        }
        [WebMethod]
        public void UpdateInterfaceRealtimeInfoWithExceptionService(string interfaceName, string applicationName, string server, int stateCode, string exceptionInfo)
        {
            GetDataBaseConfig();
            InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfoWithException(interfaceName, applicationName, server, stateCode, exceptionInfo);
        }
        private void GetDataBaseConfig()
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
        }
    }
}
