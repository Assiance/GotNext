module app.main {
    'use strict';

    interface IMainViewModel {
        sidebarToggle: any;
        layoutType: string;
        sidebarStat(event: Event): any;
        currentSkin: string;
        skinList: string[];
        skinSwitch(color: string): void;
    }

    class MainController implements IMainViewModel {
        public sidebarToggle: any;
        public layoutType: string;
        public currentSkin: string;
        public skinList: string[] = [
            'lightblue',
            'bluegray',
            'cyan',
            'teal',
            'green',
            'orange',
            'blue',
            'purple'
        ];

        static $inject: string[] = ['$timeout', '$state'];
        constructor(private $timeout: ng.ITimeoutService, private $state: ng.ui.IStateService) {
            // Detact Mobile Browser
            if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
                angular.element('html').addClass('ismobile');
            }

            // By default Sidbars are hidden in boxed layout and in wide layout only the right sidebar is hidden.
            this.sidebarToggle = {
                left: false,
                right: false
            }

            // By default template has a boxed layout
            this.layoutType = localStorage.getItem('ma-layout-status');

            this.currentSkin = 'blue';
        }

        //Close sidebar on click
        sidebarStat = (event: Event) => {
            if (!angular.element(event.target).parent().hasClass('active')) {
                this.sidebarToggle.left = false;
            }
        }

        skinSwitch = (color: string): void => {
            this.currentSkin = color;
        }
    }

    angular
        .module('app.main')
        .controller('mainController',
            MainController);
} 