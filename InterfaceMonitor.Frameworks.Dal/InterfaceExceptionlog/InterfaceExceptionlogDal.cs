using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.DalInterface;
using System.Data;
using MySql.Data.MySqlClient;

namespace InterfaceMonitor.Frameworks.Dal
{
    /// <summary>
    /// Description:接口异常日志信息数据访问层
    /// Author:WUWEI
    /// Date:2018/05/29
    /// </summary>
    public class InterfaceExceptionlogDal : IInterfaceExceptionlog
    {
        /// <summary>
        /// 添加接口异常日志信息
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="info"></param>
        public void AddInterfaceExceptionlogInfo(IDbCommand icmd, InterfaceExceptionlog info)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"insert into interfaceexceptionlog(Id,ConfigId,StateCode,ExceptionInfo,CreateTime)
                            values('{0}','{1}',{2},'{3}','{4}')";
            cmd.CommandText = string.Format(sql, info.Id, info.ConfigId, info.StateCode, info.ExceptionInfo, info.CreateTime);
            cmd.ExecuteNonQuery();
        }
    }
}
