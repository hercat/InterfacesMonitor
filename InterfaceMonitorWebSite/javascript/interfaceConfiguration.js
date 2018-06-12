
$(function () {
    InitDataGrid();
    LoadData();    
});

//初始化datagrid
function InitDataGrid() {    
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
        method: 'get',
        dataType: 'json',
        toolbar: [
            { iconCls: 'icon-add', text: '添加', align: 'left', handler: function () {alert('添加') } },
            '-',
            { iconCls: 'icon-edit', text: '编辑', align: 'left', handler: function () { alert('编辑')} },
            '-',
            { iconCls: 'icon-remove', text: '删除', align: 'left', handler: function () { alert('删除') } }
        ],
        url: '/AjaxInterfaceConfig/SearchInterfaceConfig.cspx',
        pageNumber:1,
        pagesize: 10,
        pageList: [10, 20, 30],
        columns: [[
                    { field: 'ck', align: 'center', checkbox: true }
					, { title: '接口名称', field: 'InterfaceName', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: false }
					, { title: '应用名称', field: 'ApplicationName', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
					, { title: '服务器地址', field: 'ServerAddress', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
					, { title: '服务器用户名', field: 'ServerUser', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
					, { title: '用户密码', field: 'UserPwd', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '负责人名', field: 'PersonOfChargeName', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '负责人电话', field: 'PersonOfChargePhone', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '应用程序描述', field: 'Description', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '创建时间', field: 'CreateTime', align: 'center', width: fillsize(380, 0.12, 'divTable'), sortable: false }
        ]]
    });
}

//加载数据函数
function LoadData() {
    //alert($("#gridData").datagrid("getPager").data("pagination").options.pageSize);
    $('#gridData').datagrid('load', {
        fields: '',
        key: '',
        page: $("#gridData").datagrid("getPager").data("pagination").options.pageNumber,
        pagesize: $("#gridData").datagrid("getPager").data("pagination").options.pageSize
    });
}
