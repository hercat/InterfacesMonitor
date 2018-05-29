using InterfaceMonitor.Frameworks.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.DalInterface;
using System.Data;

namespace InterfaceMonitor.Frameworks.Logical
{
    /// <summary>
    /// Description:接口实时状态业务逻辑层
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public class InterfaceRealtimeInfoOperation
    {
        /// <summary>
        /// 接口实时状态新增或修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="mode"></param>
        public static void AddOrUpdateInterceRealtimeInfo(InterfaceRealtimeInfo entity, ModifierType mode)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IInterfaceRealtimeInfo dp = DataProvider.DbInterfaceRealtimeDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                dp.AddOrUpdateInterceRealtimeInfo(cmd, entity, mode);
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
        /// 根据Id编号删除接口实时状态信息
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteInterfaceRealtimeInfoById(Guid id)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IInterfaceRealtimeInfo dp = DataProvider.DbInterfaceRealtimeDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                dp.DeleteInterfaceRealtimeInfoById(cmd, id);
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
        /// 获取实时状态信息列表
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public static List<InterfaceRealtimeInfo> GetInterfaceRealtimeInfoList(string fields, string whereCondition)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            List<InterfaceRealtimeInfo> list = new List<InterfaceRealtimeInfo>();
            try
            {
                IInterfaceRealtimeInfo dp = DataProvider.DbInterfaceRealtimeDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetInterfaceRealtimeInfoList(cmd, fields, whereCondition);
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
