 module app.sitesettings {
     'use strict';

     interface ISiteSettingsViewModel {
         title: string;
         description: string;
         themeNames: string[];
         themeName: string;
         save(): void;
     }

     class SiteSettingsController implements ISiteSettingsViewModel {

         static $inject: string[] = [''];
         constructor(public title: string,
             public description: string,
             public themeNames: string[],
             public themeName: string) {
         }

         save(): void { }
     }

     angular
         .module('app.sitesettings')
         .controller('siteSettingsController',
             SiteSettingsController);
 }