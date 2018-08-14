using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;

namespace InterfaceMonitor.WindowsService
{
    public partial class InterfaceMonitorService : ServiceBase
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public InterfaceMonitorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            log.Info("【InterfaceMonitorService】服务启动...");
        }

        protected override void OnStop()
        {
            log.Info("【InterfaceMonitorService】服务停止...");
        }
    }
}
