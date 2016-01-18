var app;
(function (app) {
    var services;
    (function (services) {
        'use strict';
        var ContextService = (function () {
            function ContextService($resource) {
                this.$resource = $resource;
            }
            ContextService.prototype.examples = function () {
                return this.$resource('http://localhost:53213/api/examples/:exampleId'); //put server path in config
            };
            return ContextService;
        })();
        factory.$inject = ['$resource'];
        function factory($resource) {
            return new ContextService($resource);
        }
        angular
            .module('app.services')
            .factory('contextService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
