﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;

namespace InterfaceMonitor.Frameworks.DalInterface
{
    /// <summary>
    /// Description:接口实时状态数据接口层
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public interface IInterfaceRealtimeInfo
    {
        void AddOrUpdateInterceRealtimeInfo(IDbCommand idbcmd, InterfaceRealtimeInfo entity, ModifierType mode);
        void DeleteInterfaceRealtimeInfoById(IDbCommand idbcmd, Guid id);
        InterfaceRealtimeInfo GetInterfaceRealtimeInfo(IDbCommand idbcmd, Guid id);
        InterfaceRealtimeInfo GetInterfaceRealtimeInfo(IDbCommand idbcmd, string interfaceName, string applicationName, string server);
        InterfaceRealtimeInfo GetInterfaceRealtimeInfo(IDbCommand icmd, string interfaceName, Guid appid);
        List<InterfaceRealtimeInfo> GetInterfaceRealtimeInfoList(IDbCommand idbcmd, string fields, string whereCondition);
        List<InterfaceRealtimeInfo> GetInterfaceRealtimeInfoPageList(IDbCommand idbcmd, string fields, string whereCondition, int pageIndex, int pageSize);
    }
}
