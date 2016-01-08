module app.domain {
    'use strict';

    export interface IProfile {
        isLoggedIn: boolean;
        username: string;
        token: string;
    }

    export class Profile implements IProfile {
        isLoggedIn = false;
        username = '';
        token = '';
    }
}