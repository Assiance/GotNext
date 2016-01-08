// Example Factory
module app.services {
    'use strict';

    //Service Model
    export interface IUserAccountDefinition {
        Username: string;
        Email: string;
        Password: string;
        ConfirmPassword: string;
        Grant_Type: string;
    }

    export interface IUserAccount extends IUserAccountDefinition, ng.resource.IResource<IUserAccountDefinition> {
    }

    export class UserAccount implements IUserAccountDefinition {
        public Username: string;
        public Grant_Type: string;
        public Email: string;
        public Password: string;
        public ConfirmPassword: string;
    }
    
    //Service
    export interface IUserAccountResource extends ng.resource.IResource<ng.resource.IResourceClass<IUserAccountDefinition>> {
        registerUser: (params: IUserAccountDefinition, success: Function, error?: Function) => IUserAccountResource
    }


    export interface IUserAccountService {
        registration: any;
        login: any;
    }

    class UserAccountService implements IUserAccountService {

        constructor(private $resource: ng.resource.IResourceService,
            private appSettings: constants.IAppSettings) {

            var self = this;
        }

        registration: any = this.$resource(this.appSettings.serverPath + "/api/Account/Register", null, {
            'registerUser': { method: 'POST' }
        });

        login: any = this.$resource(this.appSettings.serverPath + "/Token", null, {
            'loginUser': {
                method: 'POST',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                transformRequest: function(data, headersGetter) {
                    var str = [];
                    for (var d in data) {
                        str.push(encodeURIComponent(d) + "=" + encodeURIComponent(data[d]));
                    }

                    return str.join("&");
                }
            }
        });
        
    }

    factory.$inject = [
        '$resource',
        'appSettings'
    ];
    function factory($resource: ng.resource.IResourceService, appSettings: constants.IAppSettings): IUserAccountService {
        return new UserAccountService($resource, appSettings);
    }

    angular
        .module('app.services')
        .factory('userAccountService',
        factory);
}