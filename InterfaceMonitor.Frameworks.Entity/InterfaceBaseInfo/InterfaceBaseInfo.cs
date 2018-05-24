using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// Description:业务接口基本信息类实体
    /// Author:WUWEI
    /// Date:2018/05/24
    /// </summary>
    public class InterfaceBaseInfo
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
        /// 接口信息
        /// </summary>
        public string Interface { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumInterfaceBaseInfo.Id.ToString()))
                Id = new Guid(dr[EnumInterfaceBaseInfo.Id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceBaseInfo.InterfaceName.ToString()))
                InterfaceName = dr[EnumInterfaceBaseInfo.InterfaceName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceBaseInfo.Interface.ToString()))
                Interface = dr[EnumInterfaceBaseInfo.Interface.ToString()].ToString();
            return true;
        }
    }
    public enum EnumInterfaceBaseInfo
    {
        Id,
        InterfaceName,
        Interface
    }
}
