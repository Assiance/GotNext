var app;
(function (app) {
    var services;
    (function (services) {
        'use strict';
        var CurrentUserService = (function () {
            function CurrentUserService(profile) {
                var _this = this;
                this.profile = profile;
                this.resetProfile = function () {
                    _this.profile.isLoggedIn = false;
                    _this.profile.token = "";
                    _this.profile.username = "";
                };
            }
            CurrentUserService.prototype.setProfile = function (username, token, isLoggedIn) {
                this.profile.username = username;
                this.profile.token = token;
                this.profile.isLoggedIn = isLoggedIn;
            };
            CurrentUserService.prototype.getProfile = function () {
                return this.profile;
            };
            return CurrentUserService;
        })();
        factory.$inject = [];
        function factory() {
            return new CurrentUserService(new app.domain.Profile());
        }
        angular
            .module('app.services')
            .factory('currentUserService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
