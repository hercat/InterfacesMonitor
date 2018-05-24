using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// Description:接口实时状态实体
    /// Author:WUWEI
    /// Date:2018/05/24
    /// </summary>
    public class InterfaceRealtimeInfo
    {
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
        /// 当前返回时间
        /// </summary>
        public int ReturnTimeout { get; set; }
        /// <summary>
        /// AllParse
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumInterfaceRealtimeInfo.InterfaceName.ToString()))
                InterfaceName = dr[EnumInterfaceRealtimeInfo.InterfaceName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceRealtimeInfo.ApplicationName.ToString()))
                ApplicationName = dr[EnumInterfaceRealtimeInfo.ApplicationName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceRealtimeInfo.ServerAddress.ToString()))
                ServerAddress = dr[EnumInterfaceRealtimeInfo.ServerAddress.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumInterfaceRealtimeInfo.ReturnTimeout.ToString()))
                ReturnTimeout = Int32.Parse(dr[EnumInterfaceRealtimeInfo.ReturnTimeout.ToString()].ToString());
            return true;
        }
    }
    /// <summary>
    /// 接口实时状态数据库表字段枚举
    /// </summary>
    public enum EnumInterfaceRealtimeInfo
    {
        InterfaceName,
        ApplicationName,
        ServerAddress,
        ReturnTimeout
    }
}
