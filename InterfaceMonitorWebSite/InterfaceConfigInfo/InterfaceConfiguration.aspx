<%@ Page Title="接口信息配置" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="InterfaceConfiguration.aspx.cs" Inherits="InterfaceMonitorWebSite.Config.InterfaceConfiguration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/interfaceConfiguration.css" rel="stylesheet" />
    <script src="../javascript/interfaceConfiguration.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyRight" runat="server">
    <div>
        <div id="content_title">
            <span>接口配置信息</span>
        </div>
        <div id="funtion_buttons">
            <span id="import_button">Excel导入</span>
        </div>
        <div id="divTable">
            <table id="gridData"></table>
        </div>
    </div>
</asp:Content>
