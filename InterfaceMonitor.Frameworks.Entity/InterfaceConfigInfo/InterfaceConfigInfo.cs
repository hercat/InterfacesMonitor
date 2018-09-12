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
        /// 接口Url地址
        /// </summary>
        public string UrlAddress { get; set; }
        /// <summary>
        /// 应用程序描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 异常影响等级（0:一般;1:严重;2:非常严重）
        /// </summary>
        public int Exeptionlevel { get; set; }
        /// <summary>
        /// 是否立刻影响生产
        /// </summary>
        public int AffectProduction { get; set; }
        /// <summary>
        /// 接口类型（0:默认类型;其他未定义）
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 应用系统编号
        /// </summary>
        public Guid appid { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>
        public string appname { get; set; }
        /// <summary>
        /// 关联应用系统编号
        /// </summary>
        public Guid destinappid { get; set; }
        /// <summary>
        /// 关联应用系统名称
        /// </summary>
        public string destinappname { get; set; }
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
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.urlAddress.ToString()))
                UrlAddress = dr[EnumInterfaceConfigInfo.urlAddress.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.Description.ToString()))
                Description = dr[EnumInterfaceConfigInfo.Description.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.CreateTime.ToString()))
                CreateTime = DateTime.Parse(dr[EnumInterfaceConfigInfo.CreateTime.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.exeptionlevel.ToString()))
                Exeptionlevel = Int32.Parse(dr[EnumInterfaceConfigInfo.exeptionlevel.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.affectProduction.ToString()))
                AffectProduction = Int32.Parse(dr[EnumInterfaceConfigInfo.affectProduction.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.type.ToString()))
                Type = Int32.Parse(dr[EnumInterfaceConfigInfo.type.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.appid.ToString()))
                appid = new Guid(dr[EnumInterfaceConfigInfo.appid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.appname.ToString()))
                appname = dr[EnumInterfaceConfigInfo.appname.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.destinappid.ToString()))
                destinappid = new Guid(dr[EnumInterfaceConfigInfo.destinappid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceConfigInfo.destinappname.ToString()))
                destinappname = dr[EnumInterfaceConfigInfo.destinappname.ToString()].ToString();
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
        urlAddress,
        Description,
        CreateTime,
        exeptionlevel,
        affectProduction,
        type,
        appid,
        appname,
        destinappid,
        destinappname
    }
}
