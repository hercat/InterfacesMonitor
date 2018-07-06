/// <reference path="jquery-3.3.1.min.js" />
/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\VueWebDemoSolution\vue2.5.16/vue.js" />

$(document).ready(function () {

    //var data = { a: 1 };
    //var vm = new Vue({
    //    data: data
    //});
    //alert(vm.a == data.a);
    //alert("修改vm.a=2前,vm.a:" + vm.a + ",data.a:" + data.a);
    //vm.a = 2;
    //alert("修改vm.a=2后,vm.a:" + vm.a + ",data.a:" + data.a);
    //data.a = 3;
    //alert("修改data.a=3后,vm.a:" + vm.a + ",data.a:" + data.a);
    //vm.b = "hi";
    //alert("添加vm.b='hi'后,vm.b:" + vm.b + ",data.b:" + data.b);

    //var obj = { foo: 'bar' };
    //Object.freeze(obj);
    //new Vue({
    //    el: '#app',
    //    data: obj,
    //    methods: {
    //        changeIt: function () {
    //            data.foo = 'baz'
    //        }
    //    }
    //});

    var vm = new Vue({
        data: {
            a: 1
        },
        created: function () {
            console.log('a is:' + this.a);
        }
    });
    vm.$watch('a', function (newValue, oldValue) {
        console.log('oldValue is:' + oldValue + ",newValue is:" + newValue);
    });
    vm.a = 3;

});
