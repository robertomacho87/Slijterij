using Slijterij.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SlijterijXamarin.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private static ObservableCollection<Product> products;
        private static List<String> origins;
        private static List<String> whiskeyTypes;
        private static List<String> abvs;

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                SetProperty(ref products, value);
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

        public Command NewProductCommand { get; }
        public Command DeleteProductCommand { get; }
        public Command SelectedProductCommand { get; }
        public Command SaveProductCommand { get; }

        public Task Initialization { get; private set; }

        public ProductViewModel()
        {
            ErrorMessage = "Product Overview Error";

            if (Products == null)
            {
                Products = new ObservableCollection<Product>();

                Products.CollectionChanged += (sender, args) =>
                {
                    Title = "Products (" + Products.Count + ")";
                    Debug.WriteLine($"item {args.Action} + {Products.Count}");
                };

                GetProducts();
            }

            SaveProductCommand = new Command(async () => await SaveProduct());
            NewProductCommand = new Command(async () => await NewProduct());
            DeleteProductCommand = new Command(async () => await DeleteProduct());
            SelectedProductCommand = new Command<Product>(OnListViewItemSelected);
        }

        private Task DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public async void GetProducts()
        {
            var data = await App.ProdManager.GetTasksAsync();
            data.ForEach(d => Products.Add(d));
        }

        public async void GetOrigins()
        {
            var data = await App.ProdManager.GetTasksAsync();
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
                //await App.Current.MainPage.Navigation.PushAsync(new DeckPage
                //{
                //    cards = product.Cards,
                //    BindingContext = product
                //});
                throw new NotImplementedException();
            }
        }
    }
}
