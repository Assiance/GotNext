var app;
(function (app) {
    var domain;
    (function (domain) {
        'use strict';
        var RegisterUser = (function () {
            function RegisterUser(userId, firstName, lastName) {
                this.userId = userId;
                this.firstName = firstName;
                this.lastName = lastName;
            }
            return RegisterUser;
        })();
        domain.RegisterUser = RegisterUser;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
