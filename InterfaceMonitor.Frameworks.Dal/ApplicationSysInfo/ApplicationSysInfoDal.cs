﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.DalInterface;

namespace InterfaceMonitor.Frameworks.Dal
{
    public class ApplicationSysInfoDal : IApplicationSysInfo
    {
        public bool AddOrUpdateApplicationSysInfo(IDbCommand icmd, ApplicationSysInfo info, ModifierType mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == ModifierType.Add)
            {
                string sql = @"insert into applicationinfo(Id,name,server,userdep,chargeman,phone,description,createtime) 
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                cmd.CommandText = string.Format(sql, info.Id, info.name, info.server, info.userdep, info.chargeman, info.phone, info.description, info.createtime);
            }
            else if (mode == ModifierType.Update)
            {
                string sql = @"update applicationinfo set name = '{0}',server = '{1}',userdep = '{2}',chargeman = '{3}',phone = '{4}',description = '{5}',createtime = '{6}'
                                where Id = '{7}'";
                cmd.CommandText = string.Format(sql, info.name, info.server, info.userdep, info.chargeman, info.phone, info.description, info.createtime, info.Id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public ApplicationSysInfo GetApplicationSysInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,name,server,userdep,chargeman,phone,description,createtime from applicationinfo where Id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            DataTable dt = new DataTable();
            ApplicationSysInfo info = null;
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new ApplicationSysInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public bool DeleteApplicationSysInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from interfacemonitordb.applicationinfo where Id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public ApplicationSysInfo GetApplicationSysInfo(IDbCommand icmd, string name, string server)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,name,server,userdep,chargeman,phone,description,createtime from applicationinfo where name = '{0}' and server = '{1}'";
            cmd.CommandText = string.Format(sql, name, server);
            DataTable dt = new DataTable();
            ApplicationSysInfo info = null;
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new ApplicationSysInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public List<ApplicationSysInfo> GetApplicationSysInfoList(IDbCommand icmd, string fields, string condition)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from applicationinfo ", fields);
            else
                sb.Append("select * from applicationinfo ");
            if (!string.IsNullOrEmpty(condition))
                sb.AppendFormat("where {0}", condition);
            List<ApplicationSysInfo> list = new List<ApplicationSysInfo>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                ApplicationSysInfo info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new ApplicationSysInfo();
                    info.AllParse(dr);
                    if (info != null)
                        list.Add(info);
                }
            }
            return list;
        }

        public static List<ApplicationSysInfo> GetApplicationSysInfoList(IDbCommand icmd, string fileds, string condition, int startIndex, int pageSize)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fileds))
                sb.AppendFormat("select {0} from applicationinfo ", fileds);
            else
                sb.Append("select * from applicationinfo ");
            if (!string.IsNullOrEmpty(condition))
                sb.AppendFormat(" where {0} ", condition);
            sb.AppendFormat("limit {0},{1}", startIndex, pageSize);
            List<ApplicationSysInfo> list = new List<ApplicationSysInfo>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                ApplicationSysInfo info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new ApplicationSysInfo();
                    info.AllParse(dr);
                    if (info != null)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}