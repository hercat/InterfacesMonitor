﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.DalInterface;
using InterfaceMonitor.Frameworks.Utility;
using System.Data;
using MySql.Data.MySqlClient;

namespace InterfaceMonitor.Frameworks.Dal
{
    /// <summary>
    /// Description:接口配置信息数据访问层
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public class InterfaceConfigInfoDal : IInterfaceConfigInfo
    {
        /// <summary>
        /// 接口配置信息数据新增或修改方法
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="mode"></param>
        public void AddOrUpdateInterfaceConfigInfo(IDbCommand icmd,InterfaceConfigInfo entity,ModifierType mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == ModifierType.Add)
            {                
                string sql = @"insert into interfaceconfiginfo(Id,InterfaceName,ApplicationName,ServerAddress,
                                ServerUser,UserPwd,PersonInChargeName,PersonInChargePhone,ConnectedTimeout,
                                DocumentHelpPath,Description,CreateTime,urlAddress,exeptionlevel,affectProduction,type,appid)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')";
                cmd.CommandText = string.Format(sql, entity.Id, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.ServerUser, entity.UserPwd, entity.PersonOfChargeName, entity.PersonOfChargePhone,
                    entity.ConnectedTimeout, entity.DocumentHelpPath, entity.Description, entity.CreateTime, entity.UrlAddress, entity.Exeptionlevel, entity.AffectProduction, entity.Type, entity.appid);
            }
            else if (mode == ModifierType.Update)
            {
                string sql = @"update interfaceconfiginfo 
                                set InterfaceName = '{0}',
                                ApplicationName = '{1}',
                                ServerAddress = '{2}',
                                ServerUser = '{3}',
                                UserPwd = '{4}',
                                PersonInChargeName = '{5}',
                                PersonInChargePhone = '{6}',
                                ConnectedTimeout = {7},
                                DocumentHelpPath = '{8}',
                                Description = '{9}',
                                CreateTime = '{10}',
                                urlAddress = '{12}',
                                exeptionlevel = '{13}',
                                affectProduction = '{14}',
                                type = '{15}',
                                appid = '{16}'
                                where Id = '{11}'";
                cmd.CommandText = string.Format(sql, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.ServerUser, entity.UserPwd, entity.PersonOfChargeName, entity.PersonOfChargePhone,
                    entity.ConnectedTimeout, entity.DocumentHelpPath, entity.Description, entity.CreateTime, entity.Id, entity.UrlAddress, entity.Exeptionlevel, entity.AffectProduction, entity.Type, entity.appid);
            }
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 接口配置信息数据删除方法
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="id"></param>
        public void DeleteInterfaceConfigInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from interfaceconfiginfo where Id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// 根据Id编号获取接口配置信息
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public InterfaceConfigInfo GetInterfaceConfigInfoById(IDbCommand icmd,Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,ServerUser,UserPwd,PersonInChargeName,PersonInChargePhone,ConnectedTimeout,DocumentHelpPath,Description,CreateTime,urlAddress,exeptionlevel,affectProduction,type,appid
                            from interfaceconfiginfo
                            where Id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            InterfaceConfigInfo entity = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                entity = new InterfaceConfigInfo();
                entity.AllParse(dt.Rows[0]);
            }
            return entity;
        }

        public InterfaceConfigInfo GetInterfaceConfigInfoWithApp(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select a.Id,a.InterfaceName,a.ApplicationName,a.ServerAddress,a.ServerUser,a.UserPwd,a.PersonInChargeName,a.PersonInChargePhone,a.ConnectedTimeout,a.DocumentHelpPath,a.Description,a.CreateTime,a.urlAddress,a.exeptionlevel,a.affectProduction,a.type,
                                b.appId,b.appname,b.destinappid,b.destinappname
                            from interfaceconfiginfo a
                            left join applicationinterfacerelation b
                            on a.Id = b.interfaceId
                            where a.Id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            InterfaceConfigInfo entity = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                entity = new InterfaceConfigInfo();
                entity.AllParse(dt.Rows[0]);
            }
            return entity;
        }
        /// <summary>
        /// 根据接口名、应用系统名和服务器地址获取配置信息
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="interfaceName"></param>
        /// <param name="applicationName"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public InterfaceConfigInfo GetInterfaceConfigInfo(IDbCommand icmd, string interfaceName, string server)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,ServerUser,UserPwd,PersonInChargeName,
                            PersonInChargePhone,ConnectedTimeout,DocumentHelpPath,Description,CreateTime,urlAddress,
                            exeptionlevel,affectProduction,type,appid
                            from interfaceconfiginfo
                            where InterfaceName = '{0}' and ServerAddress = '{1}'";
            cmd.CommandText = string.Format(sql, interfaceName, server);
            InterfaceConfigInfo info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new InterfaceConfigInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }
        public InterfaceConfigInfo GetInterfaceConfigInfo(IDbCommand icmd, string interfaceName, string appname, string server)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,ServerUser,UserPwd,PersonInChargeName,
                            PersonInChargePhone,ConnectedTimeout,DocumentHelpPath,Description,CreateTime,urlAddress,
                            exeptionlevel,affectProduction,type,appid
                            from interfaceconfiginfo
                            where InterfaceName = '{0}' and ApplicationName ='{1}' and ServerAddress = '{2}'";
            cmd.CommandText = string.Format(sql, interfaceName, appname, server);
            InterfaceConfigInfo info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new InterfaceConfigInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }
        public InterfaceConfigInfo GetInterfaceConfigInfo(IDbCommand icmd, string interfaceName, Guid appid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,ServerUser,UserPwd,PersonInChargeName,
                            PersonInChargePhone,ConnectedTimeout,DocumentHelpPath,Description,CreateTime,urlAddress,
                            exeptionlevel,affectProduction,type,appid
                            from interfaceconfiginfo
                            where InterfaceName = '{0}' and appid = '{1}'";
            cmd.CommandText = string.Format(sql, interfaceName, appid);
            InterfaceConfigInfo info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new InterfaceConfigInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }
        /// <summary>
        /// 获取接口配置信息列表
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="fields"></param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public List<InterfaceConfigInfo> GetInterfaceConfigInfoList(IDbCommand icmd, string fields, string whereCondition)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from interfaceconfiginfo ", fields);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.Append(whereCondition);
            cmd.CommandText = sb.ToString();
            List<InterfaceConfigInfo> list = new List<InterfaceConfigInfo>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                InterfaceConfigInfo obj = null;
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new InterfaceConfigInfo();
                    obj.AllParse(dr);
                    if (null != obj)
                        list.Add(obj);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取接口配置信息列表(带分页)
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="fields"></param>
        /// <param name="whereCondition"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<InterfaceConfigInfo> GetInterfaceConfigInfoPageList(IDbCommand icmd, string fields, string whereCondition, int startIndex, int pageSize)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;            
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from interfaceconfiginfo ", fields);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.AppendFormat("{0} ", whereCondition);
            sb.AppendFormat("limit {0},{1} ", startIndex, pageSize);
            cmd.CommandText = sb.ToString();
            List<InterfaceConfigInfo> list = new List<InterfaceConfigInfo>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                InterfaceConfigInfo obj = null;
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new InterfaceConfigInfo();
                    obj.AllParse(dr);
                    if (null != obj)
                        list.Add(obj);
                }
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="fields"></param>
        /// <param name="whereCondition"></param>
        /// <param name="orderby"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<InterfaceConfigInfo> GetInterfaceConfigInfoByCondition(IDbCommand icmd, string fields, string whereCondition, string orderby,string limit)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if(!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from interfaceconfiginfo ", fields);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.AppendFormat("{0} ", whereCondition);
            if (!string.IsNullOrEmpty(orderby))
                sb.AppendFormat("{0} ", orderby);
            if (!string.IsNullOrEmpty(limit))
                sb.AppendFormat("{0} ", limit);
            cmd.CommandText = sb.ToString();
            List<InterfaceConfigInfo> list = new List<InterfaceConfigInfo>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                InterfaceConfigInfo obj = null;
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new InterfaceConfigInfo();
                    obj.AllParse(dr);
                    if (null != obj)
                        list.Add(obj);
                }
            }
            return list;
        }
    }
}
