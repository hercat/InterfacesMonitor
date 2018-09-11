
$(document).ready(function () {
    initDataGrid();
    $('#search_button').click(function () {
        searchData();
    });
});

//初始化datagrid
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
					, { title: '应用名称', field: 'name', align: 'center', width: fillsize(380, 0.16, 'divTable'), sortable: false }
					, { title: '服务器地址', field: 'server', align: 'center', width: fillsize(380, 0.12, 'divTable'), sortable: false }
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
                        title: '应用程序描述', field: 'description', align: 'center', width: fillsize(380, 0.16, 'divTable'), sortable: false,
                        formatter: function (value, row, index) {
                            var abValue = value;
                            if (abValue.length >= 18)
                                abValue = value.substring(0, 14) + "...";
                            var content = "<span title='" + value + "' class='note'>" + abValue + "</span>";
                            return content;
                        }
                    }
                    , {
                        title: '创建时间', field: 'createtime', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: false,
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
//查询点击事件
function searchData() {
    $('#gridData').datagrid('clearChecked');
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
    return true;
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
                    if (!checkingData())
                        return;
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
                                    clearAddBox();
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
//修改应用系统信息
function editApplicationInfo() {
    var rowdata = $('#gridData').datagrid('getSelected');
    if (rowdata != null) {
        $.ajax({
            url: '/AjaxApplicationSysInfo/GetApplicationSysInfoById.cspx',
            data: {
                id: rowdata.Id
            },
            type: 'get',
            cache: false,
            success: function (info) {
                $('#applicationName').val(info.name);
                $('#server').val(info.server);
                $('#userdep').val(info.userdep);
                $('#charger').val(info.chargeman);
                $('#phone').val(info.phone);
                $('#desc').val(info.description);
                $('#level').combobox('setValue', info.level);
                //控件数据加载完毕后弹出对话框
                $('#add_box_div').dialog({
                    title: '修改【' + info.name + '】接口配置信息',
                    iconCls: 'icon-edit',
                    width: 700,
                    height: 460,
                    closable: false,
                    cache: false,
                    modal: false,
                    buttons: [{
                        text: '修改',
                        iconCls: 'icon-edit',
                        handler: function () {
                            if (!checkingData())
                                return;
                            $.messager.confirm("提醒", "确定要修改【" + info.name + "】应用系统信息？", function (r) {
                                if (r) {
                                    $.ajax({
                                        url: '/AjaxApplicationSysInfo/UpdateApplicationSysInfo.cspx',
                                        data: {
                                            id: rowdata.Id,
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
                                            clearAddBox();
                                        }
                                    });
                                }
                            });
                        }
                    }, {
                        text: '取消',
                        iconCls: 'icon-cancel',
                        handler: function () {
                            $('#add_box_div').dialog('close');
                            clearAddBox();
                        }
                    }]
                });
            }
        });
    }
    else {
        $.messager.alert(g_MsgBoxTitle, "请勾选需要编辑的行！", "warning");
    }
}
//删除应用系统
function deleteApplicationInfo() {
    var rowdata = $('#gridData').datagrid('getSelected');
    if (rowdata == null) {
        $.messager.alert(g_MsgBoxTitle, "请选中需要删除的应用系统信息！", "warning");
        return;
    }
    else {
        //确认消息框
        $.messager.confirm("提醒", "确定要删除【" + rowdata.name + "】应用系统吗？", function (r) {
            if (!r)
                return;
            else {
                $.ajax({
                    url: '/AjaxApplicationSysInfo/DeleteApplicationSysInfo.cspx',
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
