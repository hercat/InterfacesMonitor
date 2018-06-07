using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVC;

namespace InterfaceMonitor.Frameworks.AjaxWebController
{
    public class AjaxTest
    {       
        [Action]
        public object TestMethod()
        {
            var obj = "这是一个测试方法！";
            return new JsonResult(obj);
        }
    }
}
