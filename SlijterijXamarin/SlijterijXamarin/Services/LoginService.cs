using Newtonsoft.Json;
using Slijterij.Models;
using SlijterijXamarin.Commons;
using SlijterijXamarin.Interfaces;
using SlijterijXamarin.Models;
using SlijterijXamarin.Services.RequestProvider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SlijterijXamarin.Services
{
    public class LoginService : ILoginService
    {
        
        private IRequestProvider _client;

        public LoginService(IRequestProvider client)
        {
            _client = client;
        }

        public async Task<bool> Login(Employee employee)
        {
            //var uri = new Uri(string.Format(Constants.AuthUrl, string.Empty));
            var uri = Constants.AuthUrl;


            try
            {
                //var json = JsonConvert.SerializeObject(employee);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");

                EmployeeDto response = null;
                
                response = await _client.LoginAsync<EmployeeDto>(uri, employee, token: Constants.BearerToken);              
                
                if (response != null  )
                {
                    Constants.BearerToken = response.Token;
                
                    Debug.WriteLine(@"\Login was successfull.");
                    return true;
         
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return false;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task Register(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
