using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using log4net;
using System.Reflection;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;

namespace InterfaceMonitor.Frameworks.BizProcess
{
    public class ApplicationSysInfoBizprocess
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void AddApplicationSysInfo(string name, string server, string userdep, string chargeman, string phone, string description)
        {
            try
            {
                ApplicationSysInfo info = new ApplicationSysInfo();
                if (null == ApplicationSysInfoLogical.GetApplicationSysInfo(name, server))
                {
                    info.Id = Guid.NewGuid();
                    info.name = name;
                    info.server = server;
                    info.userdep = userdep;
                    info.chargeman = chargeman;
                    info.phone = phone;
                    info.description = description;
                    info.createtime = DateTime.Now;
                    ApplicationSysInfoLogical.AddOrUpdateApplicationSysInfo(info, ModifierType.Add);
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("AddApplicationSysInfo()发生错误,错误信息如下:{0}", ex));
            }
        }

        public static void UpdateApplicationSysInfo(Guid id, string name, string server, string userdep, string chargeman, string phone, string description)
        {
            try
            {
                ApplicationSysInfo info = new ApplicationSysInfo();
                if (null != ApplicationSysInfoLogical.GetApplicationSysInfo(name, server))
                {
                    info.Id = id;
                    info.name = name;
                    info.server = server;
                    info.userdep = userdep;
                    info.chargeman = chargeman;
                    info.phone = phone;
                    info.description = description;
                    info.createtime = DateTime.Now;
                    ApplicationSysInfoLogical.AddOrUpdateApplicationSysInfo(info, ModifierType.Update);
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("UpdateApplicationSysInfo()发生错误,错误信息如下:{0}", ex));
            }
        }
    }
}
