(function () {
    'use strict';
    angular
        .module('app')
        .config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('login', {
            url: '/login',
            templateUrl: 'app/login/index.html'
        });
        $urlRouterProvider.otherwise('/login');
    }
})();
