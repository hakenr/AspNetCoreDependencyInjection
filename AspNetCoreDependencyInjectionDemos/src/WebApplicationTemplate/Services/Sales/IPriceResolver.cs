using System;
using WebApplicationTemplate.Models.Sales;

namespace WebApplicationTemplate.Services.Sales
{
	public interface IPriceResolver
	{
		decimal? GetPrice(Customer customer, Product product);
	}
}