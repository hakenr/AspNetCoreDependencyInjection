using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationTemplate.Models;
using WebApplicationTemplate.Models.Sales;

namespace WebApplicationTemplate.Repositories.Sales
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public ProductRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public IEnumerable<Product> GetAll()
		{
			return applicationDbContext.Products.ToList();
		}

		public Product GetObject(int productId)
		{
			return applicationDbContext.Products.SingleOrDefault(p => p.ProductId == productId);
		}
	}
}