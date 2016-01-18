// Example Factory
var app;
(function (app) {
    var services;
    (function (services) {
        'use strict';
        var UserAccount = (function () {
            function UserAccount() {
            }
            return UserAccount;
        })();
        services.UserAccount = UserAccount;
        var UserAccountService = (function () {
            function UserAccountService($resource, appSettings) {
                this.$resource = $resource;
                this.appSettings = appSettings;
                this.registration = this.$resource(this.appSettings.serverPath + "/api/Account/Register", null, {
                    'registerUser': { method: 'POST' }
                });
                this.login = this.$resource(this.appSettings.serverPath + "/Token", null, {
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
                var self = this;
            }
            return UserAccountService;
        })();
        factory.$inject = [
            '$resource',
            'appSettings'
        ];
        function factory($resource, appSettings) {
            return new UserAccountService($resource, appSettings);
        }
        angular
            .module('app.services')
            .factory('userAccountService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
