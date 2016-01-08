module app.login {
    'use strict';

    interface ILoginViewModel {
        registerEmail: string;
        registerPassword: string;
        registerConfirmPassword: string;
        loginUsername: string;
        loginPassword: string;
        token: string;
        message: string;

        registerUser: () => void;
        login: () => void;
    }

    class LoginController implements ILoginViewModel {
        static $inject: string[] = [
            'appSettings',
            'userAccountService',
            'currentUserService'];
        constructor(public appSettings: constants.IAppSettings, public userAccountService: services.IUserAccountService, public currentUserService: services.ICurrentUserService,
            public registerEmail: string,
            public registerPassword: string,
            public registerConfirmPassword: string,
            public loginUsername: string,
            public loginPassword: string,
            public token: string,
            public message: string) {

            var vm = this;
        }

        public registerUser(): void {
            var registerer = new services.UserAccount();
            registerer.Email = this.registerEmail;
            registerer.Password = this.registerPassword;
            registerer.ConfirmPassword = this.registerConfirmPassword;

            this.userAccountService.registration.registerUser(registerer, (data) => {
                this.registerConfirmPassword = "";
                this.message = "registration successful";
                this.login();
            },
            (response) => {
                alert('Fail Reg');
            });
        }

        login(): void {
            var unloggedInUser = new services.UserAccount();
            unloggedInUser.Username = this.loginUsername;
            unloggedInUser.Email = this.loginUsername;
            unloggedInUser.Password = this.loginPassword;
            unloggedInUser.Grant_Type = "password";


            this.userAccountService.login.loginUser(unloggedInUser, (data) => {
                this.currentUserService.setProfile(this.loginUsername, this.token);
            },
            (response) => {
                alert("Fail Login");
            });
        }
    }

    angular
        .module('app.login')
        .controller('loginController',
            LoginController);
}