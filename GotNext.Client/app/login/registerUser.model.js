var app;
(function (app) {
    var domain;
    (function (domain) {
        'use strict';
        var RegisterUser = (function () {
            function RegisterUser(firstName, lastName, email, dateOfBirth, password) {
                this.firstName = firstName;
                this.lastName = lastName;
                this.email = email;
                this.dateOfBirth = dateOfBirth;
                this.password = password;
                this.confirmPassword = this.password;
            }
            return RegisterUser;
        })();
        domain.RegisterUser = RegisterUser;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
