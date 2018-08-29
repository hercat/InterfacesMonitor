
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
            //{
            //    iconCls: 'icon-add',
            //    text: '添加',
            //    align: 'left',
            //    handler: function () {
            //        addApplicationInterface();
            //    }
            //},
            //'-',
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
					, { title: '应用系统名称', field: 'name', align: 'center', width: fillsize(380, 0.38, 'divTable'), sortable: false }					
                    , { title: '接口名称', field: 'chargeman', align: 'center', width: fillsize(380, 0.49, 'divTable'), sortable: false }                                              
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