using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;

namespace InterfaceMonitor.Frameworks.DalInterface
{
    public interface IInterfaceConfigInfo
    {
        void AddOrUpdateInterfaceConfigInfo(IDbCommand idbcmd,InterfaceConfigInfo entity,ModifierType mode);
        void DeleteInterfaceConfigInfoById(IDbCommand idbcmd, Guid id);
        InterfaceConfigInfo GetInterfaceConfigInfoById(IDbCommand idbcmd,Guid id);
        InterfaceConfigInfo GetInterfaceConfigInfo(IDbCommand idbcmd, string interfaceName, string server);
        InterfaceConfigInfo GetInterfaceConfigInfo(IDbCommand idbcmd, string interfaceName, string appname, string server);
        InterfaceConfigInfo GetInterfaceConfigInfo(IDbCommand idbcmd, string interfaceName, Guid appid);
        List<InterfaceConfigInfo> GetInterfaceConfigInfoList(IDbCommand idbcmd, string fields, string whereCondition);
        List<InterfaceConfigInfo> GetInterfaceConfigInfoPageList(IDbCommand idbcmd, string fields, string whereCondition, int pageIndex, int pageSize);
        List<InterfaceConfigInfo> GetInterfaceConfigInfoByCondition(IDbCommand idbcmd, string fields, string whereCondition, string orderby,string limit);
    }
}
