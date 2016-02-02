interface IAppCookies {
    userId: string;
}

interface IRootScope extends ng.IRootScopeService {
    $state: ng.ui.IState;
    $stateParams: ng.ui.IStateParamsService;
}

((): void => {
    'use strict';

    angular
        .module('app')
        .run(run);

    run.$inject = [
        '$rootScope',
        '$cookies',
        'currentUserService',
        '$state',
        '$stateParams'
    ];

    function run($rootScope: IRootScope, $cookies: IAppCookies, currentUserService: app.services.ICurrentUserService, $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService): void {
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

        console.log($state);

        $rootScope.$on('$stateChangeStart', (e, toState: ng.ui.IState): void => {
            var profile = currentUserService.getProfile();

            if (profile.isLoggedIn === false && toState.name !== "app.noHeader.login") {
                e.preventDefault();
                $state.go('app.noHeader.login');
            }
        });

        $rootScope.$on('$routeChangeError', (): void => {
        });
    }
})();