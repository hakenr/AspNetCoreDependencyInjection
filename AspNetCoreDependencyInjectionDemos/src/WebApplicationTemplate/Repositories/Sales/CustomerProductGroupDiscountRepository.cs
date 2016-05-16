using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using WebApplicationTemplate.Models;
using WebApplicationTemplate.Models.Sales;

namespace WebApplicationTemplate.Repositories.Sales
{
	public class CustomerProductGroupDiscountRepository : ICustomerProductGroupDiscountRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public CustomerProductGroupDiscountRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public decimal? GetDiscountForCustomerAndProductGroup(Customer customer, ProductGroup productGroup)
		{
			return applicationDbContext.CustomerProductGroupDiscounts
				.SingleOrDefault(d => (d.Customer.CustomerId == customer.CustomerId) && (d.ProductGroup.ProductGroupId == productGroup.ProductGroupId))?.Discount;
		}
	}
}