using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVC;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;
using InterfaceMonitor.Frameworks.Utility;

namespace InterfaceMonitor.Frameworks.AjaxWebController
{
    public class AjaxApplicationInterfaceRelation
    {
        /// <summary>
        /// 添加应用系统与接口关联关系
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appname"></param>
        /// <param name="interfaceid"></param>
        /// <param name="interfacename"></param>
        /// <returns></returns>
        [Action]
        public object AddApplicationInterfaceRelation(string appid, string appname, string interfaceid, string interfacename,string destinappid,string destinappname,string fatherid,string fathername)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                if (null == ApplicationInterfaceRelationOperation.GetApplicationInterfaceRelation(new Guid(appid), new Guid(interfaceid), new Guid(destinappid)))
                {
                    ApplicationInterfaceRelation info = new ApplicationInterfaceRelation()
                    {
                        Id = Guid.NewGuid(),
                        appId = new Guid(appid),
                        appname = appname,
                        interfaceId = new Guid(interfaceid),
                        interfacename = interfacename,
                        destinappid = new Guid(destinappid),
                        destinappname = destinappname,
                        updatetime = DateTime.Now
                    };
                    ApplicationInterfaceRelationOperation.AddOrUpdateApplicationInterfaceRelation(info, ModifierType.Add);
                    if (null == ApplicationRelationOperation.GetApplicationRelationById(new Guid(appid)))
                    {
                        ApplicationRelation relation = new ApplicationRelation()
                        {
                            appId = new Guid(appid),
                            appName = appname,
                            fatherId = new Guid(fatherid),
                            fatherName = fathername,
                            childId = new Guid(destinappid),
                            childName = destinappname
                        };
                        ApplicationRelationOperation.AddOrUpdateApplicationRelation(relation, ModifierType.Add);
                    }
                    return string.Format("添加【{0},{1},{2}】关联关系成功！", appname, interfacename, destinappname);
                }
                else
                    return string.Format("系统已存在【{0},{1},{2}】该关联关系！", appname, interfacename, destinappname);
            }
            catch (Exception ex)
            {
                return string.Format("添加【{0},{1},{2}】关联关系失败！异常信息如下:{3}", appname, interfacename, destinappname, ex.Message);
            }
        }
        /// <summary>
        /// 修改应用系统与接口关联关系
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appid"></param>
        /// <param name="appname"></param>
        /// <param name="interfaceid"></param>
        /// <param name="interfacename"></param>
        /// <returns></returns>
        [Action]
        public object UpdateApplicationInterfaceRelation(string id, string appid, string appname, string interfaceid, string interfacename, string destinappid, string destinappname,string fatherid,string fathername)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (settings.SysMySqlDB != null)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                if (null != ApplicationInterfaceRelationOperation.GetApplicationInterfaceRelationById(new Guid(id)))
                {
                    ApplicationInterfaceRelation info = new ApplicationInterfaceRelation()
                    {
                        Id = new Guid(id),
                        appId = new Guid(appid),
                        appname = appname,
                        interfaceId = new Guid(interfaceid),
                        interfacename = interfacename,
                        destinappid = new Guid(destinappid),
                        destinappname = destinappname,
                        updatetime = DateTime.Now
                    };                    
                    ApplicationInterfaceRelationOperation.AddOrUpdateApplicationInterfaceRelation(info, ModifierType.Update);
                    return string.Format("修改【{0},{1},{2}】关联关系成功！", appname, interfacename, destinappname);
                }
                else
                    return string.Format("系统不存在【{0},{1},{2}】该关联关系！", appname, interfacename, destinappname);
            }
            catch (Exception ex)
            {
                return string.Format("修改【{0},{1},{2}】关联关系失败！异常信息如下:{3}", appname, interfacename, destinappname, ex.Message);
            }
        }
        /// <summary>
        /// 根据id获取应用系统与接口关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public object GetApplicationInterfaceRelationById(string id)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (null != settings.SysMySqlDB)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                ApplicationInterfaceRelation info = ApplicationInterfaceRelationOperation.GetApplicationInterfaceRelationById(new Guid(id));
                return new JsonResult(info);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 根据id删除应用系统与接口关联关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public object DeleteApplicationInterfaceRelation(string id)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (null != settings.SysMySqlDB)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                ApplicationInterfaceRelation info = ApplicationInterfaceRelationOperation.GetApplicationInterfaceRelationById(new Guid(id));
                if (null != info)
                {
                    ApplicationInterfaceRelationOperation.DeleteApplicationInterfaceRelationById(new Guid(id));
                    return string.Format("删除【{0},{1},{2}】关联关系成功！", info.appname, info.interfacename, info.destinappname);
                }
                else
                    return string.Format("系统不存在【{0}】编号关联关系！", id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 分页获取应用系统与接口关联关系列表
        /// </summary>
        /// <param name="fileds"></param>
        /// <param name="key"></param>
        /// <param name="order"></param>
        /// <param name="ascOrdesc"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [Action]
        public object GetApplicationInterfaceRelationList(string fields, string key, string order, string ascOrdesc, int page, int rows)
        {
            try
            {
                SystemSettingBase settings = SystemSettingBase.CreateInstance();
                if (null != settings.SysMySqlDB)
                    ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                PageInfo pageinfo = new PageInfo()
                {
                    PageIndex = rows * (page - 1),
                    PageSize = rows,
                    RecCount = 0
                };
                if (string.IsNullOrEmpty(fields))
                    fields = "*";
                string whereCondition = string.Empty;
                if (!string.IsNullOrEmpty(key))
                    whereCondition = string.Format(" where appname like '%{0}%' or interfacename like '%{0}%' ", key);
                string orderby = string.Empty;
                if (!string.IsNullOrEmpty(order))
                    orderby = string.Format(" order by {0} {1} ", order, ascOrdesc);
                string limit = string.Format(" limit {0},{1}", pageinfo.PageIndex, pageinfo.PageSize);
                List<ApplicationInterfaceRelation> list = ApplicationInterfaceRelationOperation.GetApplicationInterfaceRealtionList(fields, whereCondition);
                pageinfo.RecCount = list.Count;
                List<ApplicationInterfaceRelation> target = ApplicationInterfaceRelationOperation.GetApplicationInterfaceRealtionList(fields, whereCondition, orderby, limit);
                GridResult<ApplicationInterfaceRelation> result = new GridResult<ApplicationInterfaceRelation>(target, pageinfo.RecCount);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
