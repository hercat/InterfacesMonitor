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
            string sql = @"insert into interfaceexceptionlog(ConfigId,StateCode,ExceptionInfo,CreateTime)
                            values('{0}',{1},'{2}','{3}')";
            cmd.CommandText = string.Format(sql, info.ConfigId, info.StateCode, info.ExceptionInfo, info.CreateTime);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 获取接口异常日志信息列表
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="fields">字段名</param>
        /// <param name="whereCondition">筛选条件</param>
        /// <returns></returns>
        public List<InterfaceExceptionlog> GetInterfaceExceptionlogList(IDbCommand icmd, string fields, string whereCondition)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from interfaceexceptionlog ", fields);
            else
                sb.Append("select * from interfaceexceptionlog ");
            if (!string.IsNullOrEmpty(whereCondition))
                sb.AppendFormat(whereCondition);
            cmd.CommandText = sb.ToString();
            List<InterfaceExceptionlog> list = new List<InterfaceExceptionlog>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                InterfaceExceptionlog obj = null;
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new InterfaceExceptionlog();
                    obj.AllParse(dr);
                    if (null != obj)
                        list.Add(obj);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取接口异常日志信息列表(带分页)
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="fields"></param>
        /// <param name="whereCondition"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<InterfaceExceptionlog> GetInterfaceExceptionlogPageList(IDbCommand icmd, string fields, string whereCondition, int pageIndex, int pageSize)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            int startIndex = (pageIndex - 1) * pageSize;//计算页面下标值
            if (!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from interfaceexceptionlog ", fields);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.AppendFormat("{0} ", whereCondition);
            sb.AppendFormat("limit {0},{1}", startIndex, pageSize);
            cmd.CommandText = sb.ToString();
            List<InterfaceExceptionlog> list = new List<InterfaceExceptionlog>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                InterfaceExceptionlog obj = null;
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new InterfaceExceptionlog();
                    obj.AllParse(dr);
                    if (null != obj)
                        list.Add(obj);
                }
            }
            return list;
        }
    }
}
