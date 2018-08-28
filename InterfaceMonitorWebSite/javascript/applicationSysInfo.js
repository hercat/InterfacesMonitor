
$(document).ready(function () {
    initDataGrid();
});

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
        method: 'post',
        dataType: 'json',
        toolbar: [
            {
                iconCls: 'icon-add',
                text: '添加',
                align: 'left',
                handler: function () {
                    addInterfaceConfigInfo();
                }
            },
            '-',
            {
                iconCls: 'icon-edit',
                text: '编辑',
                align: 'left',
                handler: function () {
                    editInterfaceConfig();
                }
            },
            '-',
            {
                iconCls: 'icon-remove',
                text: '删除',
                align: 'left',
                handler: function () {
                    deleteInterfaceConfig();
                }
            }
        ],
        url: '/AjaxApplicationSysInfo/GetApplicationSysInfoList.cspx',
        pageNumber: 1,
        pagesize: 10,
        pageList: [10, 20, 30],
        columns: [[
                    { field: 'ck', align: 'center', checkbox: true }					
					, { title: '应用名称', field: 'name', align: 'center', width: fillsize(380, 0.2, 'divTable'), sortable: false }
					, { title: '服务器地址', field: 'server', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: false }
                    , { title: '使用部门', field: 'userdep', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '负责人', field: 'chargeman', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '负责人电话', field: 'phone', align: 'center', width: fillsize(380, 0.12, 'divTable'), sortable: false }
                    , { title: '级别', field: 'level', align: 'center', width: fillsize(380, 0.09, 'divTable'), sortable: false }
                    , {
                        title: '应用程序描述', field: 'description', align: 'center', width: fillsize(380, 0.2, 'divTable'), sortable: false,
                        formatter: function (value, row, index) {
                            var abValue = value;
                            if (abValue.length >= 18)
                                abValue = value.substring(0, 14) + "...";
                            var content = "<span title='" + value + "' class='note'>" + abValue + "</span>";
                            return content;
                        }
                    }
                    , {
                        title: '创建时间', field: 'createtime', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false,
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
