
$(document).ready(function () {
    initDataGrid();
    loadData();
    $('#search_button').click(function () {
        searchData();
    });
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
                    addApplicationInfo();
                }
            },
            '-',
            {
                iconCls: 'icon-edit',
                text: '编辑',
                align: 'left',
                handler: function () {
                    editApplicationInfo();
                }
            },
            '-',
            {
                iconCls: 'icon-remove',
                text: '删除',
                align: 'left',
                handler: function () {
                    deleteApplicationInfo();
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
                    , { title: '负责人电话', field: 'phone', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , {
                        title: '级别', field: 'level', align: 'center', width: fillsize(380, 0.08, 'divTable'), sortable: false, formatter: function (value, row, index) {
                            var result;
                            if (value == 0)
                                result = "一般";
                            else if (value == 1)
                                result = "重要";
                            else if (value == 2)
                                result = "非常重要";
                            return result;
                        }
                    }
                    , {
                        title: '应用程序描述', field: 'description', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: false,
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
//加载数据函数
function loadData() {
    $('#gridData').datagrid('load', {
        fields: '',
        key: '',
        order: 'createtime',
        ascOrdesc: 'desc'
    });
}
//提交数据校验
function checkingData() {
    if (trim($('#applicationName').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "应用系统名称不能为空！", "warning");
        return false;
    }
    if (trim($('#server').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "服务器地址不能为空！", "warning");
        return false;
    }
    if (trim($('#userdep').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "使用部门不能为空！", "warning");
        return false;
    }
    if (trim($('#charger').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "负责人不能为空！", "warning");
        return false;
    }
    if (trim($('#phone').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "负责人电话不能为空！", "warning");
        return false;
    }
}
//清空对话框缓存
function clearAddBox() {
    $('#applicationName').val('');
    $('#server').val('');
    $('#userdep').val('');
    $('#charger').val('');
    $('#phone').val('');
    $('#desc').val('');
    $('#level').combobox('select', '0');
}
//添加应用系统方法
function addApplicationInfo() {
    $('#add_box_div').dialog({
        title: '添加应用系统信息',
        iconCls: 'icon-add',
        width: 700,
        height: 460,
        closable: false,
        cache: false,
        modal: true,
        buttons: [
            {
                text: '添加',
                iconCls: 'icon-add',
                handler: function () {
                    //if (!checkingData())
                    //    return;
                    $.messager.confirm('提醒', '确定要添加【' + $('#applicationName').val() + '】应用系统信息吗？', function (r) {
                        if (!r)
                            return;
                        else {
                            $.ajax({
                                url: '/AjaxApplicationSysInfo/AddApplicationSysInfo.cspx',
                                data: {                                    
                                    name: $('#applicationName').val(),
                                    server: $('#server').val(),
                                    userdep: $('#userdep').val(),
                                    chargeman: $('#charger').val(),
                                    phone: $('#phone').val(),
                                    description: $('#desc').val(),
                                    level: $('#level').combobox('getValue')
                                },
                                type: 'post',
                                cache: false,
                                success: function (json) {
                                    $.messager.alert(g_MsgBoxTitle, json, "info");
                                    $('#add_box_div').dialog('close');
                                    $('#gridData').datagrid('load');                                 
                                }
                            });
                        }
                    });
                }
            },
            {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $('#add_box_div').dialog('close');
                    clearAddBox();
                }
            }
        ]
    });
}
function searchData() {
    var searchText = $('#search_text').val();
    if (searchText == '应用系统名称、服务器地址、负责人...')
        searchText = '';
    $('#gridData').datagrid('load', {
        fields: '',
        key: searchText,
        order: 'CreateTime',
        ascOrdesc: 'desc'
    });
}
