using System;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.DalInterface;
using System.Collections.Generic;

namespace InterfaceMonitor.Frameworks.Logical
{
    /// <summary>
    /// Desciption:接口配置信息数据操作业务逻辑层
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public class InterfaceConfigInfoOperation
    {
        /// <summary>
        /// 接口配置信息数据新增或修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="mode"></param>
        public static void AddOrUpdateInterfaceConfigInfo(InterfaceConfigInfo entity, ModifierType mode)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                dp.AddOrUpdateInterfaceConfigInfo(cmd, entity, mode);
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
        /// 接口配置信息数据删除
        /// </summary>
        /// <param name="id">编号</param>
        public static void DeleteInterfaceConfigInfoById(Guid id)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                dp.DeleteInterfaceConfigInfoById(cmd, id);
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
        /// 根据Id编号获取接口配置信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public static InterfaceConfigInfo GetInterfaceConfigInfoById(Guid id)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            InterfaceConfigInfo entity = null;
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                entity = dp.GetInterfaceConfigInfoById(cmd, id);
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
            return entity;
        }

        public static InterfaceConfigInfo GetInterfaceConfigInfoWithApp(Guid id)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            InterfaceConfigInfo entity = null;
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                entity = dp.GetInterfaceConfigInfoWithApp(cmd, id);
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
            return entity;
        }
        /// <summary>
        /// 根据接口名、应用系统名和服务器地址获取配置信息
        /// </summary>
        /// <param name="interfaceName">接口名</param>
        /// <param name="applicationName">应用系统名</param>
        /// <param name="server">服务器地址</param>
        /// <returns></returns>
        public static InterfaceConfigInfo GetInterfaceConfigInfo(string interfaceName, string server)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            InterfaceConfigInfo info = null;
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetInterfaceConfigInfo(cmd, interfaceName, server);
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
            return info;
        }

        public static InterfaceConfigInfo GetInterfaceConfigInfo(string interfaceName, string appname, string server)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            InterfaceConfigInfo info = null;
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetInterfaceConfigInfo(cmd, interfaceName, appname, server);
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
            return info;
        }
        /// <summary>
        /// 根据接口名、应用系统编号获取配置信息
        /// </summary>
        /// <param name="interfaceName"></param>
        /// <param name="appid"></param>
        /// <returns></returns>
        public static InterfaceConfigInfo GetInterfaceConfigInfo(string interfaceName, Guid appid)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            InterfaceConfigInfo info = null;
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetInterfaceConfigInfo(cmd, interfaceName, appid);
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
            return info;
        }
        /// <summary>
        /// 获取接口配置信息列表
        /// </summary>
        /// <param name="fields">字段</param>
        /// <param name="whereCondition">where语句</param>
        /// <returns></returns>
        public static List<InterfaceConfigInfo> GetInterfaceConfigInfoList(string fields, string whereCondition)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            List<InterfaceConfigInfo> list = new List<InterfaceConfigInfo>();
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetInterfaceConfigInfoList(cmd, fields, whereCondition);
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
        /// 获取接口配置信息列表(带分页)
        /// </summary>
        /// <param name="fields">字段名</param>
        /// <param name="whereCondition">sql筛选语句</param>
        /// <param name="startIndex">下标</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public static List<InterfaceConfigInfo> GetInterfaceConfigInfoPageList(string fields, string whereCondition, int startIndex, int pageSize)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            List<InterfaceConfigInfo> list = new List<InterfaceConfigInfo>();
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetInterfaceConfigInfoPageList(cmd, fields, whereCondition, startIndex, pageSize);
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
        /// 自定义接口配置信息列表查询
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="whereCondition"></param>
        /// <param name="orderby"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static List<InterfaceConfigInfo> GetInterfaceConfigInfoByCondition(string fields, string whereCondition, string orderby, string limit)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            List<InterfaceConfigInfo> list = new List<InterfaceConfigInfo>();
            try
            {
                IInterfaceConfigInfo dp = DataProvider.DbInterfaceConfigDP;
                conn = DbConnOperation.CreateConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetInterfaceConfigInfoByCondition(cmd, fields, whereCondition, orderby, limit);
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
