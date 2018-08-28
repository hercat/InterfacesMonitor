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
        /// 添加应用系统信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="server"></param>
        /// <param name="userdep"></param>
        /// <param name="chageman"></param>
        /// <param name="phone"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [Action]
        public object AddApplicationSysInfo(string name, string server, string userdep, string chageman, string phone, string description)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (null != settings.SysMySqlDB)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        /// <summary>
        /// 获取应用系统分页
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="key"></param>
        /// <param name="order"></param>
        /// <param name="ascOrdesc"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [Action]
        public object GetApplicationSysInfoList(string fields, string key, string order, string ascOrdesc, int page, int rows)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ToString();
                PageInfo pageInfo = new PageInfo()
                {
                    PageIndex = rows * (page - 1),
                    PageSize = rows,
                    RecCount = 0
                };
                if (string.IsNullOrEmpty(fields))
                    fields = "*";
                string whereCondition = string.Empty;
                if (!string.IsNullOrEmpty(key))
                    whereCondition = string.Format(" where name like '%{0}%' or server like '%{0}%' or userdep like '%{0}%' or chargeman like '%{0}%' or phone like '%{0}%' ", key);
                string orderby = string.Empty;
                if (!string.IsNullOrEmpty(order))
                    orderby = string.Format(" order by {0} {1}", order, ascOrdesc);
                string limit = string.Empty;
                limit = string.Format(" limit {0},{1} ", pageInfo.PageIndex, pageInfo.PageSize);
                List<ApplicationSysInfo> list = ApplicationSysInfoLogical.GetApplicationSysInfoList(fields, whereCondition);
                pageInfo.RecCount = list.Count;
                List<ApplicationSysInfo> target = ApplicationSysInfoLogical.GetApplicationSysInfoList(fields, whereCondition, orderby, limit);
                GridResult<ApplicationSysInfo> result = new GridResult<ApplicationSysInfo>(target, pageInfo.RecCount);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据id删除应用系统信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public object DeleteApplicationSysInfo(string id)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                ApplicationSysInfo info = ApplicationSysInfoLogical.GetApplicationSysInfoById(new Guid(id));
                if (null != info)
                {
                    ApplicationSysInfoLogical.DeleteApplicationSysInfoById(new Guid(id));
                    return string.Format("删除【{0}】应用系统成功！", info.name);
                }
                else
                    return string.Format("系统不存在【{0}】应用系统信息！", info.name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
