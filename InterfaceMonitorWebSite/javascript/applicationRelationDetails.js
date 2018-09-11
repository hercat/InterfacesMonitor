var appid = null;
var appname = null;

$(document).ready(function () {
    appid = GetUrlQueryString("appId");    
    appid = window.atob(appid);
    getApplicationinfo(appid);
    loadData(appid);
});
//获取应用系统下游系统与接口详细信息
function loadData(appid) {
    $.ajax({
        url: '/AjaxStatics/GetDestinappStatics.cspx',
        data: {
            appid: appid
        },
        type: 'GET',
        cache: false,
        success: function (json) {
            $('#content').empty();
            $.each(json, function (key, val) {
                if (val.StateCode == 0) {
                    var html = '<div class="container">' +
                                    '<div class="container-top">' +
                                        val.destinappname +
                                    '</div>' +
                                    '<div class="container-panel">' +
                                        '<div class="container-red"></div>' +
                                    '</div>' +
                                    '<div class="container-bottom">' +
                                        '<a href="#" onclick=' + 'interfaceDetails("' + val.interfaceId + '") >' + val.interfacename + '</a>' +
                                    '</div>' +
                                '</div>';
                    $('#content').append(html);
                }
                else {
                    var html = '<div class="container">' +
                                    '<div class="container-top">' +
                                        val.destinappname +
                                    '</div>' +
                                    '<div class="container-panel">' +
                                        '<div class="container-green"></div>' +
                                    '</div>' +
                                    '<div class="container-bottom">' +
                                        '<a href="#" onclick=' + 'interfaceDetails("' + val.interfaceId + '")>' + val.interfacename + '</a>' +
                                    '</div>' +
                                '</div>';
                    $('#content').append(html);
                }
            });
        }
    });
}
//获取应用系统信息
function getApplicationinfo(appid) {
    $.ajax({
        url: '/AjaxApplicationSysInfo/GetApplicationSysInfoById.cspx',
        data: {
            id: appid
        },
        type: 'GET',
        cache: false,
        success: function (json) {
            var title = '【' + json.name + '】下游系统与对应接口详细信息';
            $('#title').text(title);
        }
    });
}
//接口详细信息
function interfaceDetails(id) {
    window.open("./InterfaceDetails.aspx?id=" + window.btoa(id));//新窗口跳转+地址栏参数编码处理
}