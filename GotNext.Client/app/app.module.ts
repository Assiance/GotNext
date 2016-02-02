((): void => {
    'use strict';

    angular.module('app', [
        'app.core',
        'app.domain',
        'app.main',
        'app.layout',
        'app.services',
        'app.components',
        'app.blocks',
        /*
     *  Feature Areas
     */
        'app.dashboard',
        'app.sitesettings',
        'app.login',
        'app.example'
    ]);
})(); 