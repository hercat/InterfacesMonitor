
//页面加载函数
$(document).ready(function () {
    initDataGrid();
    //初始化绑定接口datagrid并加载数据
    initAttachGrid();
    //初始化下游系统选择datagrid
    initSysGrid();
    loadData();
    $('#search_button').click(function () {
        searchData();
    });
    $('#search').click(function () {
        searchInterface();
    });
    $('#search2').click(function () {
        searchSysInfo();
    });
    linkbutton();
    //选择上游应用系统
    $('#searchSystem2').click(function () {
        searchFatherSystem();
    });
    //选择下游系统
    $('#searchSystem').click(function () {
        searchDestinctionSystem();
    });
});
function clearSysSelectBox() {
    $('#key2').val('应用系统名称、服务器地址、负责人...');
    $('#sysdataGrid').datagrid('clearChecked');
}
//初始化页面linkbutton
function linkbutton() {
    $('#search').linkbutton({
        iconCls: 'icon-search'
    });
    $('#searchSystem').linkbutton({
        iconCls: 'icon-search'
    });
    $('#search2').linkbutton({
        iconCls: 'icon-search'
    });
    $('#searchSystem2').linkbutton({
        iconCls:'icon-search'
    });
}
//选择下游应用系统
function searchDestinctionSystem() {
    $('#container').empty();
    $('#attach_system_div').dialog({
        title: '选择下游系统',
        iconCls: 'icon-add',
        width: 920,
        height: 540,
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
                        $.messager.alert(g_MsgBoxTitle, "请选择下游应用系统！", "warning");
                        return;
                    }
                    $.messager.confirm("提醒", "确定要选择【" + rowdata.name + "】该应用系统吗？", function (r) {
                        if (r) {
                            var name = rowdata.name;
                            var id = rowdata.Id;
                            var el = '<span value="' + id + '" class="destinname">' + name + '</span>';
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
//选择上游应用系统
function searchFatherSystem() {
    $('#container2').empty();
    $('#attach_system_div').dialog({
        title: '选择上游系统',
        iconCls: 'icon-add',
        width: 920,
        height: 540,
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
                        $.messager.alert(g_MsgBoxTitle, "请选择下游应用系统！", "warning");
                        return;
                    }
                    $.messager.confirm("提醒", "确定要选择【" + rowdata.name + "】该应用系统吗？", function (r) {
                        if (r) {
                            var name = rowdata.name;
                            var id = rowdata.Id;
                            var el = '<span value="' + id + '" class="destinname">' + name + '</span>';
                            $('#container2').append(el);
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
					, { title: '应用名称', field: 'name', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: false }
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
                    , {
                        title: '关联接口', field: 'Id', align: 'center', width: fillsize(380, 0.08, 'divTable'), sortable: false,
                        formatter: function (value, row, index) {
                            var str = '<a name="attach" href="#" class="easyui-linkbutton" ></a>';
                            return str;
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
            $('a[name="attach"]').linkbutton({
                iconCls: 'icon-add',
                text: '关联接口',
                onClick: function () {
                    var rowdata = $('#gridData').datagrid('getSelected');
                    attachInterface(rowdata.Id);
                }
            });
        }
    });
    //窗体尺寸调整
    $(window).resize(function () {
        $('#gridData').datagrid('resize', {
            width: $("#divTable").css("width")
        });
    });
}

//关联接口按钮响应事件
function attachInterface(id) {
    $('#attach_interface_div').dialog({
        title: '关联接口绑定',
        iconCls: 'icon-add',
        width: 910,
        height: 690,
        closable: false,
        cache: false,
        modal: true,        
        onBeforeOpen: function () {
            $('#container').empty();
            $('#container2').empty();
            beforeOpen(id);
            searchInterface();
        },
        buttons: [
            {
                text: '保存',
                iconCls: 'icon-add',
                handler: function () {
                    var rowdata = $('#attachGridData').datagrid('getSelected');
                    if (rowdata == null){
                        $.messager.alert(g_MsgBoxTitle, "请选择要关联的接口！", "warning");
                        return;
                    }
                    $.messager.confirm("提醒", "确定要保存该关联信息？", function (r) {
                        if (r) {
                            
                            clearAttachBox();
                        }
                    });
                }
            },
            {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $('#attach_interface_div').dialog('close');
                    clearAttachBox();
                }
            }
        ]
    });
}
function clearAttachBox() {
    $('#key').val('接口名称、服务器地址、负责人...');
    $('#attachGridData').datagrid('clearChecked');
}
//接口绑定onBeforeOpen响应事件
function beforeOpen(id) {
    $.ajax({
        url: '/AjaxApplicationSysInfo/GetApplicationSysInfoById.cspx',
        data: {
            id: id
        },
        type: 'get',
        cache: false,
        success: function (info) {
            $('#appname').text(info.name);
        }
    });
}
//初始化接口绑定控件datagrid
function initAttachGrid() {
    $('#attachGridData').datagrid({
        idField: 'Id',
        height:'400',
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
        url: '/AjaxInterfaceConfig/SearchInterfaceConfigNew.cspx',
        pageNumber: 1,
        pagesize: 10,
        pageList: [10],
        columns: [[
                    { field: 'ck', align: 'center', checkbox: true }
					, { title: '接口名称', field: 'InterfaceName', align: 'center', width: 200, sortable: false }
					, { title: '服务器地址', field: 'ServerAddress', align: 'center', width: 180, sortable: false }
                    , { title: '负责人', field: 'PersonOfChargeName', align: 'center', width: 100, sortable: false }
                    , { title: '负责人电话', field: 'PersonOfChargePhone', align: 'center', width: 180, sortable: false }
                    , {
                        title: '创建时间', field: 'CreateTime', align: 'center', width: 160, sortable: false,
                        formatter: function (value, row, index) {
                            return renderTime(value);
                        }
                    }
                    //, {
                    //    title: '操作', field: 'Id', align: 'center', width: 110, sortable: false,
                    //    formatter: function (value, row, index) {
                    //        var str = '<a name="add" href="#" class="easyui-linkbutton" ></a>';
                    //        return str;
                    //    }
                    //}
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
            $('a[name="add"]').linkbutton({
                iconCls: 'icon-add',
                text: '关联',
                onClick: function () {
                    var rowdata = $('#attachGridData').datagrid('getSelected');
                    alert(rowdata.Id);
                    //addInterface(rowdata.Id);
                }
            });
        }
    });
    //窗体尺寸调整
    $(window).resize(function () {
        $('#attachGridData').datagrid('resize', {
            width: $("#divAttachTable").css("width")
        });
    });
}
//
function searchInterface() {
    var searchText = $('#key').val();
    if (searchText == '接口名称、服务器地址、负责人...')
        searchText = '';
    $('#attachGridData').datagrid('load', {
        fields: '',
        key: searchText,
        order: 'CreateTime',
        ascOrdesc: 'desc'
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
    return true;
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
                                            id:rowdata.Id,
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
                    //, { title: '负责人电话', field: 'phone', align: 'center', width: 160, sortable: false }
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