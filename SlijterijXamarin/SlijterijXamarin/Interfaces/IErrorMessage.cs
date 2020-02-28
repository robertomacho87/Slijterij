using System;
using System.Collections.Generic;
using System.Text;

namespace SlijterijXamarin.Interfaces
{
    public interface IErrorMessage
    {
        string ErrorMessage { get; set; }
        void ShowError();
    }
}
