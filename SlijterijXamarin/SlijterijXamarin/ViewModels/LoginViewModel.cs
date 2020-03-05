
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SlijterijXamarin.Commons;
using Slijterij.Models;

namespace SlijterijXamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        //ValidatableObject<string>
        private string _userName;
        private string _password;

        private bool _isValid;
        private bool _isLogin;
        
        
        public LoginViewModel(
           )
        {
            //_userName = new ValidatableObject<string>();
            //_password = new ValidatableObject<string>();


            AddValidations();
        }

        public string UserName //ValidatableObject<string>
        {
            get
            {
                return _userName;
            }
            set
            {
                SetProperty(ref _userName, value);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetProperty(ref _password, value);
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
                SetProperty(ref _isValid, value);
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
                SetProperty(ref _isLogin, value);
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
            Employee employee = new Employee { Username = UserName, Password = Password };
            bool success = await App.LoginManager.LoginTaskAsync(employee);
            if(success)
            {
                // Navigate mainpage;
                IsValid = true;
                IsLogin = true;
                IsBusy = false;
            }
            

            //LoginUrl = _identityService.CreateAuthorizationRequest();

           
        }

        private void Register()
        {
            Employee employee = new Employee { Username = UserName, Password = Password };
            App.LoginManager.RegisterTaskAsync(employee);
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();

            return isValidUser && isValidPassword;
        }

        private bool ValidateUserName()
        {
            return false;
            //return _userName.Validate();
        }

        private bool ValidatePassword()
        {
            return false;
            //return _password.Validate();
        }

        private void AddValidations()
        {
            //_userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            //_password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
        }

      
    }
}