using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.DalInterface;

namespace InterfaceMonitor.Frameworks.Logical
{
    /// <summary>
    /// Desciption:接口配置信息数据操作业务逻辑层
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public class InterfaceConfigInfoOperation
    {
        public static void AddOrUpdateInterfaceConfigInfo(InterfaceConfigInfo entity, ModifierType mode)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                dp.AddOrUpdateInterfaceConfigInfo(cmd, entity, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (null != trans)
                    trans.Rollback();
            }
            finally
            {
                if (null != conn)
                    conn.Close();
            }
        }
    }
}
