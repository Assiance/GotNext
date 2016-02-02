((): void => {
    'use strict';

    angular.module('app.core', [
        /*
         *  Angular Modules
         */
        'ngSanitize',
        'ngCookies',
        'ngResource',
        /*
         *  3rd Party Modules
         */
        'LocalStorageModule',
        'ngAnimate',
        'ngResource',
        'ui.router',
        'ui.bootstrap',
        'angular-loading-bar',
        'oc.lazyLoad',
        //'nouislider',
        'ngTable'
    ]);
})();
