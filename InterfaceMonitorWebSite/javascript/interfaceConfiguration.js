
$(document).ready(function () {
    initDataGrid();
    loadData();
    importTooltip();        
});
//弹出接口信息添加dialog对话框
function showAddBox() {
    $('#add_box_div').dialog({
        title: '添加接口配置信息',
        iconCls:'icon-save',
        width: 800,
        height: 560,
        closed: false,
        cache: false,
        modal: true,
        buttons: [
            {
                text: '添加',
                iconCls: 'icon-ok',
                handler: function () {

                }
            },
            {
                text: '取消',
                iconCls: 'icon-cancel',
                handler: function () {
                    $('#add_box_div').dialog('close');
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
        method: 'post',
        dataType: 'json',
        toolbar: [
            {
                iconCls: 'icon-add',
                text: '添加',
                align: 'left',
                handler: function () {
                    showAddBox();
                }
            },
            '-',
            {
                iconCls: 'icon-edit',
                text: '编辑',
                align: 'left',
                handler: function () {
                    alert('编辑');
                }
            },
            '-',
            {
                iconCls: 'icon-remove',
                text: '删除',
                align: 'left',
                handler: function () {
                    alert('删除');
                }
            }
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
                    , {
                        title: '应用程序描述', field: 'Description', align: 'center', width: fillsize(380, 0.1, 'divTable'), sortable: false,
                        formatter: function (value, row, index) {
                            return "<span style='overflow:hidden;text-overflow:ellipsis;'>" + value + "</span>";
                        }
                    }
                    , {
                        title: '创建时间', field: 'CreateTime', align: 'center', width: fillsize(380, 0.12, 'divTable'), sortable: false,
                        formatter: function (value, row, index) {
                            return renderTime(value);
                        }
                    }
        ]]
    });
}

//加载数据函数
function loadData() {
    //alert($("#gridData").datagrid("getPager").data("pagination").options.pageSize);
    $('#gridData').datagrid('load', {
        fields: '',
        key: '',
        page: $("#gridData").datagrid("getPager").data("pagination").options.pageNumber,
        pagesize: $("#gridData").datagrid("getPager").data("pagination").options.pageSize
    });
}
