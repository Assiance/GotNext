module app.example {
    'use strict';

    interface IExampleViewModel {
        examples: domain.IExample[];
    }

    class ExampleController implements IExampleViewModel {

        static $inject: string[] = ['contextService'];
        constructor(private context: services.IContextService,
            public examples: domain.IExample[]) {
            var vm = this;

            context.examples().query((data: domain.IExample[]) => {
                vm.examples = data;
            });
        }
    }

    angular
        .module('app.example')
        .controller('exampleController',
            ExampleController);
} 