var app;
(function (app) {
    var domain;
    (function (domain) {
        'use strict';
        var LoginUser = (function () {
            function LoginUser(userId, firstName, lastName) {
                this.userId = userId;
                this.firstName = firstName;
                this.lastName = lastName;
            }
            return LoginUser;
        })();
        domain.LoginUser = LoginUser;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
