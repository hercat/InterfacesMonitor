﻿/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.easyui.min.js" />
/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.min.js" />

$(document).ready(function () {
    tab1Initial();
    tab2Initial();
    GetInterfaceConfigInfo(GetUrlQueryString("id"));
    GetInterfaceLogs(GetUrlQueryString("id"));
    tabContentInital();
    //文件上传dialog
    $('#btn_upload').click(function () {
        OpenUploadDialog();
    });
    
});
//tab初始化
function tabContentInital() {
    $('.tab_content').hide();
    $('.tabs li:first').addClass('active').show();
    $('.tab_content:first').show();
    $('.tabs li').click(function () {
        $('.tabs li').removeClass('active');
        $(this).addClass('active');
        $('.tab_content').hide();
        var activeTab = $(this).find('a').attr('href');
        $(activeTab).fadeIn();
        return false;
    });
}
//打开上传dialog
function OpenUploadDialog() {
    $('#selectfiles').filebox('clear');    
    $('#upload_windows').dialog({
        width: 600,
        height: 180,
        title: '文件上传',        
        collapsible: true,
        minimizable: false,
        maximizable: false,
        draggable: true,
        shadow: true,
        modal: true,
        buttons: [
            {
                text: '上传',
                iconCls: 'icon-save',
                handler: function () {                    
                    var files = $('#selectfiles').filebox('getValue');
                    alert(files);
                }
            },
            {
                text: '取消',
                iconCls: 'icon-undo',
                handler: function () {
                    $('#upload_windows').dialog('close');
                }
            }
        ]
    });
}
//tab1表格初始化
function tab1Initial() {
    var html = "<table width='100%' border='0' cellpadding='0' cellspacing='0'><thread><tr><th width='60'>序号</th><th>接口名称</th><th>应用系统</th><th>异常信息</th><th width='80'>状态码</th><th width='180'>发生时间</th></tr></thread></table>";
    $('#tab1').append(html);
}
//tab2表格初始化
function tab2Initial() {
    var html = "<table width='100%' border='0' cellpadding='0' cellspacing='0'><thread><tr><th width='60'>序号</th><th>接口名称</th><th>应用系统</th><th>变更内容</th><th width='180'>变更时间</th></tr></thread></table>";
    $('#tab2').append(html);
}
//测试追加数据到dom元素后
function AddTest() {
    var dom = $('#tab1').children('table');
    dom.append("<tr><td>1</td><td>测试接口1</td><td>测试系统</td><td>接口调用失败，尝试多次后失败！</td><td>1</td><td>2018-06-13 12:19:30</td></tr>");
    var dom2 = $('#tab2').children('table');
    dom2.append("<tr><td>1</td><td>测试接口1</td><td>测试应用系统</td><td>接口名由'测试接口'修改为'测试接口1'</td><td>2018-06-13 12:39:10</td></tr>");
}
//根据id获取接口配置信息
function GetInterfaceConfigInfo(id) {
    $.ajax({
        url: '/AjaxInterfaceConfig/GetInterfaceConfigById.cspx',
        data: {
            id: id
        },
        type: 'get',
        cache: false,
        success: function (json) {
            $('#interfaceName').html(json.InterfaceName);
            $('#appName').html(json.ApplicationName);
            $('#server').html(json.ServerAddress);
            $('#userName').html(json.ServerUser);
            $('#pwd').html(json.UserPwd);
            $('#chargeman').html(json.PersonOfChargeName);
            $('#phone').html(json.PersonOfChargePhone);
            $('#description').html(json.Description);
            $('#documents').html("<a href='" + json.DocumentHelpPath + "' target='_blank' style='text-decoration:none;' ><img src='../images/pdf_16.png' />&nbsp;" + json.DocumentHelpPath.substring(json.DocumentHelpPath.lastIndexOf('/') + 1, json.DocumentHelpPath.length) + "</a>,");
        }
    });
}
//获取接口异常日志请求方法
function GetInterfaceLogs(id) {
    $.ajax({
        url: '/AjaxInterfacelog/GetInterfaceLogs.cspx',
        data: {
            id:id
        },
        type: 'get',
        cache: false,
        success: function (json) {
            var dom = $('#tab1').children('table');
            var index = 1;
            $.each(json, function (key, val) {
                dom.append("<tr><td>" + index + "</td><td>" + $('#interfaceName').text() + "</td><td>" + $('#appName').text() + "</td><td>" + val.ExceptionInfo + "</td><td>" + val.StateCode + "</td><td>" + renderTime(val.CreateTime) + "</td></tr>");
                index++;
            });
            index = 1;
        }
    });
}


