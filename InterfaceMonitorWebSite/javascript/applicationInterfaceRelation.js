
$(document).ready(function () {
    initDataGrid();
    loadData();
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
                iconCls: 'icon-edit',
                text: '编辑',
                align: 'left',
                handler: function () {
                    editApplicationInterface();
                }
            },
            '-',
            {
                iconCls: 'icon-remove',
                text: '删除',
                align: 'left',
                handler: function () {
                    deleteApplicationInterface();
                }
            }
        ],
        url: '/AjaxApplicationInterfaceRelation/GetApplicationInterfaceRelationList.cspx',
        pageNumber: 1,
        pagesize: 10,
        pageList: [10, 20, 30],
        columns: [[
                    { field: 'ck', align: 'center', checkbox: true }
					, { title: '应用系统', field: 'appname', align: 'center', width: fillsize(380, 0.3, 'divTable'), sortable: false }
                    , { title: '接口名称', field: 'interfacename', align: 'center', width: fillsize(380, 0.3, 'divTable'), sortable: false }
                    , { title: '下游调用系统', field: 'destinappname', align: 'center', width: fillsize(380, 0.2, 'divTable'), sortable: false }
                    ,{
                        title: '更新时间', field: 'updatetime', align: 'center', width: fillsize(380, 0.18, 'divTable'), sortable: false,
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
function loadData() {
    $('#gridData').datagrid('load', { 
        fields: '',
        key: '',
        order: 'updatetime',
        ascOrdesc: 'desc'
    });
}
function deleteApplicationInterface() {
    var rowdata = $('#gridData').datagrid('getSelected');
    if (rowdata == null) {
        $.messager.alert(g_MsgBoxTitle, "请选中需要删除的配置信息！", "warning");
        return;
    }
    else {
        //确认消息框
        $.messager.confirm("提醒", "确定要删除【" + rowdata.appname + "," + rowdata.interfacename + "】该配置信息吗？", function (r) {
            if (!r)
                return;
            else {
                $.ajax({
                    url: '/AjaxApplicationInterfaceRelation/DeleteApplicationInterfaceRelation.cspx',
                    data: {
                        id: rowdata.Id
                    },
                    type: 'post',
                    cache: false,
                    success: function (json) {
                        $.messager.alert(g_MsgBoxTitle, json, "info");
                        loadData();
                    }
                });
            }
        });
    }
}