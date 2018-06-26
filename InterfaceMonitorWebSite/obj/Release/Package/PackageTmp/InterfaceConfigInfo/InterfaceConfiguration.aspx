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
            <input id="search_text" type="text" value="输入接口名称、应用名称、服务器地址、负责人..." onfocus="if(this.value=='输入接口名称、应用名称、服务器地址、负责人...'){this.value='';}" onblur="if(this.value==''){this.value='输入接口名称、应用名称、服务器地址、负责人...';}"  />
            <span id="search_button">查询</span>
            <span id="import_button">导入</span>
        </div>
        <div id="divTable">
            <table id="gridData"></table>
        </div>
    </div>
    <div id="add_box_div" style="display:none;">
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">接口名称</div>
            <div class="add_box_div_row_content"><input type="text" id="interfaceName" /></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">应用名称</div>
            <div class="add_box_div_row_content"><input type="text" id="applicationName"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">服务器地址</div>
            <div class="add_box_div_row_content"><input type="text" id="server"/></div>
        </div>
        <%--<div class="add_box_div_row">
            <div class="add_box_div_row_label">服务器用户名</div>
            <div class="add_box_div_row_content"><input type="text" id="user"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">用户密码</div>
            <div class="add_box_div_row_content"><input type="text" id="pwd"/></div>
        </div>--%>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">负责人</div>
            <div class="add_box_div_row_content"><input type="text" id="charger"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">负责人电话</div>
            <div class="add_box_div_row_content"><input type="text" id="phone"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">描述</div>
            <div class="add_box_div_row_content"><input type="text" id="desc"/></div>
        </div>
    </div>
    <div id="impoer_box_div" style="display:none;padding:8px;">
        <input id="selectfiles" class="easyui-filebox" style="width:99%" data-options="buttonText:'选择excel文件',buttonIcon:'icon-search',multiple:false" />
    </div>
</asp:Content>
