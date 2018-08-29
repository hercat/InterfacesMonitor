using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// Description:应用程序接口关系类实体
    /// Author:WUWEI
    /// Date:2018/08/28
    /// </summary>
    public class ApplicationInterfaceRelation
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 应用系统编号
        /// </summary>
        public Guid appId { get; set; }
        /// <summary>
        /// 应用系统名称
        /// </summary>
        public string appname { get; set; }
        /// <summary>
        /// 接口编号
        /// </summary>
        public Guid interfaceId { get; set; }
        /// <summary>
        /// 接口名称
        /// </summary>
        public string interfacename { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime updatetime { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.Id.ToString()))
                Id = new Guid(dr[EnumApplicationInterfaceRelation.Id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.appId.ToString()))
                appId = new Guid(dr[EnumApplicationInterfaceRelation.appId.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.appname.ToString()))
                appname = dr[EnumApplicationInterfaceRelation.appname.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.interfaceId.ToString()))
                interfaceId = new Guid(dr[EnumApplicationInterfaceRelation.interfaceId.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.interfacename.ToString()))
                interfacename = dr[EnumApplicationInterfaceRelation.interfacename.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.updatetime.ToString()))
                updatetime = DateTime.Parse(dr[EnumApplicationInterfaceRelation.updatetime.ToString()].ToString());
            return true;
        }
    }
    public enum EnumApplicationInterfaceRelation
    {
        Id,
        appId,
        appname,
        interfaceId,
        interfacename,
        updatetime
    }
}
