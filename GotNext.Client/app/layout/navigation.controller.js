var app;
(function (app) {
    var layout;
    (function (layout) {
        'use strict';
        var NavigationController = (function () {
            function NavigationController(currentUser, userService) {
                var vm = this;
                userService.getById(currentUser.userId)
                    .then(function (user) {
                    vm.fullName = user.firstName + ' ' + user.lastName;
                });
            }
            NavigationController.$inject = [
                'currentUser',
                'userService'];
            return NavigationController;
        })();
        angular
            .module('app.layout')
            .controller('navigationController', NavigationController);
    })(layout = app.layout || (app.layout = {}));
})(app || (app = {}));
//# sourceMappingURL=navigation.controller.js.map