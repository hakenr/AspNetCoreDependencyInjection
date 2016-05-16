using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using WebApplicationTemplate.Models.Sales;
using WebApplicationTemplate.Repositories.Sales;

namespace WebApplicationTemplate.Services.Sales
{
	public class PriceResolver : IPriceResolver
	{
		private readonly IBasicPriceRepository basicPriceRepository;
		private readonly ICustomerProductGroupDiscountRepository customerProductGroupDiscountRepository;
		private readonly ICustomerPriceRepository customerPriceRepository;

		public PriceResolver(
			IBasicPriceRepository basicPriceRepository,
			ICustomerProductGroupDiscountRepository customerProductGroupDiscountRepository,
			ICustomerPriceRepository customerPriceRepository
			)
		{
			this.basicPriceRepository = basicPriceRepository;
			this.customerProductGroupDiscountRepository = customerProductGroupDiscountRepository;
			this.customerPriceRepository = customerPriceRepository;
		}

		// Customer individual price has priority over basic price.
		// Customer discount for product group applies to both individual and basic price.
		public decimal? GetPrice(Customer customer, Product product)
		{
			decimal? basicPrice = basicPriceRepository.GetBasicPriceForProduct(product);
			decimal? customerPrice = customerPriceRepository.GetCustomerPrice(customer, product);

			decimal? priceBeforeDiscount = customerPrice ?? basicPrice;

			if (priceBeforeDiscount != null)
			{
				decimal? customerProductGroupDiscount = null;
				if (product.ProductGroup != null)
				{
					customerProductGroupDiscount = customerProductGroupDiscountRepository.GetDiscountForCustomerAndProductGroup(customer, product.ProductGroup);
				}

				if (customerProductGroupDiscount != null)
				{
					return priceBeforeDiscount * (1 - customerProductGroupDiscount.Value);
				}

				return priceBeforeDiscount;
			}

			return null;
		}
	}
}