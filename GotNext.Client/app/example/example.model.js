var app;
(function (app) {
    var domain;
    (function (domain) {
        'use strict';
        var Example = (function () {
            function Example(FirstName, LastName) {
                this.FirstName = FirstName;
                this.LastName = LastName;
            }
            return Example;
        })();
        domain.Example = Example;
    })(domain = app.domain || (app.domain = {}));
})(app || (app = {}));
