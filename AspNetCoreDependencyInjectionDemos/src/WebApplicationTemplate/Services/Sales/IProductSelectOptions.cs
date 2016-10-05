using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationTemplate.Services.Sales
{
	public interface IProductSelectOptions
	{
		IEnumerable<SelectListItem> GetSelectListItems();
	}
}