using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;

namespace InterfaceMonitor.Frameworks.DalInterface
{
    /// <summary>
    /// Description:接口异常日志信息接口层
    /// Author:WUWEI
    /// Date:2018/05/29
    /// </summary>
    public interface IInterfaceExceptionlog
    {
        void AddInterfaceExceptionlogInfo(IDbCommand idbcmd,InterfaceExceptionlog info);
        List<InterfaceExceptionlog> GetInterfaceExceptionlogList(IDbCommand idbcmd, string fields, string whereCondition);
    }
}
