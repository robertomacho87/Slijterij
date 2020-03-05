using SlijterijXamarin.Commons;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SlijterijXamarin.Services
{
    public static class Client //: HttpClient
    {
        private static readonly HttpClientHandler _handler;
        private static readonly HttpClient _client;

        static Client()
        {
            _handler = new HttpClientHandler();
            _handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>  true;
            _client = new HttpClient(_handler);


            if (!String.IsNullOrEmpty(Constants.BearerToken))
            {
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Constants.BearerToken);
            }
        }

        public static HttpClient Get => _client;

       
    }
}
