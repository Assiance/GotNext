((): void => {
    'use strict';

    angular
        .module('app')
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider: ng.ui.IStateProvider, $urlRouterProvider: ng.ui.IUrlRouterProvider): void {
        $stateProvider
            .state('app', {
                abstract: true,
                url: '/',
                views: {
                    'header': {
                        templateUrl: 'app/layout/header.html'
                    },
                    'main': {
                        templateUrl: 'app/layout/index.html'
                    },
                    'footer': {
                        templateUrl: 'app/layout/footer.html'
                    }
                }
            })
            .state('app.main', {
                abstract: true,
                url: '',
                views: {
                    'sidebar-left@app': {
                        templateUrl: 'app/layout/sidebar-left.html'
                    },
                    'chat@app': {
                        templateUrl: 'app/layout/chat.html'
                    }
                }
            })
            .state('app.noHeader', {
                abstract: true,
                url: '',
                views: {
                    'header@': {
                    },
                    'footer@': {
                    }
                }
            })
            .state('app.noHeader.login', {
                url: 'login',
                views: {
                    'main@': {
                        templateUrl: 'app/login/index.html'
                    }
                }
            });

        $urlRouterProvider.otherwise('/login');
    }
})();