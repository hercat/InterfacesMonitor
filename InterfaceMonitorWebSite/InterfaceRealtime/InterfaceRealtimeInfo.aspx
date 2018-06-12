<%@ Page Title="接口实时状态" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="InterfaceRealtimeInfo.aspx.cs" Inherits="InterfaceMonitorWebSite.Statics.InterfaceRealtimeInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/interfaceRealtimeInfo.css" rel="stylesheet" />    
    <script src="../javascript/interfaceRealtimeInfo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyRight" runat="server">
    <div>
        <div id="content_title">
            <span>接口实时状态</span>
        </div>
        <div id="content">
            <%--<div class="outer_div" onclick="alert('click me!');" data-title="测试系统1+测试接口1" >
                <img src="../images/green24.png" />
                <div class="inner_div">
                    InterfaceMonitor.Frameworks.BizProcess.InterfaceConfigInitBizProcess
                </div>
            </div>
            <div class="outer_div" onclick="alert('click me!');" data-title="测试系统2+测试接口2">
                <img src="../images/green24.png" />
                <div class="inner_div">
                    <a style="text-decoration:none;" href="#" >测试系统2+测试接口2</a>
                </div>
            </div>
            <div class="outer_div" onclick="alert('click me!');" data-title="测试系统1+测试接口3">
                <img src="../images/red24.png" />
                <div class="inner_div">
                    <a style="text-decoration:none;" href="#" >测试系统1+测试接口3</a>
                </div>
            </div>
            <div class="outer_div" onclick="alert('click me!');" data-title="测试系统2+测试接口4">
                <img src="../images/green24.png" />
                <div class="inner_div">
                    <a style="text-decoration:none;" href="#" >测试系统2+测试接口4</a>
                </div>
            </div>--%>
        </div>
    </div>
</asp:Content>
