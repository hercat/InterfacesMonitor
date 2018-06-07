
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

