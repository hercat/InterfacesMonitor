<%@ Page Title="系统接口管理" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ApplicationInterfaceRelation.aspx.cs" Inherits="InterfaceMonitorWebSite.applicationSysInfo.ApplicationInterfaceRelation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/applicationInterfaceRelation.css" rel="stylesheet" />
    <script src="../javascript/applicationInterfaceRelation.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyRight" runat="server">
    <div>
        <div id="content_title">
            <span>应用系统接口管理</span>
        </div>
        <div class="funtion_buttons">
            <input id="search_text" type="text" value="应用系统名称、接口名称..." onfocus="if(this.value=='应用系统名称、接口名称...'){this.value='';}" onblur="if(this.value==''){this.value='应用系统名称、接口名称...';}"  />
            <span id="search_button">查询</span>
        </div>
        <div id="divTable">
            <table id="gridData"></table>
        </div>
    </div>
</asp:Content>
