using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMonitor.Frameworks.Utility
{
    /// <summary>
    /// Description:MySql数据库配置类实体
    /// Author:WUWEI
    /// Date:2018/05/25
    /// </summary>
    public class MySqlSettings
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        private string _server;
        public string Server
        {
            get { return _server; }
            set { this._server = value; }
        }
        /// <summary>
        /// 数据库
        /// </summary>
        private string _database;
        public string Database
        {
            get { return _database; }
            set { this._database = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        private string _uid;
        public string Uid
        {
            get { return _uid; }
            set { this._uid = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        private string _password;
        public string Password
        {
            get { return _password; }
            set { this._password = value; }
        }
        /// <summary>
        /// 字符集(有效的设置字符集可避免程序客户端和数据库字符集差异所引起的中文乱码问题)
        /// </summary>
        private string _charset;
        public string CharSet
        {
            get { return _charset; }
            set { this._charset = value; }
        }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Server))
                    sb.AppendFormat("Server={0};", this.Server);
                if (!string.IsNullOrEmpty(Database))
                    sb.AppendFormat("Database={0};", this.Database);
                if (!string.IsNullOrEmpty(CharSet))
                    sb.AppendFormat("Charset={0};", CharSet);
                if (!string.IsNullOrEmpty(Uid))
                    sb.AppendFormat("Uid={0};", this.Uid);
                if (!string.IsNullOrEmpty(Password))
                    sb.AppendFormat("Pwd={0}", this.Password);
                return sb.ToString();
            }
        }
    }
}
