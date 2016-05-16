using System.Linq;
using WebApplicationTemplate.Models.Sales;

namespace WebApplicationTemplate.Models
{
	public static class ApplicationDbContextExtensions
	{
		public static void EnsureSeedData(this ApplicationDbContext context)
		{
			if (!context.Customers.Any())
			{
				var customerHavit = new Customer() { Name = "HAVIT" };
				var customerGopas = new Customer() { Name = "Gopas" };
				context.Customers.Add(customerHavit);
				context.Customers.Add(customerGopas);
				context.SaveChanges();

				var productGroupSoftware = new ProductGroup() { Name = "Software"};
				var productGroupConsulting = new ProductGroup() { Name = "Consulting" };
				context.ProductGroups.Add(productGroupSoftware);
				context.ProductGroups.Add(productGroupConsulting);
				context.SaveChanges();

				var productSw1 = new Product() { ProductNumber = "SW1", ProductGroup = productGroupSoftware };
				var productCn1 = new Product() { ProductNumber = "CN1", ProductGroup = productGroupConsulting };
				context.Products.Add(productSw1);
				context.Products.Add(productCn1);
				context.SaveChanges();

				context.BasicPrices.Add(new BasicPrice() { Product = productSw1, Price = 10.0M });
				context.BasicPrices.Add(new BasicPrice() { Product = productCn1, Price = 20.0M });
				context.SaveChanges();

				context.CustomerProductGroupDiscounts.Add(new CustomerProductGroupDiscount() { Customer = customerHavit, ProductGroup = productGroupSoftware, Discount = 0.1M });
				context.SaveChanges();

				context.CustomerPrices.Add(new CustomerPrice() { Customer = customerHavit, Product = productSw1, Price = 9.50M });
				context.SaveChanges();
			}
		}
		
	}
}