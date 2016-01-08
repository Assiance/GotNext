(function () {
    'use strict';
    angular
        .module('app.blocks')
        .config(config);
    config.$inject = ['apiEndpointProvider'];
    function config(apiEndpointProvider) {
        apiEndpointProvider.configure('/api');
    }
})();
//# sourceMappingURL=apiendpoint.config.js.map