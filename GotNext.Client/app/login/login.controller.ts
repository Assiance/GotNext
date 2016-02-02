module app.login {
    'use strict';

    interface ILoginViewModel {
        registerEmail: string;
        registerPassword: string;
        registerConfirmPassword: string;
        loginUsername: string;
        loginPassword: string;

        registerUser: () => void;
        login: () => void;
    }

    class LoginController implements ILoginViewModel {
        static $inject: string[] = [
            'authService',
            '$location'];
        constructor(private authService: services.IAuthService, private location: ng.ILocationService,
            public registerEmail: string,
            public registerPassword: string,
            public registerConfirmPassword: string,
            public registerFirstName: string,
            public registerLastName: string,
            public registerDob: string,
            public loginUsername: string,
            public loginPassword: string) {
        }

        public registerUser(): void {
            var registerer = new domain.RegisterUser(this.registerFirstName,
                this.registerLastName,
                this.registerEmail,
                this.registerDob,
                this.registerPassword);

            this.authService.register(registerer).then((data) => {
                this.registerConfirmPassword = "";
                this.loginUsername = this.registerEmail;
                this.loginPassword = this.registerPassword;
                this.login();
            },
            (response) => {
                alert('Fail Reg');
            });
        }

        public login(): void {
            var unloggedInUser = new domain.LoginUser(this.loginUsername, this.loginPassword);

            this.authService.login(unloggedInUser).then((data) => {
                this.location.path('/');
            },
            (response) => {
            });
        }
    }

    angular
        .module('app.login')
        .controller('loginController',
            LoginController);
}