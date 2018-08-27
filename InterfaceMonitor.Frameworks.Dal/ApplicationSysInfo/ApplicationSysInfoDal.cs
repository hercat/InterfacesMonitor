using System;
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
    }
}
