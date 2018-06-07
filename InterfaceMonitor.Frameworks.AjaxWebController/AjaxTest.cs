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
        public string TestMethod()
        {
            return "这是一个测试方法！";
        }
    }
}
