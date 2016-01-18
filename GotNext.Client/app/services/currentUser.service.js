var app;
(function (app) {
    var services;
    (function (services) {
        'use strict';
        var CurrentUserService = (function () {
            function CurrentUserService(profile) {
                this.profile = profile;
            }
            CurrentUserService.prototype.setProfile = function (username, token) {
                this.profile.username = username;
                this.profile.token = token;
                this.profile.isLoggedIn = true;
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
//# sourceMappingURL=currentUser.service.js.map