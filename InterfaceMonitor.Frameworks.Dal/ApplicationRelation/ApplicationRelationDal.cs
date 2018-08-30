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
    public class ApplicationRelationDal : IApplicationRelation
    {
        public bool AddOrUpdateApplicationRelation(IDbCommand icmd, ApplicationRelation info, ModifierType mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == ModifierType.Add)
            {
                string sql = @"insert into applicationrelation(appId,appName,fatherId,fatherName,childId,childName,createtime)
                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                cmd.CommandText = string.Format(sql, info.appId, info.appName, info.fatherId, info.fatherName, info.childId, info.childName, info.createtime);
            }
            else if (mode == ModifierType.Update)
            {
                string sql = @"update applicationrelation set fatherId = '{0}',fatherName = '{1}',childId = '{2}',childName = '{3}',createtime = '{4}'
                                where appId = '{5}'";
                cmd.CommandText = string.Format(sql, info.fatherId, info.fatherName, info.childId, info.childName, info.appId);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteApplicationRelationByid(IDbCommand icmd, Guid appid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from applicationrelation where appId = '{0}'";
            cmd.CommandText = string.Format(sql, appid);
            cmd.ExecuteNonQuery();
            return true;
        }

        public ApplicationRelation GetApplicationRelationById(IDbCommand icmd, Guid appid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select appId,appName,fatherId,fatherName,childId,childName,createtime from applicationrelation where appId = '{0}'";
            cmd.CommandText = string.Format(sql, appid);
            ApplicationRelation info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new ApplicationRelation();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }
    }
}
