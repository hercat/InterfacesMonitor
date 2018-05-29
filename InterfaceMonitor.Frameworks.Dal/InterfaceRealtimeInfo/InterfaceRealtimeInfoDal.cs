using InterfaceMonitor.Frameworks.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using InterfaceMonitor.Frameworks.DalInterface;

namespace InterfaceMonitor.Frameworks.Dal
{
    /// <summary>
    /// Description:接口实时状态数据访问层
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public class InterfaceRealtimeInfoDal : IInterfaceRealtimeInfo
    {
        /// <summary>
        /// 接口实时状态信息新增或修改
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="entity"></param>
        /// <param name="mode"></param>
        public void AddOrUpdateInterceRealtimeInfo(IDbCommand icmd, InterfaceRealtimeInfo entity, ModifierType mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == ModifierType.Add)
            {
                string sql = @"insert into interfacerealtimeinfo(Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime)
                            values('{0}','{1}','{2}','{3}',{4},'{5}')";
                cmd.CommandText = string.Format(sql, entity.Id, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.StateCode, entity.UpdateTime);
            }
            else if (mode == ModifierType.Update)
            {
                string sql = @"update interfacerealtimeinfo
                                set InterfaceName = '{0}',
                                ApplicationName = '{1}',
                                ServerAddress = '{2}',
                                StateCode = {3},
                                UpdateTime = '{4}'
                                where Id = '{5}'";
                cmd.CommandText = string.Format(sql, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.StateCode, entity.UpdateTime, entity.Id);
            }
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 根据Id删除实时状态信息
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="id"></param>
        public void DeleteInterfaceRealtimeInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from interfacerealtimeinfo where Id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 根据Id获取实时状态信息
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public InterfaceRealtimeInfo GetInterfaceRealtimeInfo(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime 
                            from interfacerealtimeinfo
                            where Id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            InterfaceRealtimeInfo info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new InterfaceRealtimeInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }
        /// <summary>
        /// 根据接口名、应用系统名和服务器地址获取接口实时状态信息
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="interfaceName"></param>
        /// <param name="applicationName"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public InterfaceRealtimeInfo GetInterfaceRealtimeInfo(IDbCommand icmd, string interfaceName, string applicationName, string server)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime
                                from interfacerealtimeinfo
                                where InterfaceName = '{0}' and ApplicationName = '{1}' and ServerAddress = '{2}'";
            cmd.CommandText = string.Format(sql, interfaceName, applicationName, server);
            InterfaceRealtimeInfo info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new InterfaceRealtimeInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }
        /// <summary>
        /// 获取实时状态信息列表
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="fields"></param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public List<InterfaceRealtimeInfo> GetInterfaceRealtimeInfoList(IDbCommand icmd, string fields, string whereCondition)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from interfacerealtimeinfo ", fields);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.Append(whereCondition);
            cmd.CommandText = sb.ToString();
            List<InterfaceRealtimeInfo> list = new List<InterfaceRealtimeInfo>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                InterfaceRealtimeInfo obj = null;
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new InterfaceRealtimeInfo();
                    obj.AllParse(dr);
                    if (null != obj)
                        list.Add(obj);
                }
            }
            return list;
        }        
    }
}
