var app;
(function (app) {
    var example;
    (function (example) {
        'use strict';
        var ExampleController = (function () {
            function ExampleController(context, examples) {
                this.context = context;
                this.examples = examples;
                var vm = this;
                context.examples().query(function (data) {
                    vm.examples = data;
                });
            }
            ExampleController.$inject = ['contextService'];
            return ExampleController;
        })();
        angular
            .module('app.example')
            .controller('exampleController', ExampleController);
    })(example = app.example || (app.example = {}));
})(app || (app = {}));
