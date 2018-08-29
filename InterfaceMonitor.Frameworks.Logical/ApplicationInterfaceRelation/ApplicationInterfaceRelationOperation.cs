using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data;
using System.Reflection;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.DalInterface;

namespace InterfaceMonitor.Frameworks.Logical
{
    public class ApplicationInterfaceRelationOperation
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static bool AddOrUpdateApplicationInterfaceRelation(ApplicationInterfaceRelation info, ModifierType mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationInterfaceRelation dp = DataProvider.DbApplicationInterfaceRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateApplicationInterfaceRelation(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("AddOrUpdateApplicationInterfaceRelation()发生错误,错误信息如下:{0}", ex));
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

        public static ApplicationInterfaceRelation GetApplicationInterfaceRelationById(Guid id)
        {
            ApplicationInterfaceRelation info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationInterfaceRelation dp = DataProvider.DbApplicationInterfaceRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetApplicationInterfaceRelationById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationInterfaceRelationById()发生错误,错误信息如下:{0}", ex));
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

        public static ApplicationInterfaceRelation GetApplicationInterfaceRelation(Guid appid, Guid interfaceid)
        {
            ApplicationInterfaceRelation info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationInterfaceRelation dp = DataProvider.DbApplicationInterfaceRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetApplicationInterfaceRelation(cmd, appid, interfaceid);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationInterfaceRelation()发生错误,错误信息如下:{0}", ex));
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

        public static bool DeleteApplicationInterfaceRelationById(Guid id)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationInterfaceRelation dp = DataProvider.DbApplicationInterfaceRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteApplicationInterfaceRelationById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("DeleteApplicationInterfaceRelationById()发生错误,错误信息如下:{0}", ex));
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

        public static bool DeleteApplicationInterfaceRelation(Guid appid, Guid interfaceid)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationInterfaceRelation dp = DataProvider.DbApplicationInterfaceRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteApplicationInterfaceRelation(cmd, appid, interfaceid);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("DeleteApplicationInterfaceRelation()发生错误,错误信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }

        public static List<ApplicationInterfaceRelation> GetApplicationInterfaceRealtionList(string fields, string condition)
        {
            List<ApplicationInterfaceRelation> list = new List<ApplicationInterfaceRelation>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationInterfaceRelation dp = DataProvider.DbApplicationInterfaceRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.BeginTransaction();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetApplicationInterfaceRealtionList(cmd, fields, condition);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationInterfaceRealtionList()发生错误,错误信息如下:{0}", ex));
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

        public static List<ApplicationInterfaceRelation> GetApplicationInterfaceRealtionList(string fileds, string condition, string orderby, string limit)
        {
            List<ApplicationInterfaceRelation> list = new List<ApplicationInterfaceRelation>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationInterfaceRelation dp = DataProvider.DbApplicationInterfaceRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetApplicationInterfaceRealtionList(cmd, fileds, condition, orderby, limit);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationInterfaceRelationList()发生错误,错误信息如下:{0}", ex));
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
    }
}
