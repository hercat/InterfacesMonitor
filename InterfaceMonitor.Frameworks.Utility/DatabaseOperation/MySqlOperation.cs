using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace InterfaceMonitor.Frameworks.Utility
{
    /// <summary>
    /// Description:MySql数据库操作帮助类
    /// Author:WUWEI
    /// Date：2018/05/24
    /// </summary>
    public class MySqlOperation : DatabaseOperation
    {
        private MySql.Data.MySqlClient.MySqlConnection connection;
        private MySql.Data.MySqlClient.MySqlTransaction transaction;
        private bool IsTransaction = false;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString"></param>
        public MySqlOperation(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
        }
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public override void Open()
        {
            if (connection.State == ConnectionState.Open)
                return;
            else if (connection.State == ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }
            else
                connection.Open();
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public override void Close()
        {
            if (connection.State == ConnectionState.Closed)
                return;
            else
                connection.Close();
        }
        /// <summary>
        /// 开始事务处理
        /// </summary>
        public override void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
            this.IsTransaction = true;
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public override void CommitTransaction()
        {
            transaction.Commit();
            this.IsTransaction = false;
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public override void RollbackTransaction()
        {
            transaction.Rollback();
            this.IsTransaction = false;
        }
        /// <summary>
        /// 执行SQL语句，返回影响行数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public override int ExecuteSQL(string sqlString)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            if (IsTransaction)
                command.Transaction = transaction;
            command.CommandText = sqlString;
            int ExecuteCount = command.ExecuteNonQuery();
            return ExecuteCount;
        }
        public override int ExecuteSQL(string sqlString, params IDataParameter[] cmdParams)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 创建DataReader
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>返回DataReader</returns>
        public override IDataReader CreateDataReader(string cmdText)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = cmdText;
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// 执行SQL，有返回值
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>返回值</returns>
        public override object[] ReadDataValues(string sqlString)
        {
            MySqlDataReader reader = (MySqlDataReader)CreateDataReader(sqlString);
            object[] values = new object[reader.FieldCount];
            reader.Read();
            reader.GetValues(values);
            reader.Close();
            return values;
        }
        /// <summary>
        /// 向DataSet中增加DataTable
        /// </summary>
        /// <param name="dataset">所用的DataSet</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="tableName">Table名</param>
        public override void AddDatasetTable(ref DataSet dataset, string cmdText, string tableName)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            if (IsTransaction)
                command.Transaction = transaction;
            command.CommandText = cmdText;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            if (tableName.Length == 0)
                adapter.Fill(dataset);
            else
                adapter.Fill(dataset, tableName);
            dataset.Tables[dataset.Tables.Count - 1].ExtendedProperties.Add("SQL", cmdText);
            adapter.Dispose();
        }
        /// <summary>
        /// 创建DataSet
        /// </summary>
        /// <param name="sqlString">SQL命令</param>
        /// <param name="tableName">Table名</param>
        /// <returns></returns>
        public override DataSet CreateDataSet(string sqlString, string tableName)
        {
            DataSet dataset = new DataSet();
            AddDatasetTable(ref dataset, sqlString, tableName);
            return dataset;
        }
        /// <summary>
        /// 创建DataSet
        /// </summary>
        /// <param name="sqlString">SQL命令</param>
        /// <returns>返回DataSet</returns>
        public override DataSet CreateDataSet(string sqlString)
        {
            return CreateDataSet(sqlString, "");
        }
        /// <summary>
        /// 从数据库中读取Blob字段
        /// </summary>
        /// <param name="blobcolumn">Blob字段名</param>
        /// <param name="tableName">Blob字段所在数据库表</param>
        /// <param name="whereCondition">读取时的筛选条件</param>
        /// <returns>Blob的byte数组</returns>
        public override byte[] SelectBlob(string blobcolumn, string tableName, string whereCondition)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select {0} from {1} ", blobcolumn, tableName);
            if (!string.IsNullOrEmpty(whereCondition))            
                sb.AppendLine(whereCondition);
            MySqlCommand command = new MySqlCommand(sb.ToString(), connection);
            MySqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess);
            if (!reader.Read())
                return null;
            MemoryStream BlobStream = new MemoryStream();
            BinaryWriter BlobWriter = new BinaryWriter(BlobStream);
            int BufferSize = 8192;
            byte[] OutBytes = new byte[BufferSize];
            long StartIndex = 0;
            long ReadValueSize = reader.GetBytes(0, StartIndex, OutBytes, 0, BufferSize);
            while (ReadValueSize == BufferSize)
            {
                BlobWriter.Write(OutBytes);
                BlobWriter.Flush();
                StartIndex += BufferSize;
                ReadValueSize = reader.GetBytes(0, StartIndex, OutBytes, 0, BufferSize);
            }
            if (ReadValueSize > 0)
                BlobWriter.Write(OutBytes, 0, (int)ReadValueSize);
            BlobWriter.Flush();
            BlobWriter.Close();
            byte[] ByteValues = BlobStream.ToArray();
            BlobStream.Close();
            command.Cancel();
            reader.Close();
            return ByteValues;
        }
        /// <summary>
        /// 更新数据库中的Blob字段
        /// </summary>
        /// <param name="blobValue">Blob的byte数组</param>
        /// <param name="blobColumn">Blob的字段名</param>
        /// <param name="tableName">Blob所在的数据库表</param>
        /// <param name="updateCondition">更新条件</param>
        public override void UpdateBlob(byte[] blobValue, string blobColumn, string tableName, string updateCondition)
        {
            //if (connection.State == ConnectionState.Closed)
            //    connection.Open();
            //StringBuilder sb = new StringBuilder();
        }
        /// <summary>
        /// 创建DataTable
        /// </summary>
        /// <param name="cmdText">Sql命令文本</param>
        /// <returns>返回DataTable</returns>
        public override DataTable CreateDataTable(string cmdText)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            if (IsTransaction)
                command.Transaction = transaction;
            command.CommandText = cmdText;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dt.ExtendedProperties.Add("SQL", cmdText);
            adapter.Dispose();
            return dt;
        }

        public override void UpdateDataset(string queryString, DataSet dataset, string tableName)
        {
            throw new NotImplementedException();
        }

        public override object GetSingle(string sqlString, params IDataParameter[] cmdParams)
        {
            throw new NotImplementedException();
        }

        public override void UpdateDataSet(string queryString, DataSet dataset, string tableName, bool blnTran)
        {
            throw new NotImplementedException();
        }

        public override DataSet CreateDataSet(string sqlString, params IDataParameter[] cmdParams)
        {
            throw new NotImplementedException();
        }

        public override int ExecuteSqlByProc(string cmdText, params IDataParameter[] cmdParams)
        {
            throw new NotImplementedException();
        }
    }
}
