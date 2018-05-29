using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// Descrition:接口异常信息日志类实体
    /// Author:WUWEI
    /// Date:2018/05/29
    /// </summary>
    public class InterfaceExceptionlog
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 配置信息表编号
        /// </summary>
        public Guid ConfigId { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public int StateCode { get; set; }
        /// <summary>
        /// 异常信息内容
        /// </summary>
        public string ExceptionInfo { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumInterfaceExceptionlog.Id.ToString()))
                Id = long.Parse(dr[EnumInterfaceExceptionlog.Id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceExceptionlog.ConfigId.ToString()))
                ConfigId = new Guid(dr[EnumInterfaceExceptionlog.ConfigId.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceExceptionlog.StateCode.ToString()))
                StateCode = Int32.Parse(dr[EnumInterfaceExceptionlog.StateCode.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumInterfaceExceptionlog.ExceptionInfo.ToString()))
                ExceptionInfo = dr[EnumInterfaceExceptionlog.ExceptionInfo.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceExceptionlog.CreateTime.ToString()))
                CreateTime = DateTime.Parse(dr[EnumInterfaceExceptionlog.CreateTime.ToString()].ToString());
            return true;
        }
    }
    /// <summary>
    /// 接口异常日志信息数据库表字段枚举
    /// </summary>
    public enum EnumInterfaceExceptionlog
    {
        Id,
        ConfigId,
        StateCode,
        ExceptionInfo,
        CreateTime
    }
}
