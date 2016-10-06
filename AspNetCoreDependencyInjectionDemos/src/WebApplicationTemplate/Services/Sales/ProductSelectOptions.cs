using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationTemplate.Repositories.Sales;

namespace WebApplicationTemplate.Services.Sales
{
	public class ProductSelectOptions : IProductSelectOptions
	{
		private readonly IProductRepository productRepository;

		public ProductSelectOptions(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		public IEnumerable<SelectListItem> GetSelectListItems()
		{
			return productRepository.GetAll().Select(product => new SelectListItem() { Value = product.ProductId.ToString(), Text = product.ProductNumber });
		}
	}
}