using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Slijterij.Helpers;
using Slijterij.Models;
using Slijterij.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Slijterij.DAL;

namespace Slijterij.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employees = new List<Employee>();
        private WhiskeyContext _context;
       
        //private readonly AppSettings _appSettings;

        public EmployeeService(WhiskeyContext context)
        {
            _context = context;
            //_appSettings = appSettings.Value; IOptions<AppSettings> appSettings,
        }
        public Employee Authenticate(string username, string password)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (employee == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, employee.PasswordHash, employee.PasswordSalt))
                return null;


            //// authentication successful so generate jwt token
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, employee.ID.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //employee.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            //employee.Password = null;

            return employee;

        }

        public Employee Create(Employee employee, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Employees.Any(x => x.Username == employee.Username))
                throw new AppException("Username \"" + employee.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            employee.PasswordHash = passwordHash;
            employee.PasswordSalt = passwordSalt;

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void Update(Employee employeeParams, string password = null)
        {
            var employee = _context.Employees.Find(employeeParams.Id);

            if (employee == null)
                throw new AppException("User not found");

            if (employeeParams.Username != employee.Username)
            {
                // username has changed so check if the new username is already taken
                if (_context.Employees.Any(x => x.Username == employeeParams.Username))
                    throw new AppException("Username " + employeeParams.Username + " is already taken");
            }

            // update user properties
            employee.FirstName = employeeParams.FirstName;
            employee.LastName = employeeParams.LastName;
            employee.Username = employeeParams.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                employee.PasswordHash = passwordHash;
                employee.PasswordSalt = passwordSalt;
            }

            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
