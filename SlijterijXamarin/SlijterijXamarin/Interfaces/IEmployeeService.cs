using Slijterij.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlijterijXamarin.Interfaces
{
    public interface IEmployeeService
    {
        Employee Authenticate(string username, string password);
        IEnumerable<Employee> GetAll();
    }
}
