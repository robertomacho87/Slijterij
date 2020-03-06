using Slijterij.Models;
using SlijterijXamarin.Services;
using SlijterijXamarin.ViewModels.Base;
using SlijterijXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SlijterijXamarin.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private static ObservableCollection<Product> products;
        private static List<String> origins;
        private static List<String> whiskeyTypes;
        private static List<String> abvs;

        private IRESTService _restService;

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                RaisePropertyChanged(() => Products);
            }
        }

        private List<String> Origins
        {
            get
            {
                return origins;
            }
        }

        private List<String> ABVs
        {
            get
            {
                return abvs;
            }
        }
        private List<String> WhiskeyTypes
        {
            get
            {
                return whiskeyTypes;
            }
        }

        public Command NewProductCommand => new Command(async () => await NewProduct());
        public Command DeleteProductCommand => new Command(async () => await DeleteProduct());
        public Command SelectedProductCommand => new Command<Product>(OnListViewItemSelected);
        public Command SaveProductCommand => new Command(async () => await SaveProduct());

        public Task Initialization { get; private set; }

        public ProductViewModel(IRESTService restService)
        {
            _restService = restService;

            
                

                //Products.CollectionChanged += (sender, args) =>
                //{
                //    //Title = "Products (" + Products.Count + ")";
                //    Debug.WriteLine($"item {args.Action} + {Products.Count}");
                //};

                //GetProducts();
 
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            if (Products == null)
            {
                Products = new ObservableCollection<Product>();
            }
            // Get Catalog, Brands and Types
            var data = await _restService.RefreshProductDataAsync();
            data.ForEach(d => Products.Add(d));

            IsBusy = false;
        }

        private Task DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public  async void GetProducts()
        {
            var data = await _restService.RefreshProductDataAsync();
            data.ForEach(d => Products.Add(d));
        }   

        public async void GetOrigins()
        {
            var data = await _restService.RefreshProductDataAsync();
            data.ForEach(d => Products.Add(d));
        }

        public async Task NewProduct()
        {
            throw new NotImplementedException();
            //await App.Current.MainPage.Navigation.PushAsync(new DeckEntryPage());
        }
        public async Task SaveProduct()
        {
            throw new NotImplementedException();
            //Product product = new Product()
            //{
            //    Name = Name,
            //    Date = DateTime.UtcNow
            //};
            //try
            //{
            //    await App.Database.SaveDeckAsync(product);
            //}
            //catch (AggregateException ex)
            //{
            //    string message = string.Empty;
            //    foreach (Exception e in ex.InnerExceptions)
            //    {
            //        this.ErrorMessage += e.Message + ",";
            //    }
            //    await App.Current.MainPage.DisplayAlert("Error", message, "Ok");
            //}
            //await App.Current.MainPage.DisplayAlert("Success", "Saved Deck: " + product.Text, "Ok");
            //Name = string.Empty;
            //await App.Current.MainPage.Navigation.PopAsync();
            //Decks.Add(product);
        }

        public async void OnListViewItemSelected(Product product)
        {
            if (product != null)
            {
                //var selectedDeck = e.SelectedItem as Deck;

                //if (selectedDeck == null) return;
                // Go to deck page
                //await App.Current.MainPage.Navigation.PushAsync(new ProductDetailsPage(product));
                //{
                //    cards = product.Cards,
                //    BindingContext = product
                //});
                throw new NotImplementedException();
            }
        }
    }
}
