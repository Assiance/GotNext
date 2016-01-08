module app.layout {
    'use strict';

    interface INavigationViewModel {
        fullName: string;
    }

    class NavigationController implements INavigationViewModel {
        fullName: string;

        static $inject: string[] = [
            'currentUser',
            'userService'];
        constructor(currentUser: app.values.ICurrentUser,
            userService: services.IUserService) {
            var vm = this;

            userService.getById(currentUser.userId)
                .then((user: domain.IUser): void => {
                vm.fullName = user.firstName + ' ' + user.lastName;
            });
        }
    }

    angular
        .module('app.layout')
        .controller('navigationController',
            NavigationController);
}