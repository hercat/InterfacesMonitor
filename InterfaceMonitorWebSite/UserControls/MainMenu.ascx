<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="InterfaceMonitorWebSite.UserControls.MainMenu" %>
<link href="../css/MainMenuSkin.css" rel="stylesheet" />
<div id="nav">
    <ul>
        <li><a>接口实时状态</a>
            <dl>
                <dd />                                    
                <dt>
                    <a href="/InterfaceRealtime/InterfaceRealtimeInfo.aspx">实时状态</a>
                </dt>
                <dd />
            </dl>
        </li>        
        <li><a>信息配置</a>
            <dl>
                <dd />
                <dt>
                    <a href="/InterfaceConfigInfo/InterfaceConfiguration.aspx">接口配置</a>
                </dt>
                <%--<dt>
                    <a href="/Config/SysConfiguration.aspx">系统配置</a>
                </dt>--%>
                <dd />
            </dl>
        </li>
    </ul>
</div>