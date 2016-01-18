interface IAppCookies {
    userId: string;
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
        '$state'
    ];

    function run($rootScope: ng.IRootScopeService, $cookies: IAppCookies, currentUserService: app.services.ICurrentUserService, $state: ng.ui.IStateService): void {
        $rootScope.$on('$stateChangeStart', (e, toState: ng.ui.IState): void => {
            var profile = currentUserService.getProfile();

            if (profile.isLoggedIn === false && toState.name !== "login") {
                e.preventDefault();
                $state.go('login');
            }
        });

        $rootScope.$on('$routeChangeError', (): void => {
        });
    }
})();