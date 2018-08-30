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
using log4net;

namespace InterfaceMonitor.Frameworks.Logical
{
    /// <summary>
    /// Description:数据提供对象逻辑层
    /// Author:WUWEI
    /// Date:2018/05/28
    /// </summary>
    public class DataProvider
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
                        log.Error(string.Format("DataProvider不存在{0}数据提供对象！", dpname));
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
                        log.Error(string.Format("DataProvider不存在{0}数据提供对象！", dpname));
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
                        log.Error(string.Format("DataProvider不存在{0}数据提供对象！", dpname));
                    }
                    _dbInterfaceRealtimeDP = (IInterfaceRealtimeInfo)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbInterfaceRealtimeDP;
            }
        }
        #endregion

        #region 接口异常日志信息数据提供对象
        private static IInterfaceExceptionlog _dbInterfaceExceptionlogDP;
        public static IInterfaceExceptionlog DbInterfaceExceptionlogDP
        {
            get
            {
                if (_dbInterfaceExceptionlogDP == null)
                {
                    string dpname = "DbInterfaceExceptionlogDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        //后续增加日志处理
                        log.Error(string.Format("DataProvider不存在{0}数据提供对象！", dpname));
                    }
                    _dbInterfaceExceptionlogDP = (IInterfaceExceptionlog)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbInterfaceExceptionlogDP;
            }
        }
        #endregion

        #region 应用系统数据提供对象
        private static IApplicationSysInfo _dbApplicationSysInfoDP;
        public static IApplicationSysInfo DbApplicationSysInfoDP
        {
            get
            {
                if (_dbApplicationSysInfoDP == null)
                {
                    string dpname = "DbApplicationSysInfoDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        //后续增加日志处理
                        log.Error(string.Format("DataProvider不存在{0}数据提供对象！", dpname));
                    }
                    _dbApplicationSysInfoDP = (IApplicationSysInfo)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbApplicationSysInfoDP;
            }
        }
        #endregion

        #region 应用系统接口关系数据提供对象
        private static IApplicationInterfaceRelation _dbApplicationInterfaceRelationDP;
        public static IApplicationInterfaceRelation DbApplicationInterfaceRelationDP
        {
            get
            {
                if (_dbApplicationInterfaceRelationDP == null)
                {
                    string dpname = "DbApplicationInterfaceRelationDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        //后续增加日志处理
                        log.Error(string.Format("DataProvider不存在{0}数据提供对象！", dpname));
                    }
                    _dbApplicationInterfaceRelationDP = (IApplicationInterfaceRelation)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbApplicationInterfaceRelationDP;
            }
        }
        #endregion

        #region 应用系统关系数据提供对象
        private static IApplicationRelation _dbApplicationRelationDP;
        public static IApplicationRelation DbApplicationRelationDP
        {
            get
            {
                if (_dbApplicationRelationDP == null)
                {
                    string dpname = "DbApplicationRelationDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        //后续增加日志处理
                        log.Error(string.Format("DataProvider不存在{0}数据提供对象！", dpname));
                    }
                    _dbApplicationRelationDP = (IApplicationRelation)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbApplicationRelationDP;
            }
        }
        #endregion

    }
}
