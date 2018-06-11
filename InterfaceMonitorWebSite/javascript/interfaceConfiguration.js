/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.min.js" />
/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\InterfaceMonitorWebSite\jquery-easyui-1.5.5.2/jquery.easyui.min.js" />

$(function () {    
    InitDataGrid();
});

//初始化datagrid
function InitDataGrid() {    
    $('#gridData').datagrid({
        idField:'Id',
        pageSize: 10,
        pageList: [10, 20, 30],
        columns: [[
                    { field: 'ck', align: 'center', checkbox: true }
					, { title: '接口名称', field: 'InterfaceName', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: true }
					, { title: '应用名称', field: 'ApplicationName', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: true }
					, { title: '服务器地址', field: 'ServerAddress', align: 'center', width: fillsize(380, 0.15, 'divTable'), sortable: true }
					, { title: '服务器用户名', field: 'ServerUser', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
					, { title: '用户密码', field: 'UserPwd', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '负责人名', field: 'PersonOfChargeNames', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '负责人电话', field: 'PersonOfChargePhone', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '应用程序描述', field: 'Description', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false }
                    , { title: '创建时间', field: 'CreateTime', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: true }
        ]]
    });
}