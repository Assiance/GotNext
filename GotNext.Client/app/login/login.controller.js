var app;
(function (app) {
    var login;
    (function (login) {
        'use strict';
        var LoginController = (function () {
            function LoginController(appSettings, userAccountService, currentUserService, registerEmail, registerPassword, registerConfirmPassword, loginUsername, loginPassword, token, message) {
                this.appSettings = appSettings;
                this.userAccountService = userAccountService;
                this.currentUserService = currentUserService;
                this.registerEmail = registerEmail;
                this.registerPassword = registerPassword;
                this.registerConfirmPassword = registerConfirmPassword;
                this.loginUsername = loginUsername;
                this.loginPassword = loginPassword;
                this.token = token;
                this.message = message;
                var vm = this;
            }
            LoginController.prototype.registerUser = function () {
                var _this = this;
                var registerer = new app.services.UserAccount();
                registerer.Email = this.registerEmail;
                registerer.Password = this.registerPassword;
                registerer.ConfirmPassword = this.registerConfirmPassword;
                this.userAccountService.registration.registerUser(registerer, function (data) {
                    _this.registerConfirmPassword = "";
                    _this.message = "registration successful";
                    _this.login();
                }, function (response) {
                    alert('Fail Reg');
                });
            };
            LoginController.prototype.login = function () {
                var _this = this;
                var unloggedInUser = new app.services.UserAccount();
                unloggedInUser.Username = this.loginUsername;
                unloggedInUser.Email = this.loginUsername;
                unloggedInUser.Password = this.loginPassword;
                unloggedInUser.Grant_Type = "password";
                this.userAccountService.login.loginUser(unloggedInUser, function (data) {
                    _this.currentUserService.setProfile(_this.loginUsername, _this.token);
                }, function (response) {
                    alert("Fail Login");
                });
            };
            LoginController.$inject = [
                'appSettings',
                'userAccountService',
                'currentUserService'];
            return LoginController;
        })();
        angular
            .module('app.login')
            .controller('loginController', LoginController);
    })(login = app.login || (app.login = {}));
})(app || (app = {}));
//# sourceMappingURL=login.controller.js.map