module app.services {
    'use strict';

    export interface IUserService {
        getById(userId: string): ng.IPromise<domain.IUser>;
    }

    class UserService implements IUserService {

        static $inject: string[] = ['$http'];
        constructor(private $http: ng.IHttpService) {
        }

        getById(userId: string): ng.IPromise<domain.IUser> {
            return this.$http.get('/api/users/' + userId)
                .then((response: ng.IHttpPromiseCallbackArg<domain.IUser>): domain.IUser => {
                return response.data;
            });
        }
    }

    angular
        .module('app.services')
        .service('userService',
            UserService);
} 