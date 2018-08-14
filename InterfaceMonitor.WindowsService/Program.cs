using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace InterfaceMonitor.WindowsService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            string log4netConfig = string.Format("{0}\\log4net.xml", currentPath);
            XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(log4netConfig));
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new InterfaceMonitorService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
