using System;
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
                                DocumentHelpPath,Description,CreateTime)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}')";
                cmd.CommandText = string.Format(sql, entity.Id, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.ServerUser, entity.UserPwd, entity.PersonOfChargeName, entity.PersonOfChargePhone,
                    entity.ConnectedTimeout, entity.DocumentHelpPath, entity.Description, entity.CreateTime);
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
                                CreateTime = '{10}'
                                where Id = '{11}'";
                cmd.CommandText = string.Format(sql, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.ServerUser, entity.UserPwd, entity.PersonOfChargeName, entity.PersonOfChargePhone,
                    entity.ConnectedTimeout, entity.DocumentHelpPath, entity.Description, entity.CreateTime, entity.Id);
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
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,ServerUser,UserPwd,PersonInChargeName,PersonInChargePhone,ConnectedTimeout,DocumentHelpPath,Description,CreateTime
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
        /// <summary>
        /// 根据接口名、应用系统名和服务器地址获取配置信息
        /// </summary>
        /// <param name="icmd"></param>
        /// <param name="interfaceName"></param>
        /// <param name="applicationName"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public InterfaceConfigInfo GetInterfaceConfigInfo(IDbCommand icmd, string interfaceName, string applicationName, string server)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select Id,InterfaceName,ApplicationName,ServerAddress,ServerUser,UserPwd,PersonInChargeName,
                            PersonInChargePhone,ConnectedTimeout,DocumentHelpPath,Description,CreateTime
                            from interfaceconfiginfo
                            where InterfaceName = '{0}' and ApplicationName = '{1}' and ServerAddress = '{2}'";
            cmd.CommandText = string.Format(sql, interfaceName, applicationName, server);
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
        public List<InterfaceConfigInfo> GetInterfaceConfigInfoPageList(IDbCommand icmd, string fields, string whereCondition, int pageIndex, int pageSize)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            int startIndex = (pageIndex - 1) * pageSize;//计算分页开始下标值
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
    }
}
