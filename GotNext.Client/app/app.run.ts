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
        'currentUser'
    ];

    function run($rootScope: ng.IRootScopeService,
        $cookies: IAppCookies,
        currentUser: app.values.ICurrentUser): void {

        $rootScope.$on('$routeChangeError', (): void => {
        });

        currentUser.userId = $cookies.userId; // Look into what this is doing
    }
})();