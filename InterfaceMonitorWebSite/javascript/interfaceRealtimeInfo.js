//js文档加载方法
$(function () {
    $("#clickMe").click(function () {
        $.ajax({
            url: '/AjaxTest/TestMethod.cspx',
            data: '',
            success: function (str)
            {                
                alert(str);
            }
        });
    });
});

