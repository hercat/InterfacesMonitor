<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="InterfaceMonitorWebSite.UserControls.MainMenu" %>
<link href="../css/MainMenuSkin.css" rel="stylesheet" />
<div id="nav">
    <ul>
        <li><a>接口实时状态</a>
            <dl>
                <dd />                                    
                <dt>
                    <a href="/Statics/InterfaceRealtimeInfo.aspx">实时状态</a>
                </dt>
                <dd />
            </dl>
        </li>
        <li><a>接口异常日志</a>
            <dl>
                <dd />                   
                <dt>
                    <a href="#">接口日志</a>
                </dt>
                <dd />
            </dl>
        </li>
        <li><a>信息配置</a>
            <dl>
                <dd />
                <dt>
                    <a href="/Config/InterfaceConfiguration.aspx">接口配置</a>
                </dt>
                <dt>
                    <a href="#">系统配置</a>
                </dt>
                <dd />
            </dl>
        </li>
    </ul>
</div>