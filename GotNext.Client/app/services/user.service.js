var app;
(function (app) {
    var services;
    (function (services) {
        'use strict';
        var UserService = (function () {
            function UserService($http) {
                var _this = this;
                this.$http = $http;
                this.getById = function (userId) {
                    return _this.$http.get('/api/users/' + userId)
                        .then(function (response) {
                        return response.data;
                    });
                };
            }
            UserService.$inject = ['$http'];
            return UserService;
        })();
        angular
            .module('app.services')
            .service('userService', UserService);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
