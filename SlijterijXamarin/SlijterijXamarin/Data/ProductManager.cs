using Slijterij.Models;
using SlijterijXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SlijterijXamarin.Interfaces;

namespace SlijterijXamarin.Data
{
    public class ProductManager
    {
		IRESTService restService;

		public ProductManager(IRESTService service)
		{
			this.restService = service;
		}

		public Task<List<Product>> GetTasksAsync()
		{
			return restService.RefreshDataAsync();
		}

		public Task SaveTaskAsync(Product product, bool isNewItem = false)
		{
			return restService.SaveProduct(product, isNewItem);
		}

		public Task DeleteTaskAsync(Product product)
		{
			return restService.DeleteProduct(product.ID);
		}
	}
}
