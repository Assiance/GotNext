module app.domain {
    'use strict';

    export interface IRegisterUser {
        email: string;
        password: string;
        confirmPassword: string;
        firstName: string;
        lastName: string;
        dateOfBirth: string;
    }

    export class RegisterUser implements IRegisterUser {
        public confirmPassword: string;

        constructor(public firstName: string, public lastName: string, public email: string, public dateOfBirth: string, public password: string) {
            this.confirmPassword = this.password;
        }
    }
}