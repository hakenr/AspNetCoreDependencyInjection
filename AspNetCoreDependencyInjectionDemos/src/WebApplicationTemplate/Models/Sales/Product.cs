using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplicationTemplate.Models.Sales
{
	public class Product
	{
		public int ProductId { get; set; }

		public string ProductNumber { get; set; }

		public ProductGroup ProductGroup { get; set; }
	}
}