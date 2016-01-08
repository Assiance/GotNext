module app.domain {
    'use strict';

    export interface IUser {
        userId: number;
        firstName: string;
        lastName: string;
    }

    export class User implements IUser {

        constructor(public userId: number,
            public firstName: string,
            public lastName: string) {

        }
    }
}