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
    public class ApplicationRelationOperation
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static bool AddOrUpdateApplicationRelation(ApplicationRelation info, ModifierType mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationRelation dp = DataProvider.DbApplicationRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateApplicationRelation(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("AddOrUpdateApplicationRelation()发生错误,错误信息如下:{0}", ex));
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

        public static bool DeleteApplicationRelationByid(Guid appid)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationRelation dp = DataProvider.DbApplicationRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteApplicationRelationByid(cmd, appid);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("DeleteApplicationRelationByid()发生错误,错误信息如下:{0}", ex));
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

        public static ApplicationRelation GetApplicationRelationById(Guid appid)
        {
            ApplicationRelation info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IApplicationRelation dp = DataProvider.DbApplicationRelationDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetApplicationRelationById(cmd, appid);
                trans.Commit();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetApplicationRelationById()发生错误,错误信息如下:{0}", ex));
                if (trans != null)
                    trans.Rollback();
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }
    }
}
