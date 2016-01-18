module app.services {
    'use strict';

    export interface ICurrentUserService {
        setProfile(username: string, token: string, isLoggedIn: boolean): void;
        getProfile(): domain.IProfile;
        resetProfile(): void;
    }

    class CurrentUserService implements ICurrentUserService {
        constructor(private profile: domain.IProfile) {
        }

        setProfile(username: string, token: string, isLoggedIn: boolean): void {
            this.profile.username = username;
            this.profile.token = token;
            this.profile.isLoggedIn = isLoggedIn;
        }

        getProfile(): domain.IProfile {
            return this.profile;
        }

        resetProfile = () => {
            this.profile.isLoggedIn = false;
            this.profile.token = "";
            this.profile.username = "";
        };
    }

    factory.$inject = [];
    function factory(): ICurrentUserService {
        return new CurrentUserService(new domain.Profile());
    }

    angular
        .module('app.services')
        .factory('currentUserService',
        factory);
} 