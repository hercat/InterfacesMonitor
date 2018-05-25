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
    /// Date:2018/05/24
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
        public Guid ApplicationId { get; set; }
        /// <summary>
        /// 接口编号
        /// </summary>
        public Guid InterfaceId { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.Id.ToString()))
                Id = new Guid(dr[EnumApplicationInterfaceRelation.Id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.ApplicationId.ToString()))
                ApplicationId = new Guid(dr[EnumApplicationInterfaceRelation.ApplicationId.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.InterfaceId.ToString()))
                InterfaceId = new Guid(dr[EnumApplicationInterfaceRelation.InterfaceId.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationInterfaceRelation.UpdateTime.ToString()))
                UpdateTime = DateTime.Parse(dr[EnumApplicationInterfaceRelation.UpdateTime.ToString()].ToString());
            return true;
        }
    }
    public enum EnumApplicationInterfaceRelation
    {
        Id,
        ApplicationId,
        InterfaceId,
        UpdateTime
    }
}
