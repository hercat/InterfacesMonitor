using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InterfaceMonitor.Frameworks.DalInterface
{
    /// <summary>
    /// Description:数据库连接接口创建接口
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public interface IDbConn
    {
        IDbConnection CreateDbConn(string connString);
    }
}
