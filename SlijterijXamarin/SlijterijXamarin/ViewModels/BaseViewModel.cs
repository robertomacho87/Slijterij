using SlijterijXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace SlijterijXamarin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IErrorMessage
    {
        public string ErrorMessage { get; set; } = "error";
        private bool isBusy;
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            Debug.WriteLine($"Property {propertyName} changed");
            OnPropertyChanged(propertyName);
            return true;
        }
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

     
        void IErrorMessage.ShowError()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
