using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SlijterijXamarin.Commons
{
    public static class Constants
    {

        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.10.1.22:81" : "https://10.10.1.22:81";
        public static string ProductsUrl = BaseAddress + "/api/product";
        public static string AuthUrl = BaseAddress + "/employee/authenticate";
        public static string RegisterUrl = BaseAddress + "/employee/register";
        public static string BearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODM0MDc4NDMsImV4cCI6MTU4NDAxMjY0MywiaWF0IjoxNTgzNDA3ODQzfQ.ZVDKZz6q4589RjskQ9d4nLRTS45nGZ8k6hSAgeH4OC4";

    }
}
