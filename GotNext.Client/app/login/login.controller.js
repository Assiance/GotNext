var app;
(function (app) {
    var login;
    (function (login) {
        'use strict';
        var LoginController = (function () {
            function LoginController(currentUserService, authService, location, registerEmail, registerPassword, registerConfirmPassword, registerFirstName, registerLastName, registerDob, loginUsername, loginPassword) {
                this.currentUserService = currentUserService;
                this.authService = authService;
                this.location = location;
                this.registerEmail = registerEmail;
                this.registerPassword = registerPassword;
                this.registerConfirmPassword = registerConfirmPassword;
                this.registerFirstName = registerFirstName;
                this.registerLastName = registerLastName;
                this.registerDob = registerDob;
                this.loginUsername = loginUsername;
                this.loginPassword = loginPassword;
            }
            LoginController.prototype.registerUser = function () {
                var _this = this;
                var registerer = new app.domain.RegisterUser(this.registerFirstName, this.registerLastName, this.registerEmail, this.registerDob, this.registerPassword);
                this.authService.register(registerer).then(function (data) {
                    _this.registerConfirmPassword = "";
                    _this.loginUsername = _this.registerEmail;
                    _this.loginPassword = _this.registerPassword;
                    _this.login();
                }, function (response) {
                    alert('Fail Reg');
                });
            };
            LoginController.prototype.login = function () {
                var _this = this;
                var unloggedInUser = new app.domain.LoginUser(this.loginUsername, this.loginPassword);
                this.authService.login(unloggedInUser).then(function (data) {
                    _this.location.path('/');
                }, function (response) {
                });
            };
            LoginController.$inject = [
                'currentUserService',
                'authService',
                '$location'];
            return LoginController;
        })();
        angular
            .module('app.login')
            .controller('loginController', LoginController);
    })(login = app.login || (app.login = {}));
})(app || (app = {}));
