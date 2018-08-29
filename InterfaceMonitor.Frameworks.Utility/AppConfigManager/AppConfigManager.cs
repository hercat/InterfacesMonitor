using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMonitor.Frameworks.Utility
{
    /// <summary>
    /// Description:应用程序配置管理帮助类
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public class AppConfigManager
    {
        private static IDictionary<string, string> _dicDataProvider;
        public static IDictionary<string, string> DicDataProvider
        {
            get
            {
                if (_dicDataProvider == null || _dicDataProvider.Count == 0)
                {
                    _dicDataProvider = new Dictionary<string, string>();
                    _dicDataProvider.Add("DbConnDP", "InterfaceMonitor.Frameworks.Dal.DbConnDal");
                    _dicDataProvider.Add("DbInterfaceConfigInfoDP", "InterfaceMonitor.Frameworks.Dal.InterfaceConfigInfoDal");
                    _dicDataProvider.Add("DbInterfaceRealtimeDP", "InterfaceMonitor.Frameworks.Dal.InterfaceRealtimeInfoDal");
                    _dicDataProvider.Add("DbInterfaceExceptionlogDP", "InterfaceMonitor.Frameworks.Dal.InterfaceExceptionlogDal");
                    _dicDataProvider.Add("DbApplicationSysInfoDP", "InterfaceMonitor.Frameworks.Dal.ApplicationSysInfoDal");
                    _dicDataProvider.Add("DbApplicationInterfaceRelationDP", "InterfaceMonitor.Frameworks.Dal.ApplicationInterfaceRelationDal");
                }
                return _dicDataProvider;
            }
        }
        public static bool GetDataProvider(string dpname, out string dllname, out string assname)
        {
            dllname = DicDataProvider[dpname];
            assname = dllname.Substring(0, dllname.LastIndexOf("."));
            return true;
        }
    }
}
