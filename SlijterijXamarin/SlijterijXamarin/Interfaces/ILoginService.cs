using Slijterij.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlijterijXamarin.Interfaces
{
    public interface ILoginService
    {
        Task Register(Employee employee);
        Task<bool> Login(Employee employee);
        Task Logout();
    }
}
