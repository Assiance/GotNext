var app;
(function (app) {
    var blocks;
    (function (blocks) {
        'use strict';
        var AuthInterceptorService = (function () {
            function AuthInterceptorService(q, location, currentUserService) {
                var _this = this;
                this.q = q;
                this.location = location;
                this.currentUserService = currentUserService;
                this.request = function (config) {
                    config.headers = config.headers || {};
                    var profile = _this.currentUserService.getProfile();
                    if (profile.isLoggedIn) {
                        config.headers.Authorization = 'Bearer ' + profile.token;
                    }
                    return config;
                };
                this.responseError = function (rejection) {
                    if (rejection.status === 401) {
                        _this.location.path('/login');
                    }
                    return _this.q.reject(rejection);
                };
            }
            return AuthInterceptorService;
        })();
        factory.$inject = [
            '$q',
            '$location',
            'currentUserService'
        ];
        function factory($q, $location, currentUserService) {
            return new AuthInterceptorService($q, $location, currentUserService);
        }
        angular
            .module('app.blocks')
            .factory('authInterceptorService', factory);
    })(blocks = app.blocks || (app.blocks = {}));
})(app || (app = {}));
