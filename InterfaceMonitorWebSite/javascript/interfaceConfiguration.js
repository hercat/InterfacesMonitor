
//js页面加载方法
$(document).ready(function () {
    initDataGrid();
    loadData();
    importTooltip();
    excelImport();
    initSysGrid();
    $('#search_button').click(function () {
        searchData();
    });
    clearAddBox();
    linkbutton();
    $('#searchSystem').click(function () {
        searchDestinctionSystem();
    });
    $('#search2').click(function () {
        searchSysInfo();
    });
});
function onSelect() {    
    $('#gridData').datagrid({
        onSelect: function (index, row) {
            
        }
    })
}
function initSysGrid() {
    $('#sysdataGrid').datagrid({
        idField: 'Id',
        height: '400',
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
        url: '/AjaxApplicationSysInfo/GetApplicationSysInfoList.cspx',
        pageNumber: 1,
        pagesize: 10,
        pageList: [10, 20, 30],
        columns: [[
                    { field: 'ck', align: 'center', checkbox: true }
					, { title: '应用名称', field: 'name', align: 'center', width: 180, sortable: false }
					, { title: '服务器地址', field: 'server', align: 'center', width: 180, sortable: false }
                    , { title: '使用部门', field: 'userdep', align: 'center', width: 120, sortable: false }
                    , { title: '负责人', field: 'chargeman', align: 'center', width: 100, sortable: false }
                    , {
                        title: '级别', field: 'level', align: 'center', width: 100, sortable: false, formatter: function (value, row, index) {
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
                        title: '创建时间', field: 'createtime', align: 'center', width: 160, sortable: false,
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
        $('#sysdataGrid').datagrid('resize', {
            width: $("#sysDiv").css("width")
        });
    });
}
//选择应用系统
function searchDestinctionSystem() {
    $('#container').empty();
    $('#attach_system_div').dialog({
        title: '选择应用系统',
        iconCls: 'icon-add',
        width: 920,
        height: 530,
        closable: false,
        cache: false,
        modal: true,
        onBeforeOpen: function () {
            searchSysInfo();
        },
        buttons: [
            {
                text: '确定',
                iconCls: 'icon-add',
                handler: function () {
                    var rowdata = $('#sysdataGrid').datagrid('getSelected');
                    if (rowdata == null) {
                        $.messager.alert(g_MsgBoxTitle, "请选择应用系统！", "warning");
                        return;
                    }
                    $.messager.confirm("提醒", "确定要选择【" + rowdata.name + "】该应用系统吗？", function (r) {
                        if (r) {
                            var name = rowdata.name;
                            var id = rowdata.Id;
                            var el = '<span id="' + id + '" class="destinname">' + name + '</span>';
                            $('#container').append(el);
                            $('#attach_system_div').dialog('close');
                            clearSysSelectBox();
                        }
                    });
                }
            },
            {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $('#attach_system_div').dialog('close');
                    clearSysSelectBox();
                }
            }
        ]
    });
}
//查询点击事件
function searchSysInfo() {
    var searchText = $('#key2').val();
    if (searchText == '应用系统名称、服务器地址、负责人...')
        searchText = '';
    $('#sysdataGrid').datagrid('load', {
        fields: '',
        key: searchText,
        order: 'CreateTime',
        ascOrdesc: 'desc'
    });
}
//提交数据校验
function checkingData() {
    if (trim($('#interfaceName').val()) == ""){        
        $.messager.alert(g_MsgBoxTitle, "接口名称不能为空！", "warning");        
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
    if (trim($('#timeout').val()) == "") {
        $.messager.alert(g_MsgBoxTitle, "接口超时时间不能为空！", "warning");
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
    $('#charger').val('');
    $('#phone').val('');
    $('#timeout').val('');
    $('#desc').val('');
    $('#urlAddress').val('');
    $('#level').combobox('select', '0');
    $('#type').combobox('select', '0');
    $('#incluence').switchbutton('uncheck');
}
//弹出接口信息添加dialog对话框
function addInterfaceConfigInfo() {
    $('#container').empty();
    $('#add_box_div').dialog({
        title: '添加接口配置信息',
        iconCls:'icon-add',
        width: 700,
        height: 625,
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
                    $.messager.confirm('提醒', '确定要添加【' + $('#interfaceName').val() + '】接口信息吗？', function (r) {
                        if (!r)
                            return;
                        else {
                            var appid = $('#container').children('.destinname').attr('id');
                            var appname = $('#container').children('.destinname').text();
                            if ((appid == null || appid == "") || (appname == null || appname == "")) {
                                $.messager.alert(g_MsgBoxTitle, "请选择应用系统！", "warning");
                                return;
                            }
                            $.ajax({
                                url: '/AjaxInterfaceConfig/AddInterfaceConfigInfo.cspx',
                                data: {
                                    interfaceName: $('#interfaceName').val(),             
                                    user: '',//$('#user').val(),
                                    pwd: '',//$('#pwd').val(),
                                    charger: $('#charger').val(),
                                    phone: $('#phone').val(),
                                    timeout: $('#timeout').val(),
                                    docPath: '',
                                    desc: $('#desc').val(),
                                    urlAddress: $('#urlAddress').val(),
                                    exeptionlevel: $('#level').combobox('getValue'),
                                    affectProduction: $('#incluence').switchbutton('options').checked ? 1 : 0,
                                    type: $('#type').combobox('getValue'),
                                    appid: appid
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
//根据id获取配置信息
function getConfigInfo(id) {
    $.ajax({
        url: '/AjaxInterfaceConfig/GetInterfaceConfigById.cspx',
        data: {
            id: id
        },
        type: 'get',
        cache: false,
        success: function (info) {
            alert(info.Id);
        }
    });
}
//编辑接口配置信息
function editInterfaceConfig() {
    $('#container').empty();
    var rowdata = $('#gridData').datagrid('getSelected');
    if (rowdata != null) {
        $.ajax({
            url: '/AjaxInterfaceConfig/GetInterfaceConfigById.cspx',
            data: {
                id: rowdata.Id
            },
            type: 'get',
            cache: false,
            success: function (info) {
                $('#interfaceName').val(info.InterfaceName);
                var el = '<span id="' + info.appid + '" class="destinname">' + info.ApplicationName + '</span>';
                $('#container').append(el);
                $('#charger').val(info.PersonOfChargeName);
                $('#phone').val(info.PersonOfChargePhone);
                $('#timeout').val(info.ConnectedTimeout);
                $('#desc').val(info.Description);
                $('#urlAddress').val(info.UrlAddress);
                $('#level').combobox('setValue', info.Exeptionlevel);
                $('#type').combobox('setValue',info.Type);
                if (info.AffectProduction == 0)
                    $('#incluence').switchbutton('uncheck');
                else
                    $('#incluence').switchbutton('check');
                //控件数据加载完毕后弹出对话框
                $('#add_box_div').dialog({
                    title: '修改【' + info.InterfaceName + '】接口配置信息',
                    iconCls: 'icon-edit',
                    width: 700,
                    height: 625,
                    closable: false,
                    cache: false,
                    modal: false,
                    buttons: [{
                        text: '修改',
                        iconCls: 'icon-edit',
                        handler: function () {
                            if (!checkingData())
                                return;
                            $.messager.confirm("提醒", "确定要修改【" + info.InterfaceName + "】配置信息？", function (r) {
                                if (r) {
                                    var appid = $('#container').children('.destinname').attr('id');
                                    var appname = $('#container').children('.destinname').text();
                                    if ((appid == null || appid == "") || (appname == null || appname == "")) {
                                        $.messager.alert(g_MsgBoxTitle, "请选择应用系统！", "warning");
                                        return;
                                    }
                                    $.ajax({
                                        url: '/AjaxInterfaceConfig/UpdateInterfaceConfigInfo.cspx',
                                        data: {
                                            id: rowdata.Id,
                                            interfaceName: $('#interfaceName').val(),
                                            user: '',
                                            pwd: '',
                                            charger: $('#charger').val(),
                                            phone: $('#phone').val(),
                                            timeout: $('#timeout').val(),
                                            docPath: '',
                                            desc: $('#desc').val(),
                                            urlAddress: $('#urlAddress').val(),
                                            exeptionlevel: $('#level').combobox('getValue'),
                                            affectProduction: $('#incluence').switchbutton('options').checked ? 1 : 0,
                                            type: $('#type').combobox('getValue'),
                                            appid:appid
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
        url: '/AjaxInterfaceConfig/SearchInterfaceConfigNew.cspx',
        pageNumber:1,
        pagesize: 10,
        pageList: [10, 20, 30],
        columns: [[
                    { field: 'ck', align: 'center', checkbox: true }
					, { title: '接口名称', field: 'InterfaceName', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: false }
					, { title: '应用名称', field: 'ApplicationName', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: false }
					, { title: '服务器地址', field: 'ServerAddress', align: 'center', width: fillsize(380, 0.10, 'divTable'), sortable: false }
                    , { title: '负责人名', field: 'PersonOfChargeName', align: 'center', width: fillsize(380, 0.08, 'divTable'), sortable: false }
                    , { title: '负责人电话', field: 'PersonOfChargePhone', align: 'center', width: fillsize(380, 0.12, 'divTable'), sortable: false }
                    , { title: '超时时间（分钟）', field: 'ConnectedTimeout', align: 'center', width: fillsize(380, 0.05, 'divTable'),sortable:false }
                    , { title: '应用程序描述', field: 'Description', align: 'center', width: fillsize(380, 0.18, 'divTable'), sortable: false,
                        formatter: function (value, row, index) {
                            var abValue = value;
                            if (abValue.length >= 18)
                                abValue = value.substring(0, 14) + "...";
                            var content = "<span title='" + value + "' class='note'>" + abValue + "</span>";
                            return content;
                        }
                    }
                    , { title: '创建时间', field: 'CreateTime', align: 'center', width: fillsize(380, 0.14, 'divTable'), sortable: false,
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
function searchData() {
    var searchText = $('#search_text').val();    
    if (searchText == '输入接口名称、应用名称、服务器地址、负责人...')
        searchText = '';
    $('#gridData').datagrid('load', {
        fields: '',
        key: searchText,
        order: 'CreateTime',
        ascOrdesc: 'desc'
    });
}
//excel导入响应方法
function excelImport() {
    $('#import_button').click(importExcel);
}
//初始化linkbutton
function linkbutton() {
    $('#searchSystem').linkbutton({
        iconCls: 'icon-search'
    });
    $('#search2').linkbutton({
        iconCls: 'icon-search'
    });
}

