<%@ Page Title="接口实时状态" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="InterfaceRealtimeInfo.aspx.cs" Inherits="InterfaceMonitorWebSite.Statics.InterfaceRealtimeInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/interfaceRealtimeInfo.css" rel="stylesheet" />    
    <script src="../javascript/interfaceRealtimeInfo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyRight" runat="server">
    <div class="mainDiv">
        <div id="content_title">
            <span>接口实时状态</span>
        </div>
        <div id="content">
        </div>
    </div>
</asp:Content>
