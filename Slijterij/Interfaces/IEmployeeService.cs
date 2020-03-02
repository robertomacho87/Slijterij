using Slijterij.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slijterij.Interfaces
{
    public interface IEmployeeService
    {
        Employee Authenticate(string username, string password);
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Create(Employee employee, string password);
        void Update(Employee employee, string password = null);
        void Delete(int id);
    }
}
