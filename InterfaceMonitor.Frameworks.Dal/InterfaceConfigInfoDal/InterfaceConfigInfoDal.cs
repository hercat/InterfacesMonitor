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
        /// 接口配置信息新增或修改方法
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
                                DocumentHelpPath,Description)
                            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}')";
                cmd.CommandText = string.Format(sql, entity.Id, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.ServerUser, entity.UserPwd, entity.PersonOfChargeName, entity.PersonOfChargePhone,
                    entity.ConnectedTimeout, entity.DocumentHelpPath, entity.Description);
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
                                Description = '{9}'
                                where Id = '{10}'";
                cmd.CommandText = string.Format(sql, entity.InterfaceName, entity.ApplicationName, entity.ServerAddress, entity.ServerUser, entity.UserPwd, entity.PersonOfChargeName, entity.PersonOfChargePhone,
                    entity.ConnectedTimeout, entity.DocumentHelpPath, entity.Description, entity.Id);
            }
            cmd.ExecuteNonQuery();
        }
    }
}
