var app;
(function (app) {
    var blocks;
    (function (blocks) {
        'use strict';
        var ApiEndpointProvider = (function () {
            function ApiEndpointProvider() {
            }
            ApiEndpointProvider.prototype.configure = function (baseUrl) {
                this.config = {
                    baseUrl: baseUrl
                };
            };
            ApiEndpointProvider.prototype.$get = function () {
                return this.config;
            };
            return ApiEndpointProvider;
        })();
        angular
            .module('app.blocks')
            .provider('apiEndpoint', // Note: Do not append provider on providers
        ApiEndpointProvider);
    })(blocks = app.blocks || (app.blocks = {}));
})(app || (app = {}));
//# sourceMappingURL=apiendpoint.provider.js.map