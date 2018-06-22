
//js页面加载方法
$(document).ready(function () {
    initDataGrid();
    loadData();
    importTooltip();
    excelImport();
});
function onSelect() {    
    $('#gridData').datagrid({
        onSelect: function (index, row) {
            
        }
    })
}
//提交数据校验
function checkingData() {
    if (trim($('#interfaceName').val()) == ""){        
        $.messager.alert(g_MsgBoxTitle, "接口名称不能为空！", "warning");        
        return false;
    }
    if (trim($('#applicationName').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "应用名称不能为空！", "warning");
        return false;
    }
    if (trim($('#server').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "服务器地址不能为空！", "warning");
        return false;
    }
    //if (trim($('#user').val()) == "") {
    //    $.messager.alert(g_MsgBoxTitle, "服务器用户名不能为空！", "warning");
    //    return false;
    //}
    //if (trim($('#pwd').val()) == "") {
    //    $.messager.alert(g_MsgBoxTitle, "用户密码不能为空！", "warning");
    //    return false;
    //}
    if (trim($('#charger').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "负责人不能为空！", "warning");
        return false;
    }
    if (trim($('#phone').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "负责人电话不能为空！", "warning");
        return false;
    }
    if (trim($('#desc').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "描述不能为空！", "warning");
        return false;
    }
    return true;
}
//清空添加
function clearAddBox() {
    $('#interfaceName').val('');
    $('#applicationName').val('');
    $('#server').val('');
    //$('#user').val('');
    //$('#pwd').val('');
    $('#charger').val('');
    $('#phone').val('');
    $('#desc').val('');
}
//弹出接口信息添加dialog对话框
function addInterfaceConfigInfo() {    
    $('#add_box_div').dialog({
        title: '添加接口配置信息',
        iconCls:'icon-save',
        width: 580,
        height: 330,
        closed: false,
        cache: false,
        modal: true,
        buttons: [
            {
                text: '添加',
                iconCls: 'icon-add',
                handler: function () {
                    if (!checkingData())
                        return;
                    $.messager.confirm('提醒', '确定要添加【' + $('#interfaceName').val() + '】接口信息吗？', function (r) {
                        if (!r)
                            return;
                        else {
                            $.ajax({
                                url: '/AjaxInterfaceConfig/AddInterfaceConfigInfo.cspx',
                                data: {
                                    interfaceName: $('#interfaceName').val(),
                                    applicationName: $('#applicationName').val(),
                                    server: $('#server').val(),
                                    user: '',//$('#user').val(),
                                    pwd: '',//$('#pwd').val(),
                                    charger: $('#charger').val(),
                                    phone: $('#phone').val(),
                                    timeout: 0,
                                    docPath: '',
                                    desc: $('#desc').val()
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
function importTooltip() {
    $('#import_button').tooltip({
        position: 'top',
        content: '<span style="color:#fff">建议使用IE11高版本浏览器导入数据</span>',
        onShow: function () {
            $(this).tooltip('tip').css({
                backgroundColor: '#666',
                borderColor: '#666'
            });
        }
    });
}
//弹出导入数据对话框
function importExcel() {
    $('#selectfiles').filebox('clear');
    $('#impoer_box_div').dialog({
        title: '接口配置数据导入',
        iconCls: 'icon-save',
        width: 600,
        height: 130,
        closed: false,
        cache: false,
        modal: true,
        buttons: [
            {
                text: '导入',
                iconCls: 'icon-ok',
                handler: function () {

                }
            },
            {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $('#impoer_box_div').dialog('close');
                }
            }
        ]
    })
}
//编辑接口配置信息
function editInterfaceConfig() {
    var rowdata = $('#gridData').datagrid('getSelected');
    alert(rowdata.Id);
}
//删除接口配置信息
function deleteInterfaceConfig() {
    var rowdata = $('#gridData').datagrid('getSelected');
    if (rowdata == null) {
        $.messager.alert(g_MsgBoxTitle, "请选中需要删除的配置信息！", "warning");
        return;
    }
    else {
        //确认消息框
        $.messager.confirm("提醒", "确定要删除【" + rowdata.InterfaceName + "】接口配置吗？", function (r) {
            if (!r)
                return;
            else {
                $.ajax({
                    url: '/AjaxInterfaceConfig/DeleteInterfaceConfigInfo.cspx',
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
        onLoadError:function(XMLHttpRequest,textStatus,ErrorThrown){
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
            //{
            //    iconCls: 'icon-edit',
            //    text: '编辑',
            //    align: 'left',
            //    handler: function () {
            //        editInterfaceConfig();
            //    }
            //},
            //'-',
            {
                iconCls: 'icon-remove',
                text: '删除',
                align: 'left',
                handler: function () {
                    deleteInterfaceConfig();
                }
            }
        ],
        url: '/AjaxInterfaceConfig/SearchInterfaceConfigNew.cspx',
        pageNumber:1,
        pagesize: 10,
        pageList: [10, 20, 30],
        columns: [[
                    { field: 'ck', align: 'center', checkbox: true }
					, { title: '接口名称', field: 'InterfaceName', align: 'center', width: fillsize(380, 0.25, 'divTable'), sortable: false }
					, { title: '应用名称', field: 'ApplicationName', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: false }
					, { title: '服务器地址', field: 'ServerAddress', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: false }
					//, { title: '服务器用户名', field: 'ServerUser', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
					//, { title: '用户密码', field: 'UserPwd', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '负责人名', field: 'PersonOfChargeName', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '负责人电话', field: 'PersonOfChargePhone', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '应用程序描述', field: 'Description', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false,
                        formatter: function (value, row, index) {
                            var abValue = value;
                            if (abValue.length >= 18)
                                abValue = value.substring(0, 14) + "...";
                            var content = "<span title='" + value + "' class='note'>" + abValue + "</span>";
                            return content;
                        }
                    }
                    , { title: '创建时间', field: 'CreateTime', align: 'center', width: fillsize(380, 0.12, 'divTable'), sortable: false,
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
                            color:'#fff'
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
        order: 'CreateTime',
        ascOrdesc:'desc'
    });
}
//excel导入响应方法
function excelImport() {
    $('#import_button').click(importExcel);
}
