using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationTemplate.Models.Sales;

namespace WebApplicationTemplate.Repositories.Sales
{
	public interface ICustomerProductGroupDiscountRepository
	{
		decimal? GetDiscountForCustomerAndProductGroup(Customer customer, ProductGroup productGroup);
	}
}