using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.DalInterface;
using MySql.Data.MySqlClient;
using System.Data;

namespace InterfaceMonitor.Frameworks.Dal
{
    public class DbConnDal : IDbConn
    {
        IDbConnection IDbConn.CreateDbConn(string connString)
        {
            return new MySqlConnection(connString);
        }
    }
}
