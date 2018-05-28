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
                    _dicDataProvider.Add("DbConnDP", "InterfaceMonitor.Frameworks.DalInterface.IDbConn");
                    _dicDataProvider.Add("DbInterfaceConfigInfoDP", "InterfaceMonitor.Frameworks.DalInterface.IInterfaceConfigInfo");
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
