﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;

namespace InterfaceMonitor.Frameworks.BizProcess
{
    /// <summary>
    /// Description:接口配置相关业务封装处理方法类
    /// Author:WUWEI
    /// Date:2017/05/29
    /// </summary>
    public class InterfaceConfigInitBizProcess
    {
        /// <summary>
        /// 接口初始化业务逻辑方法
        /// </summary>
        /// <param name="interfaceName">接口名</param>
        /// <param name="applicationName">应用系统名</param>
        /// <param name="server">服务器地址</param>
        /// <param name="user">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="charger">负责人</param>
        /// <param name="phone">负责人联系号码</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="path">帮助文档存放路径</param>
        /// <param name="descript">描述</param>
        public static void SaveInterfaceInitial(string interfaceName, string applicationName, string server, string user, string userPwd, string charger, string phone, int timeout, string path, string descript,string urlAddress)
        {
            //生成接口编号id
            Guid id = Guid.NewGuid();
            //判断接口配置信息是否存在，如果不存在则新增
            if (InterfaceConfigInfoOperation.GetInterfaceConfigInfo(interfaceName, applicationName, server) == null)
            {
                InterfaceConfigInfo config = new InterfaceConfigInfo();
                config.Id = id;
                config.InterfaceName = interfaceName;
                config.ApplicationName = applicationName;
                config.ServerAddress = server;
                config.ServerUser = user;
                config.UserPwd = userPwd;
                config.PersonOfChargeName = charger;
                config.PersonOfChargePhone = phone;
                config.ConnectedTimeout = timeout;
                config.DocumentHelpPath = path;
                config.UrlAddress = urlAddress;
                config.Description = descript;
                config.CreateTime = DateTime.Now;

                InterfaceRealtimeInfo realtime = new InterfaceRealtimeInfo();
                realtime.Id = id;
                realtime.InterfaceName = interfaceName;
                realtime.ApplicationName = applicationName;
                realtime.ServerAddress = server;
                realtime.StateCode = 0;
                realtime.UpdateTime = DateTime.Now;

                InterfaceConfigInfoOperation.AddOrUpdateInterfaceConfigInfo(config, ModifierType.Add);
                InterfaceRealtimeInfoOperation.AddOrUpdateInterceRealtimeInfo(realtime, ModifierType.Add);
            }
        }
        /// <summary>
        /// 接口更新业务逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <param name="interfaceName"></param>
        /// <param name="applicationName"></param>
        /// <param name="server"></param>
        /// <param name="user"></param>
        /// <param name="userPwd"></param>
        /// <param name="charger"></param>
        /// <param name="phone"></param>
        /// <param name="timeout"></param>
        /// <param name="path"></param>
        /// <param name="descript"></param>
        public static void UpdateInterfaceConfigInfo(string id,string interfaceName, string applicationName, string server, string user, string userPwd, string charger, string phone, int timeout, string path, string descript,string urlAddress)
        {
            Guid newid = new Guid(id);
            //判断接口配置信息是否存在，如果不存在则新增
            if (InterfaceConfigInfoOperation.GetInterfaceConfigInfo(interfaceName, applicationName, server) != null)
            {
                InterfaceConfigInfo config = new InterfaceConfigInfo();
                config.Id = newid;
                config.InterfaceName = interfaceName;
                config.ApplicationName = applicationName;
                config.ServerAddress = server;
                config.ServerUser = user;
                config.UserPwd = userPwd;
                config.PersonOfChargeName = charger;
                config.PersonOfChargePhone = phone;
                config.ConnectedTimeout = timeout;
                config.DocumentHelpPath = path;
                config.Description = descript;
                config.UrlAddress = urlAddress;
                config.CreateTime = DateTime.Now;

                InterfaceRealtimeInfo realtime = new InterfaceRealtimeInfo();
                realtime.Id = newid;
                realtime.InterfaceName = interfaceName;
                realtime.ApplicationName = applicationName;
                realtime.ServerAddress = server;
                realtime.StateCode = 0;
                realtime.UpdateTime = DateTime.Now;

                InterfaceConfigInfoOperation.AddOrUpdateInterfaceConfigInfo(config, ModifierType.Update);
                InterfaceRealtimeInfoOperation.AddOrUpdateInterceRealtimeInfo(realtime, ModifierType.Update);
            }
        }
        /// <summary>
        /// 删除接口配置信息（同时删除对应的实时状态表中信息）
        /// </summary>
        /// <param name="interfaceName"></param>
        /// <param name="applicationName"></param>
        /// <param name="server"></param>
        public static void DeleteInterfaceConfigInfo(string interfaceName, string applicationName, string server)
        {
            InterfaceConfigInfo info = InterfaceConfigInfoOperation.GetInterfaceConfigInfo(interfaceName, applicationName, server);
            if (info != null)
            {
                InterfaceConfigInfoOperation.DeleteInterfaceConfigInfoById(info.Id);
                InterfaceRealtimeInfo realtime = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfo(info.Id);
                if (realtime != null)
                    InterfaceRealtimeInfoOperation.DeleteInterfaceRealtimeInfoById(info.Id);
            }
        }
        /// <summary>
        /// 根据id删除接口配置信息（同时删除对应的实时状态表中信息）
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteInterfaceConfigInfoById(string id)
        {
            InterfaceConfigInfo info = InterfaceConfigInfoOperation.GetInterfaceConfigInfoById(new Guid(id));
            if (null != info)
            {
                InterfaceConfigInfoOperation.DeleteInterfaceConfigInfoById(info.Id);
                InterfaceRealtimeInfo realtime = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfo(info.Id);
                if (null != realtime)
                    InterfaceRealtimeInfoOperation.DeleteInterfaceRealtimeInfoById(info.Id);           
            }
        }
    }
}
