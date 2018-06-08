using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVC;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Utility;

namespace InterfaceMonitor.Frameworks.AjaxWebController
{
    public class AjaxDbInitial
    {
        [Action]
        public void InitDb()
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
        }
    }
}
