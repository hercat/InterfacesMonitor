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
        List<InterfaceConfigInfo> GetInterfaceConfigInfoList(IDbCommand idbcmd, string fields, string whereCondition);
    }
}
