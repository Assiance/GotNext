module app.constants {
    export interface IAppSettings {
        serverPath: string;
    }

    ((): void => {
        'use strict';

        var appSettings: IAppSettings = {
            serverPath: 'http://localhost:53213'
        };

        angular
            .module('app')
            .constant('appSettings', appSettings);
    })();
}