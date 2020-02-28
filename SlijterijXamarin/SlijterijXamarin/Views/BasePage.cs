using SlijterijXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SlijterijXamarin.Views
{
    public class BasePage<T> : ContentPage where T : BaseViewModel, new()
    {
        private T viewModel;
        public T ViewModel
        {
            get => viewModel;
            set
            {
                viewModel = value;
                BindingContext = viewModel;
            }
        }

        public BasePage()
        {
            ViewModel = new T();
        }

        public void ShowError()
            => DisplayAlert("Error", ViewModel.ErrorMessage, "ok");
    }
}
