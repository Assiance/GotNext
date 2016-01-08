module app.services {
    'use strict';

    export interface ICurrentUserService {
        setProfile(username: string, token: string): void;
        getProfile(): domain.IProfile;
    }

    class CurrentUserService implements ICurrentUserService {
        constructor(private profile: domain.IProfile) {
        }

        setProfile(username: string, token: string): void {
            this.profile.username = username;
            this.profile.token = token;
            this.profile.isLoggedIn = true;
        }

        getProfile(): domain.IProfile {
            return this.profile;
        }
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