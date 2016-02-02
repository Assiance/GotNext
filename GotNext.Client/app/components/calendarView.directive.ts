module app.components
{
    'use strict';

    angular
        .module('app.components')
        .directive('calendarView', calendarView);

    function calendarView(): ng.IDirective {
        var directive = <ng.IDirective> {
            restrict: 'A',
            link: link
        };

        function link(scope: ng.IScope, element: ng.IAugmentedJQuery, attrs: any): void {
            var myJquery: any = $;

            element.on('click', function () {
                myJquery('#calendar').fullCalendar('changeView', attrs.calendarView);
            });
        }

        return directive;
    }
}