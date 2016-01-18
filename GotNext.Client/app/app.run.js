(function () {
    'use strict';
    angular
        .module('app')
        .run(run);
    run.$inject = [
        '$rootScope',
        '$cookies',
        'currentUser'
    ];
    function run($rootScope, $cookies, currentUser) {
        $rootScope.$on('$routeChangeError', function () {
        });
        currentUser.userId = $cookies.userId; // Look into what this is doing
    }
})();
//# sourceMappingURL=app.run.js.map