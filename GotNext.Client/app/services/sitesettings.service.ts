// Example Factory
module app.services {
     'use strict';

     export interface ISiteSettingsService { }

     class SiteSettingsService implements ISiteSettingsService {

         constructor(private $http: ng.IHttpService,
             private apiEndpoint: blocks.IApiEndpointConfig) {
         }
     }

    factory.$inject = [
        '$http',
        'apiEndpoint'
    ];
    function factory($http: ng.IHttpService,
        apiEndpoint: blocks.IApiEndpointConfig): ISiteSettingsService {
         return new SiteSettingsService($http, apiEndpoint);
     }

     angular
         .module('app.services')
         .factory('siteSettingsService',
             factory);
 }