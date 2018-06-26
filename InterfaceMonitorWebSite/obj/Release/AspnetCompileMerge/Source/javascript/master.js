var g_MsgBoxTitle = "接口监控系统";

function OpenTab() {
    var menu = $('#nav').css("display");
    var arrdiv = $('#').css("display");
    if (menu == 'block' || menu == "") {
        $('#nav').css("display", "none");
        $("#splitter").html("<img src='../images/icon_head_plus.gif' /><span>显示菜单</span>");
        $('#contentWrap').css("marginLeft", "17px");
        $('#left_container').css("width", "15px");
    }
    else {
        $('#nav').css("display", "block");
        $('#splitter').html("<img src='../images/icon_head_minus.gif' /><span>隐藏菜单</span>");
        $('#contentWrap').css("marginLeft", "152px");
        $('#left_container').css("width", "150px");
    }
}

function fillsize(borderWidth,percent,id) {
    var bodyWidth = parseInt($("#" + id + "").css('width'));
    return (bodyWidth - 34.5) * percent;
}

//获取地址地址栏参数
function GetUrlQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}

//解析json的时间“/Date(1216796600500)/ ”
function renderTime(str) {
    ss = str.replace("/Date(", "");
    mm = ss.replace(")/", "");

    var d = new Date();
    d.setTime(mm);
    var year = d.getFullYear();
    var month = d.getMonth() + 1;
    if (month < 10)
        month = '0' + month;
    var date = d.getDate();
    if (date < 10)
        date = '0' + date;
    var hour = d.getHours();
    if (hour < 10)
        hour = '0' + hour;
    var minute = d.getMinutes();
    if (minute < 10)
        minute = '0' + minute;
    var second = d.getSeconds();
    if (second < 10)
        second = '0' + second;
    dt = year + "-" + month + "-" + date + " " + hour + ":" + minute + ":" + second;
    //alert(dt);
    return dt;
}
//清除空格
function trim(str) {
    return str.replace(/^\s+|\s+$/g, '');
}

