using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;

namespace InterfaceMonitor.Frameworks.DalInterface
{
    public interface IApplicationSysInfo
    {
        bool AddOrUpdateApplicationSysInfo(IDbCommand idbcmd, ApplicationSysInfo info, ModifierType mode);
        ApplicationSysInfo GetApplicationSysInfoById(IDbCommand idbcmd, Guid id);
        bool DeleteApplicationSysInfoById(IDbCommand idbcmd, Guid id);
        ApplicationSysInfo GetApplicationSysInfo(IDbCommand idbcmd, string name, string server);
        List<ApplicationSysInfo> GetApplicationSysInfoList(IDbCommand idbcmd, string fields, string condition);
        List<ApplicationSysInfo> GetApplicationSysInfoList(IDbCommand idbcmd, string fileds, string condition, string orderby, string limit);
    }
}
