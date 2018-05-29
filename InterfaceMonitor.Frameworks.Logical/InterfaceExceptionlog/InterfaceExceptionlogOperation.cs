using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.DalInterface;
using System.Data;

namespace InterfaceMonitor.Frameworks.Logical
{
    /// <summary>
    /// Description:接口异常日志信息业务逻辑层
    /// Author:WUWEI
    /// Date:2018/05/29
    /// </summary>
    public class InterfaceExceptionlogOperation
    {
        /// <summary>
        /// 新增接口异常日志信息
        /// </summary>
        /// <param name="info"></param>
        public static void AddInterfaceExceptionlogInfo(InterfaceExceptionlog info)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IInterfaceExceptionlog dp = DataProvider.DbInterfaceExceptionlogDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                dp.AddInterfaceExceptionlogInfo(cmd, info);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (null != trans)
                    trans.Rollback();
            }
            finally
            {
                if (null != conn)
                    conn.Close();
            }
        }
        /// <summary>
        /// 获取接口异常日志信息列表
        /// </summary>
        /// <param name="fields">字段名</param>
        /// <param name="whereCondition">筛选条件</param>
        /// <returns></returns>
        public static List<InterfaceExceptionlog> GetInterfaceExceptionlogList(string fields, string whereCondition)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            List<InterfaceExceptionlog> list = new List<InterfaceExceptionlog>();
            try
            {
                IInterfaceExceptionlog dp = DataProvider.DbInterfaceExceptionlogDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetInterfaceExceptionlogList(cmd, fields, whereCondition);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (null != trans)
                    trans.Rollback();
            }
            finally
            {
                if (null != conn)
                    conn.Close();
            }
            return list;
        }
        /// <summary>
        /// 获取接口异常日志信息列表(带分页)
        /// </summary>
        /// <param name="fields">字段名</param>
        /// <param name="whereCondition">sql筛选条件</param>
        /// <param name="pageIndex">页面下标</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        public static List<InterfaceExceptionlog> GetInterfaceExceptionlogPageList(string fields, string whereCondition, int pageIndex, int pageSize)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            List<InterfaceExceptionlog> list = new List<InterfaceExceptionlog>();
            try
            {
                IInterfaceExceptionlog dp = DataProvider.DbInterfaceExceptionlogDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetInterfaceExceptionlogPageList(cmd, fields, whereCondition, pageIndex, pageSize);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (null != trans)
                    trans.Rollback();
            }
            finally
            {
                if (null != conn)
                    conn.Close();
            }
            return list;
        }
    }
}
