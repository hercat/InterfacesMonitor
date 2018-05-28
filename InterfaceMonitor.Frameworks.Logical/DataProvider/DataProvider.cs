using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Utility;
using InterfaceMonitor.Frameworks.DalInterface;
using System.Reflection;

namespace InterfaceMonitor.Frameworks.Logical
{
    /// <summary>
    /// Description:数据提供对象逻辑层
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public class DataProvider
    {
        #region 数据库连接数据提供对象
        /// <summary>
        /// 数据库连接数据提供对象
        /// </summary>
        private static IDbConn _dbConnDP;
        public static IDbConn DbConnDP
        {
            get
            {
                if (_dbConnDP == null)
                {
                    string dpname = "DbConnDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        //后续增加日志处理
                    }
                    _dbConnDP = (IDbConn)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbConnDP;
            }
        }
        #endregion
        #region 接口配置信息数据提供对象
        /// <summary>
        /// 接口配置信息数据提供对象
        /// </summary>
        private static IInterfaceConfigInfo _dbInterfaceConfigInfoDP;
        public static IInterfaceConfigInfo DbInterfaceConfigDP
        {
            get
            {
                if (_dbInterfaceConfigInfoDP == null)
                {
                    string dpname = "DbInterfaceConfigInfoDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        //后续增加日志处理
                    }
                    _dbInterfaceConfigInfoDP = (IInterfaceConfigInfo)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbInterfaceConfigInfoDP;
            }
        }
        #endregion

        #region 接口实时状态数据提供对象
        private static IInterfaceRealtimeInfo _dbInterfaceRealtimeDP;
        public static IInterfaceRealtimeInfo DbInterfaceRealtimeDP
        {
            get
            {
                if (_dbInterfaceRealtimeDP == null)
                {
                    string dpname = "DbInterfaceRealtimeDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        //后续增加日志处理
                    }
                    _dbInterfaceRealtimeDP = (IInterfaceRealtimeInfo)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbInterfaceRealtimeDP;
            }
        }
        #endregion
    }
}
