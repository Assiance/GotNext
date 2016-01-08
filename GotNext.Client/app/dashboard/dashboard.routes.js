(function () {
    'use strict';
    angular
        .module('app.dashboard')
        .config(config);
    config.$inject = ['$stateProvider'];
    function config($stateProvider) {
        $stateProvider
            .state('home', {
            url: '/',
            templateUrl: 'app/dashboard/index.html'
        });
    }
})();
//# sourceMappingURL=dashboard.routes.js.map