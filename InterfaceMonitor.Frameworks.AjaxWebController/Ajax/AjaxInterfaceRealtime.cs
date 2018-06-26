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
                foreach (InterfaceRealtimeInfo info in list)
                {
                    int interval = (DateTime.Now - info.UpdateTime).Minutes;
                    //状态不更新超时判断
                    if (interval >= 10)
                    {
                        info.StateCode = 0;
                        //info.UpdateTime = DateTime.Now;
                        //InterfaceRealtimeInfoOperation.AddOrUpdateInterceRealtimeInfo(info, ModifierType.Update);
                    }
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
