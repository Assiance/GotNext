module app.components {
    'use strict';

    angular
        .module('app.components')
        .directive('fgLine', fgLine);

    function fgLine(): ng.IDirective {
        var directive = <ng.IDirective> {
            restrict: 'C',
            link: link
        };

        function link(scope: ng.IScope, element: ng.IAugmentedJQuery): void {
            if ($('.fg-line')[0]) {
                $('body').on('focus', '.form-control', function () {
                    $(this).closest('.fg-line').addClass('fg-toggled');
                })

                $('body').on('blur', '.form-control', function () {
                    var p = $(this).closest('.form-group');
                    var i = p.find('.form-control').val();

                    if (p.hasClass('fg-float')) {
                        if (i.length == 0) {
                            $(this).closest('.fg-line').removeClass('fg-toggled');
                        }
                    }
                    else {
                        $(this).closest('.fg-line').removeClass('fg-toggled');
                    }
                });
            }
        }

        return directive;
    }
}