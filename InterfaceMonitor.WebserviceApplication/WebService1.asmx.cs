using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.BizProcess;

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
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public void UpdateInterfaceRealtimeInfoService(string interfaceName, string applicationName, string server, int stateCode)
        {
            ConnString.MySqldb = "server=localhost;Database=InterfaceMonitorDB;Charset=utf8;Uid=root;Pwd=jianglin";
            InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfo(interfaceName, applicationName, server, stateCode);
        }
        [WebMethod]
        public void UpdateInterfaceRealtimeInfoWithExceptionService(string interfaceName, string applicationName, string server, int stateCode, string exceptionInfo)
        {
            ConnString.MySqldb = "server=localhost;Database=InterfaceMonitorDB;Charset=utf8;Uid=root;Pwd=jianglin";
            InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfoWithException(interfaceName, applicationName, server, stateCode, exceptionInfo);
        }
    }
}
