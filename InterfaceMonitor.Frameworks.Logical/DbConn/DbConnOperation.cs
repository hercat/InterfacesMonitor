using System.Data;

namespace InterfaceMonitor.Frameworks.Logical
{
    /// <summary>
    /// Description:
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public class DbConnOperation
    {
        /// <summary>
        /// 创建Mysql数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection()
        {
            return DataProvider.DbConnDP.CreateDbConn(InterfaceMonitor.Frameworks.Entity.ConnString.MySqldb);
        }
    }
}
