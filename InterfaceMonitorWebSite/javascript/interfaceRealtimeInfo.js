﻿/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.min.js" />
/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.easyui.min.js" />

//js文档加载方法
$(function () {
    //定时刷新
    setInterval(LoadInterfaceRealtimeInfo, 10000);    
});
//加载实时接口信息
function LoadInterfaceRealtimeInfo() {
    $.ajax({
        url: '/AjaxInterfaceRealtime/InterfaceRealtimeList.cspx',
        data: {},
        type: 'get',
        cache: false,
        success: function (json) {
            $('#content').empty();
            $.each(json, function (key, val) {
                if (val.StateCode == 1)
                    $('#content').append("<div class='outer_div' data-title='" + val.ApplicationName + "+" + val.InterfaceName + "' onclick=" + "InterfaceDetails('" + val.Id + "') ><img src='../images/green24.png' /><div class='inner_div'>" + val.InterfaceName + "</div></div>");
                else if (val.StateCode == 0)
                    $('#content').append("<div class='outer_div' data-title='" + val.ApplicationName + "+" + val.InterfaceName + "' onclick=" + "InterfaceDetails('" + val.Id + "') ><img src='../images/red24.png' /><div class='inner_div'>" + val.InterfaceName + "</div></div>");
            });
        }
    });
}

function InterfaceDetails(id) {
    //window.location.href = "./InterfaceDetails.aspx?id=" + id;//当前页跳转
    window.open("./InterfaceDetails.aspx?id=" + id);//新窗口跳转+地址栏参数
}
