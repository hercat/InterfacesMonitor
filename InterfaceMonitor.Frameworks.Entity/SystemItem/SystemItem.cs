using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// Description:系统组件信息类实体
    /// Author:WUWEI
    /// Date:2018/05/24
    /// </summary>
    public class SystemItem
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumSystemItem.Id.ToString()))
                Id = new Guid(dr[EnumSystemItem.Id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumSystemItem.Name.ToString()))
                Name = dr[EnumSystemItem.Name.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumSystemItem.Type.ToString()))
                Type = Int32.Parse(dr[EnumSystemItem.Type.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumSystemItem.Remark.ToString()))
                Remark = dr[EnumSystemItem.Remark.ToString()].ToString();
            return true;
        }
    }
    public enum EnumSystemItem
    {
        Id,
        Name,
        Type,
        Remark
    }
}
