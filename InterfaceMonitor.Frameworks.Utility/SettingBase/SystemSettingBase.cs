using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMonitor.Frameworks.Utility
{
    /// <summary>
    /// Description:系统配置项，保存于XMl文件
    /// Author:WUWEI
    /// Date:2018/05/25
    /// </summary>
    public class SystemSettingBase : SettingBase
    {
        /// <summary>
        /// 定义一个静态变量来保存类的实例
        /// </summary>
        private static SystemSettingBase _instance = null;
        /// <summary>
        /// 定义一个标识来确保线程安全
        /// </summary>
        private static readonly object locker = new object();
        /// <summary>
        /// 定义私有构造函数，使得外界不能通过构造函数来创建该类实例
        /// </summary>
        private SystemSettingBase() { }

        #region 公有属性
        /// <summary>
        /// 定义一个公有属性成员作为该类的全局访问点
        /// </summary>
        public static SystemSettingBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    SystemSettingBase temp = new SystemSettingBase();
                    _instance = SystemSettingBase.Load(temp, LocationType.Application) as SystemSettingBase;
                }
                return _instance;
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 定义一个公共方法作为该类的全局访问点
        /// </summary>
        /// <returns></returns>
        public static SystemSettingBase CreateInstance()
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    if (_instance == null)
                    {
                        SystemSettingBase temp = new SystemSettingBase();
                        _instance = SystemSettingBase.Load(temp, LocationType.Application) as SystemSettingBase;
                    }
                }
            }
            return _instance;
        }
        #endregion

        #region MySql数据库配置信息
        private MySqlSettings _sysMySqlDB = new MySqlSettings();
        public MySqlSettings SysMySqlDB
        {
            get { return _sysMySqlDB; }
            set { this._sysMySqlDB = value; }
        }
        #endregion

        #region Mongodb数据库配置信息
        private MongoSettings _sysMongodb = new MongoSettings();
        public MongoSettings SysMongodb
        {
            get { return _sysMongodb; }
            set { this._sysMongodb = value; }
        }
        #endregion
    }
}
