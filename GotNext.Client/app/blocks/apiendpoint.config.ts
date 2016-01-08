((): void => {
    'use strict';

    angular
        .module('app.blocks')
        .config(config);

    config.$inject = ['apiEndpointProvider'];

    function config(apiEndpointProvider: app.blocks.IApiEndpointProvider): void {
        apiEndpointProvider.configure('/api');
    }
})(); 