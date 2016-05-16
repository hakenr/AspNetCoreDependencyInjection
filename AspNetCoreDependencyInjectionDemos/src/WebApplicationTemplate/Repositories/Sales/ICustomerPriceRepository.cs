using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationTemplate.Models.Sales;

namespace WebApplicationTemplate.Repositories.Sales
{
	public interface ICustomerPriceRepository
	{
		decimal? GetCustomerPrice(Customer customer, Product product);
	}
}