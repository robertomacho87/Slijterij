using SlijterijXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SlijterijXamarin.Services
{
    public class SettingsService : ISettingsService
    {
        private const string baseAddress = "https://10.10.1.22:81";
        private const string productsUrl = baseAddress + "/api/product";
        private const string accessToken = "access_token";

       

        public string AuthAccessToken { get => accessToken; set { accessToken = value; } }
        public bool UseMocks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BaseUrl { get => baseAddress ; set => throw new NotImplementedException(); }
    }
}
