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