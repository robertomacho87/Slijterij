using Slijterij.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlijterijXamarin.Services
{
    public interface IRESTService
    {
        Task<List<Product>> RefreshProductDataAsync();

        Task SaveProduct(Product product, bool isNewItem);

        Task DeleteProduct(int id);


    }
}
