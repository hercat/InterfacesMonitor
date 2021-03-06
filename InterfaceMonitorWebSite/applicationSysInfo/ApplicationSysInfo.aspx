﻿<%@ Page Title="关联关系维护" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="ApplicationSysInfo.aspx.cs" Inherits="InterfaceMonitorWebSite.applicationSysInfo.ApplicationSysInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/applicationSysInfo.css" rel="stylesheet" />
    <script src="../javascript/applicationSysInfo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyRight" runat="server">
    <div>
        <div id="content_title">
            <span>关联关系维护</span>
        </div>
        <div class="funtion_buttons">
            <input id="search_text" type="text" value="应用系统名称、服务器地址、负责人..." onfocus="if(this.value=='应用系统名称、服务器地址、负责人...'){this.value='';}" onblur="if(this.value==''){this.value='应用系统名称、服务器地址、负责人...';}"  />
            <span id="search_button">查询</span>
        </div>
        <div id="divTable">
            <table id="gridData"></table>
        </div>
    </div>
    <!-- 添加或修改应用系统信息控件 -->
    <div id="add_box_div" style="display:none;">        
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">应用系统名称</div>
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="applicationName"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">服务器地址</div>
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="server"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">使用部门</div>
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="userdep"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">负责人</div>
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="charger"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">负责人电话</div>
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="phone"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">系统级别</div>
            <div class="add_box_div_row_content">
                <select id="level" name="level" class="easyui-combobox" data-options="width:'100',height:'30',panelHeight:'100'" >
                    <option value="0">一般</option>
                    <option value="1">重要</option>
                    <option value="2">非常重要</option>
                </select>
            </div>
        </div>        
        <div class="add_box_div_row2">
            <div class="add_box_div_row_label">描述</div>
            <div class="add_box_div_row_content"><textarea id="desc" rows="1" cols="39"></textarea></div>
        </div>
    </div>
    <!-- 关联接口控件 -->
    <div id="attach_interface_div" style="display:none;">
        <div class="add_box_div_row3">
            <div class="add_box_div_row_label">当前系统</div>
            <div class="add_box_div_row_content3">
                <span class="destinname" id="appname"></span>
            </div>
        </div>
        <%--<div class="add_box_div_row3">
            <div class="add_box_div_row_label">上游系统</div>
            <div class="add_box_div_row_content3">
                <div id="container2"></div>
                <div id="searchSystem2">选择</div>
            </div>
        </div>--%>
        <div class="add_box_div_row3">
            <div class="add_box_div_row_label">下游系统</div>
            <div class="add_box_div_row_content3">                
                <div id="container"></div>
                <div id="searchSystem">选择</div>
            </div>
        </div>
        <div class="add_box_div_row3">
            <div class="add_box_div_row_label">关联接口</div>
            <div class="add_box_div_row_content3">
                <input id="key" type="text" value="接口名称、服务器地址、负责人..." onfocus="if(this.value=='接口名称、服务器地址、负责人...'){this.value='';}" onblur="if(this.value==''){this.value='接口名称、服务器地址、负责人...';}"  />
            <span id="search" class="easyui-linkbutton">搜索</span>
            </div>
        </div>
        <div id="divAttachTable">
            <table id="attachGridData"></table>
        </div>
    </div>
    <div id="attach_system_div" style="display:none;">
        <div class="add_box_div_row3">
            <div class="add_box_div_row_content3">
                <input id="key2" type="text" value="应用系统名称、服务器地址、负责人..." onfocus="if(this.value=='应用系统名称、服务器地址、负责人...'){this.value='';}" onblur="if(this.value==''){this.value='应用系统名称、服务器地址、负责人...';}"  />
            <span id="search2" class="easyui-linkbutton">搜索</span>
            </div>
        </div>
        <div id="sysDiv">
            <table id="sysdataGrid"></table>
        </div>
    </div>
</asp:Content>
