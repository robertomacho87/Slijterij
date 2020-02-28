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
        
    }
}
