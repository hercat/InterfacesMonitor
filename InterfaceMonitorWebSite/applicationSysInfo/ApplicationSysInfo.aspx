<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ApplicationSysInfo.aspx.cs" Inherits="InterfaceMonitorWebSite.applicationSysInfo.ApplicationSysInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/applicationSysInfo.css" rel="stylesheet" />
    <script src="../javascript/applicationSysInfo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyRight" runat="server">
    <div>
        <div id="content_title">
            <span>应用系统管理</span>
        </div>
        <div class="funtion_buttons">
            <input id="search_text" type="text" value="应用系统名称、服务器地址、负责人..." onfocus="if(this.value=='应用系统名称、服务器地址、负责人...'){this.value='';}" onblur="if(this.value==''){this.value='应用系统名称、服务器地址、负责人...';}"  />
            <span id="search_button">查询</span>
        </div>
        <div id="divTable">
            <table id="gridData"></table>
        </div>
    </div>
</asp:Content>
