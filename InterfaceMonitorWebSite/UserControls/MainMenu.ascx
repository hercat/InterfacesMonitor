<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="InterfaceMonitorWebSite.UserControls.MainMenu" %>
<link href="../css/MainMenuSkin.css" rel="stylesheet" />
<div id="nav">
    <ul>
        <li><a>实时状态</a>
            <dl>
                <dd />   
                <dt>
                    <a href="../InterfaceRealtime/applicationRealtimeInfo.aspx">系统状态</a>
                </dt>
                <dd></dd>
                <dt>
                    <a href="/InterfaceRealtime/InterfaceRealtimeInfo.aspx">实时状态</a>
                </dt>
                <dd />
            </dl>
        </li>
        <li><a>基础数据管理</a>
            <dl>
                <dd />
                <dt>
                    <a href="../applicationSysInfo/ApplicationInfoManager.aspx">应用配置</a>
                </dt>
                <dd></dd>
                <dt>
                    <a href="/InterfaceConfigInfo/InterfaceConfiguration.aspx">接口配置</a>
                </dt>                
                <dd />
            </dl>
        </li>
        <li><a>应用接口关系管理</a>
            <dl>
                <dd></dd>
                <dt>
                    <a href="../applicationSysInfo/ApplicationSysInfo.aspx">关联关系维护</a>
                </dt>
                <dd></dd>
                <dt>
                    <a href="../applicationSysInfo/ApplicationInterfaceRelation.aspx">关联关系</a>
                </dt>
                <dd></dd>
            </dl>
        </li>        
    </ul>
</div>