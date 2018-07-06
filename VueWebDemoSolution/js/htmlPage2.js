/// <reference path="jquery-3.3.1.min.js" />
/// <reference path="C:\工作\SourceCode\InterfaceMonitorSolution\VueWebDemoSolution\vue2.5.16/vue.js" />

$(document).ready(function () {
    //响应式修改数据
    var app = new Vue({
        el: '#app',
        data: {
            message: 'hello vue',
            message2:'wuwei'
        }
    });
    //指令
    var app2 = new Vue({
        el: '#app2',
        data: {
            message: new Date().toLocaleString()
        }
    });
    //条件
    var app3 = new Vue({
        el: '#app3',
        data: {
            seen: true
        }
    });
    //循环
    var app4 = new Vue({
        el: '#app4',
        data: {
            todos: [
                { text: 'C#' },
                { text: 'Java' },
                { text: 'PHP' },
                { text: 'Python' },
                { text: 'C++' }
            ]
        }
    });
    var app4_2 = new Vue({
        el: '#app4-2',
        data: {
            list: [
                { name: 'Bob' },
                { name: 'John' },
                { name: 'Jack' },
                { name: 'Steven' }
            ]
        }
    });
    //处理用户输入
    var app5 = new Vue({
        el: '#app5',
        data: {
            message: 'hello vue.js'
        },
        methods: {
            reverseMessage: function () {
                this.message = this.message.split('').reverse().join('')
            }
        }
    });
    var app5_2 = new Vue({
        el: '#app5-2',
        data: {
            message: 'hello vue.js'
        }
    });
    Vue.component('todo-item', {
        props: ['todo'],
        template: '<li>{{ todo.text }}</li>'
    });

    var app7 = new Vue({
        el: '#app-7',
        data: {
            groceryList: [
              { id: 0, text: '蔬菜' },
              { id: 1, text: '奶酪' },
              { id: 2, text: '随便其它什么人吃的东西' }
            ]
        }
    });
});