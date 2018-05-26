using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InterfaceMonitor.Frameworks.Utility
{
    /// <summary>
    /// Description:Mongodb数据库帮助类
    /// Author:WUWEI
    /// Date:2018/05/25
    /// </summary>
    public class MongodbHelper
    {
        #region 单例模式
        /// <summary>
        /// 定义私有静态变量
        /// </summary>
        private static MongodbHelper _instance = null;
        /// <summary>
        /// 定义一个多线程锁标识，确保线程的安全
        /// </summary>
        private static readonly object locker = new object();
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private MongodbHelper() { }
        /// <summary>
        /// 定义实例的全局访问点
        /// </summary>
        /// <returns></returns>
        public static MongodbHelper CreateInstance()
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    if (_instance == null)
                    {
                        _instance = new MongodbHelper();
                    }
                }
            }
            return _instance;
        }
        #endregion
        /// <summary>
        /// mongodb数据库连接字符串
        /// </summary>
        private string _mongodbConnString;
        public string MongodbConnString
        {
            get { return _mongodbConnString; }
            set { this._mongodbConnString = value; }
        }
        public static MongoServer CreateMongoServer(string mongodbConnString)
        {
            return MongoServer.Create(mongodbConnString);
        }
    }
}
