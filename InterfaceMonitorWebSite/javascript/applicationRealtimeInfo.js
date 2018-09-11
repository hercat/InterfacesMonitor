
$(function () {
    $(window).load(function () {
        loadappRealtimeInfo();
    });
    //定时刷新
    setInterval(loadappRealtimeInfo, 10000);
});
function loadappRealtimeInfo() {
    $.ajax({
        url: '/AjaxStatics/GetAppRealtimeStatics.cspx',
        data: {},
        type: 'get',
        cache: false,
        success: function (json) {
            $('#content').empty();
            $.each(json, function (key, val) {
                if (val.num > 0) {
                    if (val.statu == 0) {
                        var dom = '<div class="container_box" onclick=' + 'GetDetails("' + val.appId + '")>' +
                                    '<div class="container_box_left">' +
                                        '<div class="container_box_left_row">' + val.appname + '</div>' +
                                        '<div class="container_box_left_row">' + val.server + '</div>' +
                                        '<div class="container_box_left_row">' + val.userdep + '</div>' +
                                        '<div class="container_box_left_row">' + val.chargeman + '</div>' +
                                        '<div class="container_box_left_row">' + val.phone + '</div>' +
                                    '</div>' +
                                    '<div class="container_box_right">' +
                                        '<div class="container_box_right_row"><span class="num_all">' + val.num + '</span></div>' +
                                        '<div class="container_box_right_red"></div>' +
                                        '<div class="container_box_right_row"><span class="num_error">' + val.errorNum + '</span></div>' +
                                        '<div class="container_box_right_row">故障</div>' +
                                    '</div>' +
                                  '</div>';
                        $('#content').append(dom);
                    }
                    else if (val.statu == 1) {
                        var dom = '<div class="container_box" onclick=' + 'GetDetails("' + val.appId + '")>' +
                                    '<div class="container_box_left">' +
                                        '<div class="container_box_left_row">' + val.appname + '</div>' +
                                        '<div class="container_box_left_row">' + val.server + '</div>' +
                                        '<div class="container_box_left_row">' + val.userdep + '</div>' +
                                        '<div class="container_box_left_row">' + val.chargeman + '</div>' +
                                        '<div class="container_box_left_row">' + val.phone + '</div>' +
                                    '</div>' +
                                    '<div class="container_box_right">' +
                                        '<div class="container_box_right_row"><span class="num_all">' + val.num + '</span></div>' +
                                        '<div class="container_box_right_green"></div>' +
                                        '<div class="container_box_right_row"><span class="num_error">' + val.errorNum + '</span></div>' +
                                        '<div class="container_box_right_row">正常</div>' +
                                    '</div>' +
                                  '</div>';
                        $('#content').append(dom);
                    }
                }
                else{
                    var dom = '<div class="container_box" onclick=' + 'GetDetails("' + val.appId + '")>' +
                                '<div class="container_box_left">' +
                                    '<div class="container_box_left_row">' + val.appname + '</div>' +
                                    '<div class="container_box_left_row">' + val.server + '</div>' +
                                    '<div class="container_box_left_row">' + val.userdep + '</div>' +
                                    '<div class="container_box_left_row">' + val.chargeman + '</div>' +
                                    '<div class="container_box_left_row">' + val.phone + '</div>' +
                                '</div>' +
                                '<div class="container_box_right">' +
                                    '<div class="container_box_right_row"><span class="num_all">' + val.num + '</span></div>' +
                                    '<div class="container_box_right_yellow"></div>' +
                                    '<div class="container_box_right_row"><span class="num_error">' + val.errorNum + '</span></div>' +
                                    '<div class="container_box_right_row">正常</div>' +
                                '</div>' +
                              '</div>';
                    $('#content').append(dom);
                }
            });
        }
    })
}

function GetDetails(appId) {
    window.location.href = "./applicationRelationDetails.aspx?appId=" + window.btoa(appId);
}
