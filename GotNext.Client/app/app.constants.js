var app;
(function (app) {
    var constants;
    (function (constants) {
        (function () {
            'use strict';
            var appSettings = {
                serverPath: 'http://localhost:53213'
            };
            angular
                .module('app')
                .constant('appSettings', appSettings);
        })();
    })(constants = app.constants || (app.constants = {}));
})(app || (app = {}));
//# sourceMappingURL=app.constants.js.map