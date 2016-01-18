var app;
(function (app) {
    var domain;
    (function (domain) {
        'use strict';
        var LoginUser = (function () {
            function LoginUser(username, password) {
                this.username = username;
                this.password = password;
                this.grant_type = "password";
            }
            return LoginUser;
        })();
        domain.LoginUser = LoginUser;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
