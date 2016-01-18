var app;
(function (app) {
    var domain;
    (function (domain) {
        'use strict';
        var User = (function () {
            function User(userId, firstName, lastName) {
                this.userId = userId;
                this.firstName = firstName;
                this.lastName = lastName;
            }
            return User;
        })();
        domain.User = User;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=user.model.js.map