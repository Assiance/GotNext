(function () {
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
    function run($rootScope, $cookies, currentUserService, $state) {
        $rootScope.$on('$stateChangeStart', function (e, toState) {
            var profile = currentUserService.getProfile();
            if (profile.isLoggedIn === false && toState.name !== "login") {
                e.preventDefault();
                $state.go('login');
            }
        });
        $rootScope.$on('$routeChangeError', function () {
        });
    }
})();
