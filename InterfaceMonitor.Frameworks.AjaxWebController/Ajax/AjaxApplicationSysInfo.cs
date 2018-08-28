using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVC;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;
using InterfaceMonitor.Frameworks.Utility;
using InterfaceMonitor.Frameworks.BizProcess;

namespace InterfaceMonitor.Frameworks.AjaxWebController
{
    public class AjaxApplicationSysInfo
    {
        /// <summary>
        /// 根据id获取应用系统信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public object GetApplicationSysInfoById(string id)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                ApplicationSysInfo info = ApplicationSysInfoLogical.GetApplicationSysInfoById(new Guid(id));
                return new JsonResult(info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取应用系统信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        [Action]
        public object GetApplicationSysInfo(string name, string server)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                ApplicationSysInfo info = ApplicationSysInfoLogical.GetApplicationSysInfo(name, server);
                return new JsonResult(info);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
