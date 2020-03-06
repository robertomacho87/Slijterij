using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SlijterijXamarin.Services.RequestProvider;

namespace SlijterijXamarin.Services
{
    public class RESTService : IRESTService
    {
        IRequestProvider _client;
        private string BearerToken = Constants.BearerToken;

        public List<Product> Products { get; private set; }

        public RESTService(IRequestProvider client)
        {
            _client = client;        
        }

        public async Task<List<Product>> RefreshProductDataAsync()
        {
            Products = new List<Product>();

            //var uri = new Uri(string.Format(Constants.ProductsUrl, string.Empty));
            try
            {

                
                Products = await _client.GetAsync<List<Product>>(Constants.ProductsUrl, token: Constants.BearerToken);
                //if (response.IsSuccessStatusCode)
                //{
                //    var content = await response.Content.ReadAsStringAsync();
                //    Products = JsonConvert.DeserializeObject<List<Product>>(content);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Products;
        }

        

        public async Task SaveProduct(Product product, bool isNewItem = false)
        {
            //var uri = new Uri(string.Format(Constants.ProductsUrl, string.Empty));
            var uri = Constants.ProductsUrl;
            Product response = new Product();
            
            try
            {
                //var json = JsonConvert.SerializeObject(product);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");

                //HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, product,token: Constants.BearerToken);
                }
                else
                {
                    response = await _client.PutAsync(uri, product,token: Constants.BearerToken);
                }

                if (response != null)
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
            var uri = string.Concat(Constants.ProductsUrl, id);


            try
            {
                await _client.DeleteAsync(uri, Constants.BearerToken);

             

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
