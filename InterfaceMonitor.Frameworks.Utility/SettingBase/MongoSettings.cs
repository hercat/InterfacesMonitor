using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMonitor.Frameworks.Utility
{
    /// <summary>
    /// Description:MongoDB数据库配置类实体
    /// Author:WUWEI
    /// Date:2018/05/25
    /// </summary>
    public class MongoSettings
    {
        /// <summary>
        /// mongodb服务器地址
        /// </summary>
        private string _mongoIP;
        public string MongoIP
        {
            get { return _mongoIP; }
            set { this._mongoIP = value; }
        }
        /// <summary>
        /// mongodb服务器端口号
        /// </summary>
        private string _mongoPort;
        public string MongoPort
        {
            get { return _mongoPort; }
            set { this._mongoPort = value; }
        }
        /// <summary>
        /// mongodb数据库名称
        /// </summary>
        private string _mongodbName;
        public string MongodbName
        {
            get { return _mongodbName; }
            set { this._mongodbName = value; }
        }
        /// <summary>
        /// mongodb数据库用户
        /// </summary>
        private string _mongoUser;
        public string MongoUser
        {
            get { return _mongoUser; }
            set { this._mongoUser = value; }
        }
        /// <summary>
        /// mongodb数据库用户密码
        /// </summary>
        private string _mongoPwd;
        public string MongoPwd
        {
            get { return _mongoPwd; }
            set { this._mongoPwd = value; }
        }
    }
}
