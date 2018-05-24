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
        public string ApplicationSysName { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.Id.ToString()))
                Id = new Guid(dr[EnumApplicationSysInfo.Id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.ApplicationSysName.ToString()))
                ApplicationSysName = dr[EnumApplicationSysInfo.ApplicationSysName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationSysInfo.Remark.ToString()))
                Remark = dr[EnumApplicationSysInfo.Remark.ToString()].ToString();
            return true;
        }
    }
    public enum EnumApplicationSysInfo
    {
        Id,
        ApplicationSysName,
        Remark
    }
}
