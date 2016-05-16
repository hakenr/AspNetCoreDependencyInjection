using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationTemplate.Models.Sales;

namespace WebApplicationTemplate.Repositories.Sales
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetAll();

		Customer GetObject(int customerId);
	}
}