var MF = {};
MF.Class = {
    create: function () {
        return function () {
            this.init.apply(this, arguments);
        }
    }
};
/**
*根目录
*/
MF.Root = "/";
/**
*初始化bootstrap Table封装
*约定:toolbar的id为（bstableId+"Toolbar"）
*/
MF.BSTable = function (bstableId, url, columns) {
    this.btInstance = null;//NootstrapTable绑定的对象
    this.bstableId = bstableId;
    this.url = url;
    this.method = "post";
    this.PaginationType = "server";
    this.toolbarId = bstableId + "Toolbar";
    this.columns = columns;
    this.height = 665;
    this.data = {};
    this.queryParams = {};
};
MF.BSTable.prototype = {
    /**
    *初始化bootstrap table
    */
    init: function () {
        var tableId = this.bstableId;
        this.btInstance =
            $('#' + tableId).bootstrapTable({
                contentType: "application/json;charset=UTF-8",
                url: this.url,              //请求地址
                method: this.method,        //ajax方式,post还是get
                ajaxOptions: {              //ajax请求的附带参数
                    data: this.data
                },
                toolbar: "#" + this.toolbarId,//顶部工具条
                striped: true,              //是否显示行间隔色
                cache: false,               //是否使用缓存,默认为true
                pagination: true,           //是否显示分页（*）
                sortable: true,             //是否启用排序
                sortOrder: "desc",          //排序方式
                pageNumber: 1,                  //初始化加载第一页，默认第一页
                pageSize: 15,               //每页的记录行数（*）
                pageList: [15, 25, 45],    //可供选择的每页的行数（*）
                queryParamsType: 'limit',   //默认值为 'limit' ,在默认情况下 传给服务端的参数为：offset,limit,sort
                queryParams: function (param) {
                    return $.extend(this.queryParams, param);
                }, // 向后台传递的自定义参数
                sidePagination: this.paginationType,   //分页方式：client客户端分页，server服务端分页（*）
                search: false,              //是否显示表格搜索，此搜索是客户端搜索，不会进服务端
                strictSearch: true,         //设置为 true启用 全匹配搜索，否则为模糊搜索
                showColumns: true,          //是否显示所有的列
                showRefresh: true,          //是否显示刷新按钮
                minimumCountColumns: 2,     //最少允许的列数
                clickToSelect: true,        //是否启用点击选中行
                searchOnEnterKey: true,     //设置为 true时，按回车触发搜索方法，否则自动触发搜索方法
                columns: this.columns,      //列数组
                pagination: true,           //是否显示分页条
                height: this.height,
                showToggle: true,                    //是否显示详细视图和列表视图的切换按钮
                icons: {
                    refresh: 'glyphicon-repeat',
                    toggle: 'glyphicon-list-alt',
                    columns: 'glyphicon-list'
                },
                iconSize: 'outline'
            });
        return this;
    },
    /**
    *向后台传递的自定义参数
    */
    setQueryParams: function (param) {
        this.queryParams = param;
    },
    /**
    *设置分页方式:server或者client
    */
    setPaginationType: function (type) {
        this.paginationType = type;
    },
    /**
    *设置ajax pose请求时候附带的参数
    */
    set: function (key, value) {
        if (typeof key == "object") {
            for (var i in key) {
                if (typeof i == "function") {
                    continue;
                    this.data[i] = key[i];
                }
            }
        }
        else {
            this.data[key] = (typeof value == "undefind") ? $("#" + key).val() : value;
        }
        return this;
    },
    /**
    *设置ajax post请求时候附带的参数
    */
    setData: function (data) {
        this.data = data;
        return this;
    },
    /**
    *刷新bootstrap表格
    */
    refresh: function (params) {
        if (typeof parms != "undefined") {
            this.btInstance.bootstrapTable('refresh', parms);
        }
        else {
            this.btInstance.bootstrapTable('refresh');
        }
    }
};

/**
*关闭弹出层
*/
MF.CloseDialog = function(id)
{
    var index =parent.layer.getFrameIndex(window.name);//先得到当前iframe层的索引
    parent.layer.close(index);
}
/**
 * 调用父页面的刷新方法
 */
$.extend({
    refreshParent: function () {
        debugger;
        var iframe = top.window.frames[0];

        iframe.returns();
    }
});
