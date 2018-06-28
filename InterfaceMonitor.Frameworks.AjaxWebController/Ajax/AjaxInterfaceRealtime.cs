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
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                List<InterfaceRealtimeInfo> list = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfoList("Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime", "");
                List<InterfaceRealtimeInfo> result = new List<InterfaceRealtimeInfo>();
                int timeout = 10;
                foreach (InterfaceRealtimeInfo info in list)
                {
                    InterfaceConfigInfo config = InterfaceConfigInfoOperation.GetInterfaceConfigInfoById(info.Id);
                    double interval = (DateTime.Now - info.UpdateTime).TotalMinutes;
                    if (config != null && config.ConnectedTimeout > 0)
                        timeout = config.ConnectedTimeout;
                    //状态不更新超时判断
                    if (interval >= timeout)
                        info.StateCode = 0;                    
                    result.Add(info);
                }                
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// [Ajax层]根据Id获取接口实时状态方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public object GetInterfaceRealtimeById(string id)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                InterfaceRealtimeInfo info = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfo(new Guid(id));
                return new JsonResult(info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
