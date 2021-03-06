﻿using InterfaceMonitor.Frameworks.Entity;
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
                string sql = @"insert into interfacerealtimeinfo(Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime,appid)
                            values('{0}','{1}','{2}','{3}',{4},'{5}','{6}')";
                cmd.CommandText = string.Format(sql, entity.Id, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.StateCode, entity.UpdateTime, entity.appid);
            }
            else if (mode == ModifierType.Update)
            {
                string sql = @"update interfacerealtimeinfo
                                set InterfaceName = '{0}',
                                ApplicationName = '{1}',
                                ServerAddress = '{2}',
                                StateCode = {3},
                                UpdateTime = '{4}',
                                appid = '{5}'
                                where Id = '{6}'";
                cmd.CommandText = string.Format(sql, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.StateCode, entity.UpdateTime, entity.appid, entity.Id);
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
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime,appid
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
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime,appid
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

        public InterfaceRealtimeInfo GetInterfaceRealtimeInfo(IDbCommand icmd, string interfaceName, Guid appid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime,appid
                                from interfacerealtimeinfo
                                where InterfaceName = '{0}' and appid = '{1}'";
            cmd.CommandText = string.Format(sql, interfaceName, appid);
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
        /// <summary>
        /// 获取实时状态信息列表（带分页）
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="fields"></param>
        /// <param name="whereCondition"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<InterfaceRealtimeInfo> GetInterfaceRealtimeInfoPageList(IDbCommand icmd, string fields, string whereCondition, int pageIndex, int pageSize)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            int startIndex = (pageIndex - 1) * pageSize;//计算页面开始下标值
            if (!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from interfacerealtimeinfo ", fields);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.AppendFormat("{0} ", whereCondition);
            sb.AppendFormat("limit {0},{1}", startIndex, pageSize);
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
