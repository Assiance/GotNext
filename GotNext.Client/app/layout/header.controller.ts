module app.layout {
    'use strict';

    interface IHeaderViewModel {
    }

    class HeaderController implements IHeaderViewModel {

        static $inject: string[] = [];
        constructor() {
        }
    }

    angular
        .module('app.layout')
        .controller('headerController',
            HeaderController);
}