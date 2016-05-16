using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationTemplate.Models.Sales;

namespace WebApplicationTemplate.Repositories.Sales
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAll();

		Product GetObject(int productId);
	}
}