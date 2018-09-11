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
        </div>
        <div id="divTable">
            <table id="gridData"></table>
        </div>
    </div>
    <div id="add_box_div" style="display:none;">
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">接口名称</div>
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="interfaceName" /></div>
        </div>
        <%--<div class="add_box_div_row">
            <div class="add_box_div_row_label">应用系统</div>
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="applicationName"/></div>
        </div>--%>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">应用系统</div>
            <div class="add_box_div_row_content">
                <%--<input class="inputbox" type="text" id="server"/>--%>
                <div id="container"></div>
                <div id="searchSystem">选择</div>
            </div>
        </div>
        <div class="add_box_div_row2">
            <div class="add_box_div_row_label">接口类型</div>
            <div class="add_box_div_row_content">
                <select id="type" name="level" class="easyui-combobox" data-options="width:'100',height:'30',panelHeight:'100'" >
                    <option value="0">默认</option>
                    <option value="1">应用程序</option>
                    <option value="2">网站</option>
                </select>
            </div>
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
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="charger"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">负责人电话</div>
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="phone"/></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">接口超时时间</div>
            <div class="add_box_div_row_content"><input class="inputbox" type="text" id="timeout" /></div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">是否影响生产</div>
            <div class="add_box_div_row_content">
                <input id="incluence" class="easyui-switchbutton" data-options="width:'100',onText:'是',offText:'否'"/>
            </div>
        </div>
        <div class="add_box_div_row">
            <div class="add_box_div_row_label">影响等级</div>
            <div class="add_box_div_row_content">
                <select id="level" name="level" class="easyui-combobox" data-options="width:'100',height:'30',panelHeight:'100'" >
                    <option value="0">一般</option>
                    <option value="1">严重</option>
                    <option value="2">非常严重</option>
                </select>
            </div>
        </div>
        <div class ="add_box_div_row2">
            <div class="add_box_div_row_label">url连接地址</div>
            <div class="add_box_div_row_content"><textarea id="urlAddress" rows="1" cols="39"></textarea></div>
        </div>
        <div class="add_box_div_row2">
            <div class="add_box_div_row_label">描述</div>
            <div class="add_box_div_row_content"><textarea id="desc" rows="1" cols="39"></textarea></div>
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
