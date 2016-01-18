var app;
(function (app) {
    var domain;
    (function (domain) {
        'use strict';
        var Profile = (function () {
            function Profile() {
                this.isLoggedIn = false;
                this.username = '';
                this.token = '';
            }
            return Profile;
        })();
        domain.Profile = Profile;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
//# sourceMappingURL=profile.js.map