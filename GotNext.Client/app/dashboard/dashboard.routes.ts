((): void => {
    'use strict';

    angular
        .module('app.dashboard')
        .config(config);

    config.$inject = ['$stateProvider'];
    function config($stateProvider: ng.ui.IStateProvider): void {
        $stateProvider
            .state('app.main.home', {
                url: '',
                views: {
                    'content@app': {
                        templateUrl: 'app/dashboard/index.html'
                    }
                }
            });
    }
})();