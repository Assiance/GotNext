((): void => {
    'use strict';

    angular
        .module('app.example')
        .config(config);

    config.$inject = ['$stateProvider'];
    function config($stateProvider: ng.ui.IStateProvider): void {
        $stateProvider
            .state('app.main.example', {
                url: 'example',
                views: {
                    'content@app': {
                        templateUrl: 'app/example/index.html'
                    }
                }
            });
    }
})(); 