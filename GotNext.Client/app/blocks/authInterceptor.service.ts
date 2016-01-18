module app.blocks {
    'use strict';

    export interface IAuthInterceptorService {
        request(config: any): any;
        responseError(rejection: any): any;
    }

    class AuthInterceptorService implements IAuthInterceptorService {
        constructor(private q: ng.IQService, private location: ng.ILocationService, private currentUserService: services.ICurrentUserService) {
        }

        request = (config: any): any => {

            config.headers = config.headers || {};

            var profile = this.currentUserService.getProfile();
            if (profile.isLoggedIn) {
                config.headers.Authorization = 'Bearer ' + profile.token;
            }

            return config;
        }

        responseError = (rejection: any): any => {
            if (rejection.status === 401) {
                this.location.path('/login');
            }
            return this.q.reject(rejection);
        }
    }

    factory.$inject = [
        '$q',
        '$location',
        'currentUserService'
    ];
    function factory($q: ng.IQService, $location: ng.ILocationService, currentUserService: services.ICurrentUserService): IAuthInterceptorService {
        return new AuthInterceptorService($q, $location, currentUserService);
    }

    angular
        .module('app.blocks')
        .factory('authInterceptorService',
        factory);
} 