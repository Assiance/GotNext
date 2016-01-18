module app.domain {
    'use strict';

    export interface ILoginUser {
        username: string;
        password: string;
        grant_type: string;
    }

    export class LoginUser implements ILoginUser {
        public grant_type: string;

        constructor(public username: string,
            public password: string) {
            this.grant_type = "password";
        }
    }
}