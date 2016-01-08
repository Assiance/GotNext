module app.domain {
    'use strict';

    // Todo: Change to lowercase props
    export interface IExampleDefinition {
        Id: number;
        FirstName: string;
        LastName: string;
    }

    export interface IExample extends IExampleDefinition, ng.resource.IResource<IExampleDefinition> {
    }

    export class Example implements IExampleDefinition {
        public Id: number;

        constructor(public FirstName: string, public LastName: string) {

        }
    }
} 