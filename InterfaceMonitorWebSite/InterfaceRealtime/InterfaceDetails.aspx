<%@ Page Title="接口详细信息" Language="C#" MasterPageFile="~/Master/DetailPage.Master" AutoEventWireup="true" CodeBehind="InterfaceDetails.aspx.cs" Inherits="InterfaceMonitorWebSite.InterfaceRealtime.InterfaceDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/interfaceDetails.css" rel="stylesheet" />
    <script src="../javascript/interfaceDetails.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="main_body">
        <div class="content_title">
            <span>接口配置信息</span>
        </div>
        <div id="content_detail">
            <div class="basic_top">                
                <div class="basic_top_div">
                    <span class="basic_top_div_title">接口名称：</span><span class="basic_top_div_content" id="interfaceName"></span>
                </div>
                <div class="basic_top_div">
                    <span class="basic_top_div_title">应用系统名称：</span><span class="basic_top_div_content" id="appName"></span>
                </div>
                <div class="basic_top_div">
                    <span class="basic_top_div_title">服务器地址：</span><span class="basic_top_div_content" id="server"></span>
                </div>
                <div class="basic_top_div">
                    <span class="basic_top_div_title">服务器用户名：</span><span class="basic_top_div_content" id="userName"></span>
                </div>
                <div class="basic_top_div">
                    <span class="basic_top_div_title">密码：</span><span class="basic_top_div_content" id="pwd"></span>
                </div>
                <div class="basic_top_div">
                    <span class="basic_top_div_title">负责人：</span><span class="basic_top_div_content" id="chargeman"></span>
                </div>
                <div class="basic_top_div">
                    <span class="basic_top_div_title">联系电话：</span><span class="basic_top_div_content" id="phone"></span>
                </div>
                <div class="basic_top_div">
                    <span class="basic_top_div_title">接口详细信息：</span><span class="basic_top_div_content" id="description"></span>
                </div>
                <div class="basic_top_div">
                    <span class="basic_top_div_title">帮助文档：</span><span class="basic_top_div_content" id="documents"></span>
                    <span class="basic_upload" id="btn_upload">上传附件</span>
                </div>
            </div>
        </div>
        <div id="content_list">
            <div class="content_list_tab">
                <ul class="tabs">
                    <li><a href="#tab1">接口异常日志</a></li>
                    <li><a href="#tab2">变更日志记录</a></li>
                </ul>
            </div>
            <div class="tab_container">
                <div class="tab_content" id="tab1"></div>
                <div class="tab_content" id="tab2"></div>
            </div>
        </div>
    </div>
    <!-- 文件上传表单 -->
    <form id="upload_form" enctype="multipart/form-data">
        <div id="upload_windows" style="display:none;padding:8px;" >
            <input id="selectfiles" class="easyui-filebox" onchange="setfilepathOnchange(this)" style="width:99%;" data-options="buttonText:'选择文件...',buttonIcon:'icon-search',accept:'pdf/*',multiple:false" />
            <div id="progressbar" class="easyui-progressbar" data-options="text:'上传进度'" style="width:99%;margin-top:20px;"></div>            
        </div>        
    </form>    
</asp:Content>
