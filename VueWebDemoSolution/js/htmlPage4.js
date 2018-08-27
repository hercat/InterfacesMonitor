/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\VueWebDemoSolution\vue2.5.16/vue.js" />

$(function () {
    var app = new Vue({
        el: '#app',
        data: {
            header:'This is title',
            message: 'hello Vue.js'
        }
    });
    app.message = "修改后的message的值";
    app.header = "修改后的header的值";

    var app2 = new Vue({
        el: '#app2',
        data: {
            title: 'This is title',
            content: 'this is the content text.'
        }
    });
    app2.title = "新消息";
    var app3 = new Vue({
        el: '#app3',
        data: {
            message: '页面加载于' + new Date().toLocaleString()
        }
    });

    var app4 = new Vue({
        el: '#app4',
        data: {
            seen: true
        }
    });

    var app5 = new Vue({
        el: '#app5',
        data: {
            items: [
                { text: '学习JavaScript' },
                { text: '学习Vue' },
                { text: '搞个牛逼的项目' }
            ]
        }
    });

    var app6 = new Vue({
        el: '#app6',
        data: {
            message: '逆转消息内容'
        },
        methods: {
            reverseMessage: function () {
                this.message = this.message.split('').reverse().join('');
            }
        }
    });

    var app7 = new Vue({
        el: '#app7',
        data: {
            message:'hello Vue!'
        }
    });
    
    Vue.component('todo-item', {
        template: '<li>这是个待办项</li>'
    });
    
    var app8 = new Vue({
        el: '.app8',
        data: {
            message:'class test'
        }
    })
});
