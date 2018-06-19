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
    /// <summary>
    /// Description:接口配置Ajax控制层方法封装类
    /// Author:WUWEI
    /// Date:2018/06/10
    /// </summary>
    public class AjaxInterfaceConfig
    {
        /// <summary>
        /// [Ajax层]获取所有接口配置信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [Action]
        public object GetInterfaceConfigInfoPageList(string fields,int page, int pagesize)
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
            if (string.IsNullOrEmpty(fields))
                fields = "*";
            List<InterfaceConfigInfo> list = InterfaceConfigInfoOperation.GetInterfaceConfigInfoPageList(fields, string.Empty, page, pagesize);
            return new JsonResult(list);
        }
        /// <summary>
        /// [Ajax层]根据条件获取所有接口配置信息
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="interfaceName"></param>
        /// <param name="applicationName"></param>
        /// <param name="server"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [Action]
        public object SearchInterfaceConfigPageList(string fields, string interfaceName, string applicationName, string server, int page, int pagesize)
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
            if (string.IsNullOrEmpty(fields))
                fields = "*";
            StringBuilder sb = new StringBuilder();
            //接口名称
            if (!string.IsNullOrEmpty(interfaceName))
                sb.AppendFormat(" where InterfaceName like '%{0}%' ", interfaceName);
            //应用系统名
            if (!string.IsNullOrEmpty(interfaceName) && !string.IsNullOrEmpty(applicationName))
                sb.AppendFormat(" and ApplicationName like '%{0}%' ", applicationName);
            else if (string.IsNullOrEmpty(interfaceName) && !string.IsNullOrEmpty(applicationName))
                sb.AppendFormat(" where ApplicationName like '%{0}%' ", applicationName);
            //服务器地址
            if ((!string.IsNullOrEmpty(interfaceName) || !string.IsNullOrEmpty(applicationName)) && !string.IsNullOrEmpty(server))
                sb.AppendFormat(" and ServerAddress like '%{0}%' ", server);
            else if ((string.IsNullOrEmpty(interfaceName) && (string.IsNullOrEmpty(applicationName))) && !string.IsNullOrEmpty(server))
                sb.AppendFormat(" where ServerAddress like '%{0}%' ", server);
            List<InterfaceConfigInfo> list = InterfaceConfigInfoOperation.GetInterfaceConfigInfoPageList(fields, sb.ToString(), page, pagesize);
            return new JsonResult(list);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [Action]
        public object SearchInterfaceConfig(string fields, string key, int page, int pagesize)
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
            if (string.IsNullOrEmpty(fields))
                fields = "*";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" where InterfaceName like '%{0}%' or ApplicationName like '%{0}%' or ServerAddress like '%{0}%' ", key.Trim());
            List<InterfaceConfigInfo> list = InterfaceConfigInfoOperation.GetInterfaceConfigInfoPageList(fields, sb.ToString(), page, pagesize);
            return new JsonResult(list);
        }
        /// <summary>
        /// [Ajax层]根据接口名模糊搜索接口配置信息分页列表
        /// </summary>
        /// <param name="fields">返回字段</param>
        /// <param name="interfaceName">接口名模糊搜索内容</param>
        /// <param name="page">页下标</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
        [Action]
        public object GetInterfaceConfigInfoPageListByName(string fields, string interfaceName, int page, int pagesize)
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
            if (string.IsNullOrEmpty(fields))
                fields = "*";
            StringBuilder sb = new StringBuilder();
            //接口名模糊搜索
            if (!string.IsNullOrEmpty(interfaceName))
                sb.AppendFormat(" where InterfaceName like '%{0}%' ", interfaceName);
            List<InterfaceConfigInfo> list = InterfaceConfigInfoOperation.GetInterfaceConfigInfoPageList(fields, sb.ToString(), page, pagesize);
            return new JsonResult(list);
        }
        /// <summary>
        /// [Ajax层]根据应用名模糊搜索接口配置信息分页列表
        /// </summary>
        /// <param name="fields">返回字段</param>
        /// <param name="applicationName">应用系统名模糊搜索内容</param>
        /// <param name="page">页下标</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
        [Action]
        public object GetInterfaceConfigInfoPageListByAppName(string fields, string applicationName, int page, int pagesize)
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
            if (string.IsNullOrEmpty(fields))
                fields = "*";
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(applicationName))
                sb.AppendFormat(" where ApplicationName like '%{0}%' ", applicationName);
            List<InterfaceConfigInfo> list = InterfaceConfigInfoOperation.GetInterfaceConfigInfoPageList(fields, sb.ToString(), page, pagesize);
            return new JsonResult(list);
        }
        /// <summary>
        /// [Ajax层]根据服务器模糊搜索接口配置信息分页列表
        /// </summary>
        /// <param name="fields">返回字段名</param>
        /// <param name="server">服务器地址模糊搜索内容</param>
        /// <param name="page">页下标</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
        [Action]
        public object GetInferfaceConfigPageListByServer(string fields, string server, int page, int pagesize)
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
            if (string.IsNullOrEmpty(fields))
                fields = "*";
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(server))
                sb.AppendFormat(" where ServerAddress like '%{0}%' ", server);
            List<InterfaceConfigInfo> list = InterfaceConfigInfoOperation.GetInterfaceConfigInfoPageList(fields, sb.ToString(), page, pagesize);
            return new JsonResult(list);
        }
        /// <summary>
        /// 根据Id获取接口配置信息
        /// </summary>        
        /// <param name="id">编号</param>
        /// <returns></returns>
        [Action]
        public object GetInterfaceConfigById( string id)
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;            
            InterfaceConfigInfo info = InterfaceConfigInfoOperation.GetInterfaceConfigInfoById(new Guid(id));
            return new JsonResult(info);
        }
        /// <summary>
        /// 新增接口配置信息
        /// </summary>
        /// <param name="interfaceName">接口名称</param>
        /// <param name="applicationName">应用系统名称</param>
        /// <param name="server">服务器地址</param>
        /// <param name="user">服务器用户名</param>
        /// <param name="pwd">用户密码</param>
        /// <param name="charger">负责人</param>
        /// <param name="phone">负责人电话</param>
        /// <param name="timeout">timeout值</param>
        /// <param name="docPath">帮助文档路径</param>
        /// <param name="desc">描述</param>
        /// <returns></returns>
        [Action]
        public object AddInterfaceConfigInfo(string interfaceName, string applicationName, string server, string user, string pwd, string charger, string phone, int timeout, string docPath, string desc)
        {
            try
            {
                if (null == InterfaceConfigInfoOperation.GetInterfaceConfigInfo(interfaceName, applicationName, server))
                    InterfaceConfigInitBizProcess.SaveInterfaceInitial(interfaceName, applicationName, server, user, pwd, charger, phone, timeout, docPath, desc);
                else
                    return string.Format("{0},{1},{2}该接口配置已存在！", interfaceName, applicationName, server);               
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
