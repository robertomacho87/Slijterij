using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Slijterij.Models;
using SlijterijXamarin.Commons;
using SlijterijXamarin.Services;

namespace TodoREST
{
    public class RestService : IRESTService
    {
        HttpClient _client;

        public List<Product> Products { get; private set; }

        public RestService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _client = new HttpClient(clientHandler);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODMxNTExODYsImV4cCI6MTU4Mzc1NTk4NiwiaWF0IjoxNTgzMTUxMTg2fQ.MwypNRloK5GJPGWmWO1M74s5x3hyY9GZDCAlRSv6pRU");

        }

        public async Task<List<Product>> RefreshDataAsync()
        {
            Products = new List<Product>();

            var uri = new Uri(string.Format(Constants.ProductsUrl, string.Empty));
            try
            {

                
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<List<Product>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Products;
        }

        public async Task SaveProduct(Product product, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.ProductsUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\Product successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteProduct(int id)
        {
            var uri = new Uri(string.Concat(Constants.ProductsUrl, id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
