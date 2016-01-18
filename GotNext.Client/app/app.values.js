var app;
(function (app) {
    var values;
    (function (values) {
        (function () {
            'use strict';
            var currentUser = {
                userId: ''
            };
            angular
                .module('app')
                .value('currentUser', currentUser);
        })();
    })(values = app.values || (app.values = {}));
})(app || (app = {}));
//# sourceMappingURL=app.values.js.map