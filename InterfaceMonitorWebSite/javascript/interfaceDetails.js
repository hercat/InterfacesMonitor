/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.easyui.min.js" />
/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.min.js" />
var cid = null;
$(document).ready(function () {
    cid = GetUrlQueryString("id")
    //tab1Initial();
    //tab2Initial();
    getInterfaceConfigInfo(cid);
    //getInterfaceLogs(GetUrlQueryString("id"));
    initDataGrid();
    loadData(cid);
    //tabContentInital();
    uploadTooltip();
    //文件上传dialog
    $('#btn_upload').click(function () {
        openUploadDialog();
    });
    
});
//设置上传按钮tooltip提示
function uploadTooltip() {
    $('#btn_upload').tooltip({
        position: 'top',
        content: '<span style="color:#fff;padding:3px;">建议使用IE11高版本浏览器上传文件.</span>',
        onShow: function () {
            $(this).tooltip('tip').css({
                backgroundColor: '#666',
                borderColor: '#666'
            })
        }
    });
}
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
function openUploadDialog() {
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
        readonly:true,
        buttons: [
            {
                text: '上传',
                iconCls: 'icon-ok',
                handler: function () {
                    //获取本地文件文件路径
                    var file = $('#selectfiles').filebox('getValue');
                    alert(file);
                    var filename = $('#selectfiles').filebox('getText');
                    //获取选择上传文件文件名
                    alert(filename);
                }
            },
            {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $('#upload_windows').dialog('close');
                }
            }
        ]
    });
}
//tab1表格初始化
function tab1Initial() {
    //var html = "<table width='100%' border='0' cellpadding='0' cellspacing='0'><thread><tr><th width='5%'>序号</th><th width='20%'>接口名称</th><th width='15%'>应用系统</th><th>异常信息</th><th width='10%'>状态码</th><th width='15%'>发生时间</th></tr></thread></table>";
    var html = "<table width='100%' border='0' cellpadding='0' cellspacing='0'><thread><tr><th width='10%'>序号</th><th>异常信息</th><th width='15%'>状态码</th><th width='25%'>发生时间</th></tr></thread></table>";
    $('#tab1').append(html);
}
//tab2表格初始化
function tab2Initial() {
    //var html = "<table width='100%' border='0' cellpadding='0' cellspacing='0'><thread><tr><th width='5%'>序号</th><th width='20%'>接口名称</th><th  width='15%'>应用系统</th><th>变更内容</th><th width='25%'>变更时间</th></tr></thread></table>";
    var html = "<table width='100%' border='0' cellpadding='0' cellspacing='0'><thread><tr><th width='10%'>序号</th><th>变更内容</th><th width='25%'>变更时间</th></tr></thread></table>";
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
function getInterfaceConfigInfo(id) {
    id = window.atob(id);//对地址栏参数进行解码
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
            //$('#userName').html(json.ServerUser);
            //$('#pwd').html(json.UserPwd);
            $('#chargeman').html(json.PersonOfChargeName);
            $('#phone').html(json.PersonOfChargePhone);
            $('#description').html(json.Description);
            if (json.DocumentHelpPath != null && json.DocumentHelpPath != '')
                $('#documents').html("<a href='" + json.DocumentHelpPath + "' target='_blank' style='text-decoration:none;' ><img src='../images/pdf_16.png' />&nbsp;" + json.DocumentHelpPath.substring(json.DocumentHelpPath.lastIndexOf('/') + 1, json.DocumentHelpPath.length) + "</a>,");
        }
    });
}
//获取接口异常日志请求方法
function getInterfaceLogs(id) {
    id = window.atob(id);//对地址栏参数进行解码
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
                //dom.append("<tr><td>" + index + "</td><td>" + $('#interfaceName').text() + "</td><td>" + $('#appName').text() + "</td><td>" + val.ExceptionInfo + "</td><td>" + val.StateCode + "</td><td>" + renderTime(val.CreateTime) + "</td></tr>");
                dom.append("<tr><td>" + index + "</td><td>" + val.ExceptionInfo + "</td><td>" + val.StateCode + "</td><td>" + renderTime(val.CreateTime) + "</td></tr>");
                index++;
            });
            index = 1;
        }
    });
}
//获取接口异常日志分页请求方法
function getInterfaceLogsListPage(id) {

}

function initDataGrid() {    
    $('#gridData').datagrid({
        idField: 'Id',
        nowrap: false,
        rownumbers: true,
        singleSelect: true,
        border: true,
        checkOnSelect: true,
        selectOnCheck: true,
        pagination: true,
        collapsible: true,
        striped: true,
        fitcolumns: true,
        onLoadError: function (XMLHttpRequest, textStatus, ErrorThrown) {
            $.messager.alert(g_MsgBoxTitle,
                XMLHttpRequest.responseText.substring(XMLHttpRequest.respinseText.indexOf("<title>") + 7, XMLHttpRequest.responseText.indexOf("</title>")), "error");
        },        
        method: 'get',
        dataType: 'json',
        url: '/AjaxInterfacelog/GetInterfaceLogsPageList.cspx',
        pageNumber: 1,
        pagesize: 10,
        pageList: [10, 20, 30],
        columns: [[
					{ title: '异常信息', field: 'ExceptionInfo', align: 'center', width: fillsize(380, 0.5, 'divTable'), sortable: false }
					, { title: '状态码', field: 'StateCode', align: 'center', width: fillsize(380, 0.25, 'divTable'), sortable: false }
                    , {
                        title: '发生时间', field: 'CreateTime', align: 'center', width: fillsize(380, 0.25, 'divTable'), sortable: false,
                        formatter: function (value, row, index) {
                            return renderTime(value);
                        }
                    }
        ]],
        onLoadSuccess: function (data) {
            $(".note").tooltip(
                {
                    onShow: function () {
                        $(this).tooltip('tip').css({
                            position: 'top',
                            backgroundColor: '#666',
                            borderColor: '#666',
                            color: '#fff'
                        });
                    }
                }
            );
        }
    });
    //窗体尺寸调整
    $(window).resize(function () {
        $('#gridData').datagrid('resize', {
            width: $("#divTable").css("width")
        });
    });
}

function loadData(id) {
    id = window.atob(id);//对地址栏参数进行解码
    $('#gridData').datagrid('load', {
        id:id
    });
}
