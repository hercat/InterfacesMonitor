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
        /// <summary>
        /// 获取某接口的日志信息（带分页）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        [Action]
        public object GetInterfaceLogsPageList(string fields,string id, int page, int rows)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                PageInfo pageInfo = new PageInfo()
                {
                    PageIndex = rows * (page - 1),
                    PageSize = rows,
                    RecCount = 0
                };                
                if (string.IsNullOrEmpty(fields))
                    fields = "*";
                string where = string.Empty;
                if (!string.IsNullOrEmpty(id))
                    where = string.Format(" where ConfigId = '{0}' order by CreateTime desc ", id);
                string limit = string.Empty;
                limit = string.Format("limit {0},{1}", pageInfo.PageIndex, pageInfo.PageSize);
                List<InterfaceExceptionlog> list = InterfaceExceptionlogOperation.GetInterfaceExceptionlogList(fields, where);
                pageInfo.RecCount = list.Count;
                List<InterfaceExceptionlog> target = InterfaceExceptionlogOperation.GetInterfaceExceptionByCondition(fields, where, limit);
                GridResult<InterfaceExceptionlog> result = new GridResult<InterfaceExceptionlog>(target, pageInfo.RecCount);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
