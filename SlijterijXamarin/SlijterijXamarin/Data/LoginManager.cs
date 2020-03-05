using Slijterij.Models;
using SlijterijXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlijterijXamarin.Data
{
    public class LoginManager
    {
        ILoginService loginService;
        public LoginManager(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public Task RegisterTaskAsync(Employee employee)
        {
            return loginService.Register(employee);
        }
        public Task<bool> LoginTaskAsync(Employee employee)
        {
            return loginService.Login(employee);
        }
        public Task LogoutTask()
        {
            return loginService.Logout();
        } 
    }
}
