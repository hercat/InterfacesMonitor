using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using log4net;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.DalInterface;

namespace InterfaceMonitor.Frameworks.Logical
{
    public class ApplicationSysInfoLogical
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static bool AddOrUpdateApplicationSysInfo(ApplicationSysInfo info, ModifierType mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationSysInfo dp = DataProvider.DbApplicationSysInfoDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateApplicationSysInfo(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("AddOrUpdateApplicationSysInfo()发生错误,异常信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }

        public static ApplicationSysInfo GetApplicationSysInfoById(Guid id)
        {
            ApplicationSysInfo info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationSysInfo dp = DataProvider.DbApplicationSysInfoDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetApplicationSysInfoById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationSysInfoById()发生错误,异常信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }

        public static bool DeleteApplicationSysInfoById(Guid id)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationSysInfo dp = DataProvider.DbApplicationSysInfoDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteApplicationSysInfoById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("DeleteApplicationSysInfoById()发生错误,异常信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }

        public static ApplicationSysInfo GetApplicationSysInfo(string name, string server)
        {
            ApplicationSysInfo info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationSysInfo dp = DataProvider.DbApplicationSysInfoDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                info = dp.GetApplicationSysInfo(cmd, name, server);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationSysInfo()发生错误,异常信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }

        public static List<ApplicationSysInfo> GetApplicationSysInfoList(string fields, string condition)
        {
            List<ApplicationSysInfo> list = new List<ApplicationSysInfo>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationSysInfo dp = DataProvider.DbApplicationSysInfoDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                list = dp.GetApplicationSysInfoList(cmd, fields, condition);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationSysInfoList()发生错误,异常信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return list;
        }

        public static List<ApplicationSysInfo> GetApplicationSysInfoList(string fileds, string condition,string orderby, string limit)
        {
            List<ApplicationSysInfo> list = new List<ApplicationSysInfo>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationSysInfo dp = DataProvider.DbApplicationSysInfoDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                list = dp.GetApplicationSysInfoList(cmd, fileds, condition, orderby, limit);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationSysInfoList()发生错误,异常信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return list;
        }
        /// <summary>
        /// 应用系统监控统计数据
        /// </summary>
        /// <returns></returns>
        public static DataTable GetApplicationInfoStatics()
        {
            DataTable dt = new DataTable();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationSysInfo dp = DataProvider.DbApplicationSysInfoDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                dt = dp.GetApplicationInfoStatics(cmd);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationInfoStatics()发生错误,错误信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return dt;
        }

        public static DataTable GetApplicationInfoStaticsDetails(Guid id)
        {
            DataTable dt = new DataTable();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationSysInfo dp = DataProvider.DbApplicationSysInfoDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                dt = dp.GetApplicationInfoStaticsDetails(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationInfoStaticsDetails()发生错误,错误信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return dt;
        }
    }
}
