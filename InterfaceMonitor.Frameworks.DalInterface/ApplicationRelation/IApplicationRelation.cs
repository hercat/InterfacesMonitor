using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;

namespace InterfaceMonitor.Frameworks.DalInterface
{
    public interface IApplicationRelation
    {
        bool AddOrUpdateApplicationRelation(IDbCommand idbcmd, ApplicationRelation info, ModifierType mode);
        bool DeleteApplicationRelationByid(IDbCommand idbcmd, Guid appid);
        ApplicationRelation GetApplicationRelationById(IDbCommand idbcmd, Guid appid);
    }
}
