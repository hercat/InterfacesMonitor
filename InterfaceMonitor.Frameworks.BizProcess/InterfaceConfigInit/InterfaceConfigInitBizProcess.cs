using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;

namespace InterfaceMonitor.Frameworks.BizProcess
{
    public class InterfaceConfigInitBizProcess
    {
        public static void SaveInterfaceInitial(string interfaceName, string applicationName, string server, string user, string userPwd, string charger, string phone, int timeout, string path, string descript)
        {
            InterfaceConfigInfo config = new InterfaceConfigInfo();
            config.Id = Guid.NewGuid();
            config.InterfaceName = interfaceName;
            config.ApplicationName = applicationName;
            config.ServerAddress = server;
            config.ServerUser = user;
            config.UserPwd = userPwd;
            config.PersonOfChargeName = charger;
            config.PersonOfChargePhone = phone;
            config.ConnectedTimeout = timeout;
            config.DocumentHelpPath = path;
            config.Description = descript;
            config.CreateTime = DateTime.Now;

            InterfaceRealtimeInfo realtime = new InterfaceRealtimeInfo();
            realtime.Id = Guid.NewGuid();
            realtime.InterfaceName = interfaceName;
            realtime.ApplicationName = applicationName;
            realtime.ServerAddress = server;
            realtime.StateCode = 0;
            realtime.UpdateTime = DateTime.Now;

            InterfaceConfigInfoOperation.AddOrUpdateInterfaceConfigInfo(config, ModifierType.Add);
            InterfaceRealtimeInfoOperation.AddOrUpdateInterceRealtimeInfo(realtime, ModifierType.Add);
        }
    }
}
