module app.components {
    'use strict';

    angular
        .module('app.components')
        .directive('btn', btn);

    function btn(): ng.IDirective {
        var directive = <ng.IDirective>{
            restrict: 'C',
            link: link
        };

        function link(scope: ng.IScope, element: ng.IAugmentedJQuery): void {
            var myWindow: any = window;

            if (element.hasClass('btn-icon') || element.hasClass('btn-float')) {
                myWindow.Waves.attach(element, ['waves-circle']);
            }

            else if (element.hasClass('btn-light')) {
                myWindow.Waves.attach(element, ['waves-light']);
            }

            else {
                myWindow.Waves.attach(element);
            }

            myWindow.Waves.init();
        }

        return directive;
    }
}