﻿// recommendation
const recommApp = new Vue({
    el: '#recommApp',
    data: {
        products: []
    },
    methods: {
        view: function () {
            alert('todo');
        }
    },
    mounted() {
        this.$nextTick(function () {
            recommApp.products.push({ name: "Prod1", ur: 'todo' });
            recommApp.products.push({ name: "Prod2", ur: 'todo' });
            recommApp.products.push({ name: "Prod3", ur: 'todo' });
            recommApp.products.push({ name: "Prod4", ur: 'todo' });
            recommApp.products.push({ name: "Prod5", ur: 'todo' });
            recommApp.products.push({ name: "Prod6", ur: 'todo' });
            //axios.get('/api/products/categories')
            //    .then(function (r) {
            //        if (r && r.data) {
            //            r.data.forEach(p => {
            //                catApp.categories.push(p);
            //            });
            //        }
            //    })
            //    .catch(function (error) {
            //        console.log(error);
            //    });
        });
    }
});