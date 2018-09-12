using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.DalInterface;

namespace InterfaceMonitor.Frameworks.Dal
{
    public class ApplicationInterfaceRelationDal : IApplicationInterfaceRelation
    {
        public bool AddOrUpdateApplicationInterfaceRelation(IDbCommand icmd, ApplicationInterfaceRelation info, ModifierType mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == ModifierType.Add)
            {
                string sql = @"insert into applicationinterfacerelation(Id,appId,appname,interfaceId,interfacename,updatetime,destinappid,destinappname) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                cmd.CommandText = string.Format(sql, info.Id, info.appId, info.appname, info.interfaceId, info.interfacename, info.updatetime, info.destinappid, info.destinappname);
            }
            else if (mode == ModifierType.Update)
            {
                string sql = @"update applicationinterfacerelation set appId = '{0}',appname = '{1}',interfaceId = '{2}',interfacename = '{3}',updatetime = '{4}',destinappid = '{6}',destinappname = '{7}'
                               where Id = '{5}'";
                cmd.CommandText = string.Format(sql, info.appId, info.appname, info.interfaceId, info.interfacename, info.updatetime, info.Id, info.destinappid, info.destinappname);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public ApplicationInterfaceRelation GetApplicationInterfaceRelationById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,appId,appname,interfaceId,interfacename,updatetime,destinappid,destinappname from applicationinterfacerelation where Id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            ApplicationInterfaceRelation info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new ApplicationInterfaceRelation();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public ApplicationInterfaceRelation GetApplicationInterfaceRelation(IDbCommand icmd, Guid appid, Guid interfaceid,Guid destinappid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,appId,appname,interfaceId,interfacename,updatetime,destinappid,destinappname from applicationinterfacerelation where appId = '{0}' and interfaceId = '{1}' and destinappid = '{2}'";
            cmd.CommandText = string.Format(sql, appid, interfaceid, destinappid);
            ApplicationInterfaceRelation info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new ApplicationInterfaceRelation();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public bool DeleteApplicationInterfaceRelationById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from applicationinterfacerelation where Id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteApplicationInterfaceRelation(IDbCommand icmd, Guid appid, Guid interfaceid, Guid destinappid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from applicationinterfacerelation where appId = '{0}' and interfaceId = '{1}' and destinappid = '{2}'";
            cmd.CommandText = string.Format(sql, appid, interfaceid, destinappid);
            cmd.ExecuteNonQuery();
            return true;
        }

        public List<ApplicationInterfaceRelation> GetApplicationInterfaceRealtionList(IDbCommand icmd, string fields, string condition)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select {0} from applicationinterfacerelation ", fields);
            if (!string.IsNullOrEmpty(condition))
                sb.AppendFormat("{0} ", condition);
            cmd.CommandText = sb.ToString();
            List<ApplicationInterfaceRelation> list = new List<ApplicationInterfaceRelation>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                ApplicationInterfaceRelation info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new ApplicationInterfaceRelation();
                    info.AllParse(dr);
                    if (null != info)
                        list.Add(info);
                }
            }
            return list;
        }

        public List<ApplicationInterfaceRelation> GetApplicationInterfaceRealtionList(IDbCommand icmd, string fileds, string condition, string orderby, string limit)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select {0} from applicationinterfacerelation ", fileds);
            if (!string.IsNullOrEmpty(condition))
                sb.AppendFormat("{0} ", condition);
            if (!string.IsNullOrEmpty(orderby))
                sb.AppendFormat("{0} ", orderby);
            sb.AppendFormat("{0}", limit);
            cmd.CommandText = sb.ToString();
            List<ApplicationInterfaceRelation> list = new List<ApplicationInterfaceRelation>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                ApplicationInterfaceRelation info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new ApplicationInterfaceRelation();
                    info.AllParse(dr);
                    if (null != info)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}
