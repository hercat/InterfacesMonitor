using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;

namespace InterfaceMonitor.Frameworks.DalInterface
{
    public interface IApplicationInterfaceRelation
    {
        bool AddOrUpdateApplicationInterfaceRelation(IDbCommand idbcmd, ApplicationInterfaceRelation info, ModifierType mode);
        ApplicationInterfaceRelation GetApplicationInterfaceRelationById(IDbCommand idbcmd, Guid id);
        ApplicationInterfaceRelation GetApplicationInterfaceRelation(IDbCommand idbcmd, Guid appid, Guid interfaceid, Guid destinappid);
        bool DeleteApplicationInterfaceRelationById(IDbCommand idbcmd, Guid id);
        bool DeleteApplicationInterfaceRelation(IDbCommand idbcmd, Guid appid, Guid interfaceid, Guid destinappid);
        List<ApplicationInterfaceRelation> GetApplicationInterfaceRealtionList(IDbCommand idbcmd, string fields, string condition);
        List<ApplicationInterfaceRelation> GetApplicationInterfaceRealtionList(IDbCommand idbcmd, string fileds, string condition, string orderby, string limit);
    }
}
