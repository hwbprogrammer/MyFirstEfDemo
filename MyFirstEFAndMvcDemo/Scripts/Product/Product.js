MF.ProductInfo = MF.Class.create();
MF.ProductInfo.prototype = {
    /**
    *初始化
    */
    init: function (options)
    {
        var me = this;
        me.bindEvent();
    },
    bindEvent: function ()
    {
        var me = this;
        //新增
        $("#add").bind("click", function ()
        {
            layer.open({
                title:'新增产品',
                area:['800px','400px'],
                type: 2,
                content: [MF.Root + 'Product/AddOrEditProduct?Node=add', 'no'], //这里content是一个URL，如果你不想让iframe出现滚动条，你还可以content: ['url', 'no']
            });
        });
        //编辑
        $("#edit").bind("click", function () {
            var row = $("#td_Product").bootstrapTable('getSelections');
            layer.open({
                title: '编辑产品',
                area: ['800px', '400px'],
                type: 2,
                content: [MF.Root + 'Product/AddOrEditProduct?ID=' + row[0].ID, 'no'],
                end: function ()
                {
                    $("#td_Product").bootstrapTable("refresh");
                }
            });
        });
        //删除
        $("#del").bind("click", function () {
            var row = $("#td_Product").bootstrapTable('getSelections');
            if(row==null||row.length==0)
            {
                layer.msg('请选中要删除的数据', {icon: 6}); 
                return;
            }
            var idList=[];
            $.each(row,function(index,data)
            {
                idList.push(data.ID);
            })
            layer.confirm('确定要删除该产品吗？', { icon: 7, title: '提示' }, function (index) {
                $.ajax({
                    type: 'POST',
                    url: MF.Root + "Product/DelProductInfo",
                    data: { idList: idList },
                    success: function (data) {
                        if (data.r == 'ok') {
                            layer.msg(data.s, { icon: 6 });
                            $("#td_Product").bootstrapTable("refresh");
                        } else {
                            layer.msg(data.s, { icon: 5 });
                        }
                    }
                });
            });
           
        });
        //查询
       
    },
    /**
    *绑定表格
    */
    initColumn: function ()
    {
        var ColumnStr = [{
            checkbox: true
        }, {
            field: 'Name',
            title: '产品名称'
        }, {
            field: 'Price',
            title: '产品价格'
        }, {
            field: 'Quantity',
            title: '产品数量'
        }
        ];
        return ColumnStr;
    }
}

MF.ProductMaintain = MF.Class.create();
MF.ProductMaintain.prototype = {
    /**
    *初始化
    */
    init: function (options) {
        var me = this;
        me.bindEvent();
    },
    bindEvent: function () {
        //保存
        $("#btnSave").bind("click", function () {
            $.ajax({
                type: "post",
                url: MF.Root + "Product/SaveProductInfo",
                data: $("body").find('form').serialize(),//表单数据
                success: function (d) {
                    if (d.r == "ok") {
                        debugger;
                        layer.msg(d.s, { icon: 6 });
                        MF.CloseDialog('dlg_Product');
                        // window.parent.location.reload();
                        //$.refreshParent();
                        window.parent.returns();
                    }
                    if (d.r == "error") {
                        layer.msg(d.s, { icon: 5 });
                    }

                }
            });
        });
    }
}