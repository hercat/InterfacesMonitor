using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// Description:接口配置信息表
    /// Author:WUWEI
    /// Date:2018/05/24
    /// </summary>
    public class InterfaceConfigInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 接口名
        /// </summary>
        public string InterfaceName { get; set; }
        /// <summary>
        /// 应用程序名
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string ServerAddress { get; set; }
        /// <summary>
        /// 服务器用户名
        /// </summary>
        public string ServerUser { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 负责人名
        /// </summary>
        public string PersonOfChargeName { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        public string PersonOfChargePhone { get; set; }
        /// <summary>
        /// 接口访问超时时间
        /// </summary>
        public int ConnectedTimeout { get; set; }
        /// <summary>
        /// 应用程序问题帮助文档存放路径
        /// </summary>
        public string DocumentHelpPath { get; set; }
        /// <summary>
        /// 应用程序描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// AllParse
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.Id.ToString()))
                Id = new Guid(dr[EnumInterfaceConfigInfo.Id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.InterfaceName.ToString()))
                InterfaceName = dr[EnumInterfaceConfigInfo.InterfaceName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.ApplicationName.ToString()))
                ApplicationName = dr[EnumInterfaceConfigInfo.ApplicationName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.ServerAddress.ToString()))
                ServerAddress = dr[EnumInterfaceConfigInfo.ServerAddress.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.ServerUser.ToString()))
                ServerUser = dr[EnumInterfaceConfigInfo.ServerUser.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.UserPwd.ToString()))
                UserPwd = dr[EnumInterfaceConfigInfo.UserPwd.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.PersonInChargeName.ToString()))
                PersonOfChargeName = dr[EnumInterfaceConfigInfo.PersonInChargeName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.PersonInChargePhone.ToString()))
                PersonOfChargePhone = dr[EnumInterfaceConfigInfo.PersonInChargePhone.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.ConnectedTimeout.ToString()))
                ConnectedTimeout = Int32.Parse(dr[EnumInterfaceConfigInfo.ConnectedTimeout.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.DocumentHelpPath.ToString()))
                DocumentHelpPath = dr[EnumInterfaceConfigInfo.DocumentHelpPath.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.Description.ToString()))
                Description = dr[EnumInterfaceConfigInfo.Description.ToString()].ToString();
            return true;
        }
    }
    /// <summary>
    /// 接口配置信息数据库表字段枚举
    /// </summary>
    public enum EnumInterfaceConfigInfo
    {
        Id,
        InterfaceName,
        ApplicationName,
        ServerAddress,
        ServerUser,
        UserPwd,
        PersonInChargeName,
        PersonInChargePhone,
        ConnectedTimeout,
        DocumentHelpPath,
        Description
    }
}
