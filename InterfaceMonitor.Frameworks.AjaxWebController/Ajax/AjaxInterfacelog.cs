using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVC;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Utility;
using InterfaceMonitor.Frameworks.Logical;

namespace InterfaceMonitor.Frameworks.AjaxWebController
{
    public class AjaxInterfacelog
    {
        /// <summary>
        /// 根据Id获取接口异常日志
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [Action]
        public object GetInterfaceLogs(string id)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(id))
                    sb.AppendFormat(" where ConfigId = '{0}' order by CreateTime desc ", id);
                List<InterfaceExceptionlog> logs = InterfaceExceptionlogOperation.GetInterfaceExceptionlogList(string.Empty, sb.ToString());
                return new JsonResult(logs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
