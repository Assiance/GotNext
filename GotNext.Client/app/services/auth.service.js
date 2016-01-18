var app;
(function (app) {
    var services;
    (function (services) {
        'use strict';
        var AuthService = (function () {
            function AuthService($resource, appSettings, currentUserService) {
                var _this = this;
                this.$resource = $resource;
                this.appSettings = appSettings;
                this.currentUserService = currentUserService;
                this.login = function (user) {
                    return _this.loginRequest.loginUser(user, function (data) {
                        _this.currentUserService.setProfile(user.username, data.access_token, true);
                    }, function (response) {
                        //Login Failed Message
                    }).$promise;
                };
                this.logout = function () {
                    _this.currentUserService.resetProfile();
                };
                this.register = function (user) {
                    return _this.registerRequest.registerUser(user, function () {
                        //Registration Success Message
                    }, function () {
                        //Registration Fail Message
                    }).$promise;
                };
                this.registerRequest = this.$resource(this.appSettings.serverPath + "/api/Account/Register", null, {
                    'registerUser': { method: 'POST' }
                });
                this.loginRequest = this.$resource(this.appSettings.serverPath + "/Token", null, {
                    'loginUser': {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                        transformRequest: function (data, headersGetter) {
                            var str = [];
                            for (var d in data) {
                                str.push(encodeURIComponent(d) + "=" + encodeURIComponent(data[d]));
                            }
                            return str.join("&");
                        }
                    }
                });
            }
            return AuthService;
        })();
        factory.$inject = ['$resource',
            'appSettings',
            'currentUserService'];
        function factory($resource, appSettings, currentUserService) {
            return new AuthService($resource, appSettings, currentUserService);
        }
        angular
            .module('app.services')
            .factory('authService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
