using System;
using System.Collections.Generic;
using MyMVC;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;
using InterfaceMonitor.Frameworks.Utility;

namespace InterfaceMonitor.Frameworks.AjaxWebController
{
    public class AjaxInterfaceRealtime
    {
        /// <summary>
        /// [Ajax层]获取接口实时状态列表测试方法
        /// </summary>
        /// <returns></returns>
        [Action]
        public object InterfaceRealtimeList()
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
            List<InterfaceRealtimeInfo> list = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfoList("Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime", "");
            return new JsonResult(list);
        }
        /// <summary>
        /// [Ajax层]根据Id获取接口实时状态方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public object GetInterfaceRealtimeById(string id)
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
            InterfaceRealtimeInfo info = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfo(new Guid(id));
            return new JsonResult(info);
        }
    }
}
