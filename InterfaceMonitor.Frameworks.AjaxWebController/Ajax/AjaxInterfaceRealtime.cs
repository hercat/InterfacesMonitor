using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVC;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;
using InterfaceMonitor.Frameworks.Utility;

namespace InterfaceMonitor.Frameworks.AjaxWebController
{
    public class AjaxInterfaceRealtime
    {
        [Action]
        public object InterfaceRealtimeList()
        {            
            List<InterfaceRealtimeInfo> list = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfoList("Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime", "");
            return new JsonResult(list);
        }
    }
}
