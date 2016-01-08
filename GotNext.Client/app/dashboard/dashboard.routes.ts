((): void => {
    'use strict';

    angular
        .module('app.dashboard')
        .config(config);

    config.$inject = ['$stateProvider'];
    function config($stateProvider: ng.ui.IStateProvider): void {
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: 'app/dashboard/index.html'
            });
    }
})();