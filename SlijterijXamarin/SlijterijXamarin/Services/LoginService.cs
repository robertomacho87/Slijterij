using Newtonsoft.Json;
using Slijterij.Models;
using SlijterijXamarin.Commons;
using SlijterijXamarin.Interfaces;
using SlijterijXamarin.Models;
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
        
        private HttpClient _client;

        public LoginService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Login(Employee employee)
        {
            var uri = new Uri(string.Format(Constants.AuthUrl, string.Empty));
            
            try
            {
                var json = JsonConvert.SerializeObject(employee);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                
                response = await _client.PostAsync(uri, content);              
                
                if (response.IsSuccessStatusCode)
                {
                    var test = await response.Content.ReadAsStringAsync();
                   
                    var employeeDto = JsonConvert.DeserializeObject<EmployeeDto>(test);
                    Constants.BearerToken = employeeDto.Token;
                
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
