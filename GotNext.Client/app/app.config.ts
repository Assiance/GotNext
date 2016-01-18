((): void => {
    'use strict';

    angular
        .module('app')
        .config(config);

    config.$inject = [
        '$httpProvider'
    ];

    function config($httpProvider: ng.IHttpProvider): void {
        $httpProvider.interceptors.push('authInterceptorService');
    }
})();