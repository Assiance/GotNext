((): void => {
    'use strict';

    angular
        .module('app.example')
        .config(config);

    config.$inject = ['$stateProvider'];
    function config($stateProvider: ng.ui.IStateProvider): void {
        $stateProvider
            .state('example', {
                url: '/example',
                templateUrl: 'app/example/index.html',
                controller: 'exampleController',
                controllerAs: 'vm'
                // resolve: '' use resolves for loading start up data. ex) Edit Pages
            });
    }
})(); 