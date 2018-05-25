using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InterfaceMonitor.Frameworks.Utility
{
    /// <summary>
    /// Description:数据库操作基类
    /// Author:WUWEI
    /// Date:2018/05/25
    /// </summary>
    public abstract class DatabaseOperation
    {
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public abstract void Open();
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public abstract void Close();
        /// <summary>
        /// 开始事务处理
        /// </summary>
        public abstract void BeginTransaction();
        /// <summary>
        /// 提交事务
        /// </summary>
        public abstract void CommitTransaction();
        /// <summary>
        /// 回滚事务
        /// </summary>
        public abstract void RollbackTransaction();
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public abstract int ExecuteSQL(string sqlString);
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <param name="cmdParams">命令参数</param>
        /// <returns>影响的记录数</returns>
        public abstract int ExecuteSQL(string sqlString, params IDataParameter[] cmdParams);
        /// <summary>
        /// 执行SQL语句，有返回值
        /// </summary>
        /// <param name="sqlString">SQL字符串</param>
        /// <returns>返回值</returns>
        public abstract object[] ReadDataValues(string sqlString);
        /// <summary>
        /// 创建DataReader
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public abstract IDataReader CreateDataReader(string cmdText);
        /// <summary>
        /// 向DataSet中增加DataTable
        /// </summary>
        /// <param name="dataset">所用的DataSet</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="tableName">DataSet中的DataTable表名</param>
        public abstract void AddDatasetTable(ref DataSet dataset, string cmdText, string tableName);
        /// <summary>
        /// 创建DataSet
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <param name="tableName">DataSet中的DataTable表名</param>
        /// <returns>返回DataSet</returns>
        public abstract DataSet CreateDataSet(string sqlString, string tableName);
        /// <summary>
        /// 创建DataSet
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>返回DataSet</returns>
        public abstract DataSet CreateDataSet(string sqlString);
        /// <summary>
        /// 从数据库中读取Blob字段
        /// </summary>
        /// <param name="blobcolumn">Bolb字段名</param>
        /// <param name="tableName">Bolb字段所在的数据库表名</param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public abstract byte[] SelectBlob(string blobcolumn, string tableName, string whereCondition);
        /// <summary>
        /// 更新数据库中的Blob字段
        /// </summary>
        /// <param name="blobValue">Blob的byte数组</param>
        /// <param name="blobColumn">Blob的字段名</param>
        /// <param name="tableName">Blob所在的数据库表</param>
        /// <param name="updateCondition">更新条件</param>
        public abstract void UpdateBlob(byte[] blobValue, string blobColumn, string tableName, string updateCondition);
        /// <summary>
        /// 创建DataTable
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <returns></returns>
        public abstract DataTable CreateDataTable(string cmdText);
        /// <summary>
        /// 更新数DataSet到数据库中
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="dataset"></param>
        /// <param name="tableName"></param>
        public abstract void UpdateDataset(string queryString, DataSet dataset, string tableName);

        public abstract object GetSingle(string sqlString, params IDataParameter[] cmdParams);
        /// <summary>
        /// 判断数据库是否存在sql中的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool Exists(string sql)
        {
            object obj = GetSingle(sql);
            if (Object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return false;
            else
                return true;
        }
        /// <summary>
        /// 判断数据库是否存在sql中的查询
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="cmdParams">查询参数</param>
        /// <returns></returns>
        public bool Exists(string sql, params IDataParameter[] cmdParams)
        {
            object obj = GetSingle(sql, cmdParams);
            if (Object.Equals(obj, null) || Object.Equals(obj, System.DBNull.Value))
                return false;
            else
                return true;
        }
        public abstract void UpdateDataSet(string queryString, DataSet dataset, string tableName, bool blnTran);
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <param name="cmdParams">命令参数</param>
        /// <returns>影响的记录数</returns>
        public abstract DataSet CreateDataSet(string sqlString, params IDataParameter[] cmdParams);

        public abstract int ExecuteSqlByProc(string cmdText, params IDataParameter[] cmdParams);
    }
}
