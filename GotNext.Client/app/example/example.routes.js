(function () {
    'use strict';
    angular
        .module('app.example')
        .config(config);
    config.$inject = ['$stateProvider'];
    function config($stateProvider) {
        $stateProvider
            .state('example', {
            url: '/example',
            templateUrl: 'app/example/index.html',
            controller: 'exampleController',
            controllerAs: 'vm'
        });
    }
})();
