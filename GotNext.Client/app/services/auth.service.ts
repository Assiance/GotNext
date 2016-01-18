module app.services {
    'use strict';

    export interface IAuthService {
        login(user: domain.ILoginUser): ng.IPromise<any>;
        logout(): void;
        register(registerer: domain.IRegisterUser): ng.IPromise<any>;
    }

    class AuthService implements IAuthService {
        constructor(public $resource: ng.resource.IResourceService, public appSettings: constants.IAppSettings, public currentUserService: services.ICurrentUserService) {
        }

        login = (user: domain.ILoginUser): ng.IPromise<any> => {
            return this.loginRequest.loginUser(user, (data) => {
                this.currentUserService.setProfile(user.username, data.access_token, true);
            }, (response) => {
                //Login Failed Message
            }).$promise;
        }

        logout = (): void => {
            this.currentUserService.resetProfile();
        }

        register = (user: domain.IRegisterUser): ng.IPromise<any> => {
            return this.registerRequest.registerUser(user, () => {
                //Registration Success Message
            }, () => {
                //Registration Fail Message
            }).$promise;
        }

        registerRequest: any = this.$resource(this.appSettings.serverPath + "/api/Account/Register", null, {
            'registerUser': { method: 'POST' }
        });

        loginRequest: any = this.$resource(this.appSettings.serverPath + "/Token", null, {
            'loginUser': {
                method: 'POST',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                transformRequest: function (data, headersGetter) {
                    var str = [];
                    for (var d in data) {
                        str.push(encodeURIComponent(d) + "=" + encodeURIComponent(data[d]));
                    }

                    return str.join("&");
                }
            }
        });
    }

    factory.$inject = ['$resource',
        'appSettings',
        'currentUserService'];
    function factory($resource: ng.resource.IResourceService, appSettings: constants.IAppSettings, currentUserService: services.ICurrentUserService): IAuthService {
        return new AuthService($resource, appSettings, currentUserService);
    }

    angular
        .module('app.services')
        .factory('authService',
        factory);
} 