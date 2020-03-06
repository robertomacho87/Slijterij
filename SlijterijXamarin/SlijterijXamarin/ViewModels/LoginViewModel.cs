
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SlijterijXamarin.Commons;
using Slijterij.Models;
using SlijterijXamarin.Validations;
using SlijterijXamarin.Interfaces;
using SlijterijXamarin.ViewModels.Base;

namespace SlijterijXamarin.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private ILoginService _loginService;
        private INavigationService _navigationService;

        //ValidatableObject<string>
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;

        private bool _isValid;
        private bool _isLogin;


        public LoginViewModel(ILoginService loginService, INavigationService navigationService
           )
        {
            _navigationService = navigationService;
            _loginService = loginService;
            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();


            AddValidations();
        }

        public ValidatableObject<string> UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                RaisePropertyChanged(() => UserName);
            }
        }

        public ValidatableObject<string> Password
        {
            get
            {
                return _password;
            }
            set
            {
                RaisePropertyChanged(() => Password);
            }
        }


        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                RaisePropertyChanged(() => IsValid);
            }
        }

        public bool IsLogin
        {
            get
            {
                return _isLogin;
            }
            set
            {
                RaisePropertyChanged(() => IsLogin);
            }
        }


        public ICommand SignInCommand => new Command(async () => await SignInAsync());

        public ICommand RegisterCommand => new Command(Register);

        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());



        private async Task SignInAsync()
        {
            IsBusy = true;

            await Task.Delay(10);
            Employee employee = new Employee { Username = UserName.Value, Password = Password.Value };
            await _loginService.Login(employee);

            // Navigate mainpage;
            IsValid = true;
            IsLogin = true;
            IsBusy = false;

            await _navigationService.NavigateToAsync<ProductViewModel>();

            //LoginUrl = _identityService.CreateAuthorizationRequest();


        }

        private async void Register()
        {
            Employee employee = new Employee { Username = UserName.Value, Password = Password.Value };
            await _loginService.Register(employee);
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();

            return isValidUser && isValidPassword;
        }

        private bool ValidateUserName()
        {
            return _userName.Validate();
        }

        private bool ValidatePassword()
        {

            return _password.Validate();
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
        }


    }
}