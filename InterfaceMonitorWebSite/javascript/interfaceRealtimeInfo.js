/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.min.js" />
/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.easyui.min.js" />

//js文档加载方法
$(function () {
    //设置数据库连接字符串
    //DbInitial();
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
//数据库连接字符串加载
function DbInitial() {
    $.ajax({
        url: '/AjaxDbInitial/InitDb.cspx',
        data: {},
        type: 'get',
        cache: false,
        success: function (json) {

        }
    });
}

function InterfaceDetails(id) {
    alert(id);
}
