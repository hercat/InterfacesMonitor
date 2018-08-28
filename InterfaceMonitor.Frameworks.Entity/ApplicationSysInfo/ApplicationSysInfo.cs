using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// Description:应用系统负责人基本信息类实体
    /// Author:WUWEI
    /// Date:2018/05/24
    /// </summary>
    public class ApplicationSysInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 应用系统名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 部署服务器地址
        /// </summary>
        public string server { get; set; }
        /// <summary>
        /// 使用部门
        /// </summary>
        public string userdep { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string chargeman { get; set; }
        /// <summary>
        /// 负责人电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createtime { get; set; }
        /// <summary>
        /// 系统级别
        /// </summary>
        public int level { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.Id.ToString()))
                Id = new Guid(dr[EnumApplicationSysInfo.Id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.name.ToString()))
                name = dr[EnumApplicationSysInfo.name.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.server.ToString()))
                server = dr[EnumApplicationSysInfo.server.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.userdep.ToString()))
                userdep = dr[EnumApplicationSysInfo.userdep.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.chargeman.ToString()))
                chargeman = dr[EnumApplicationSysInfo.chargeman.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.phone.ToString()))
                phone = dr[EnumApplicationSysInfo.phone.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.description.ToString()))
                description = dr[EnumApplicationSysInfo.description.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.createtime.ToString()))
                createtime = DateTime.Parse(dr[EnumApplicationSysInfo.createtime.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.level.ToString()))
                level = Int32.Parse(dr[EnumApplicationSysInfo.level.ToString()].ToString());
            return true;
        }
    }
    public enum EnumApplicationSysInfo
    {
        Id,
        name,
        server,
        userdep,
        chargeman,
        phone,
        description,
        createtime,
        level
    }
}
