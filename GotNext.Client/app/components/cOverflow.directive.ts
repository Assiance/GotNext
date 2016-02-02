//module app.components {
//    'use strict';

//    angular
//        .module('app.components')
//        .directive('cOverflow', slugCheck);

//    slugCheck.$inject = ['scrollService'];
//    function slugCheck(scrollService: any): ng.IDirective {
//        var directive = <ng.IDirective> {
//            restrict: 'C',
//            link: link
//        };

//        function link(scope: ng.IScope, element: ng.IAugmentedJQuery): void {
//            if (!$('html').hasClass('ismobile')) {
//                scrollService.malihuScroll(element, 'minimal-dark', 'y');
//            }
//        }

//        return directive;
//    }
//}