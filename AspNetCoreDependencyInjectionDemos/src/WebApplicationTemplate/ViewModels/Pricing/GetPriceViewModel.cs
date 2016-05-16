namespace WebApplicationTemplate.ViewModels.Pricing
{
	public class GetPriceViewModel
	{
		public int CustomerId { get; set; }

		public int ProductId { get; set; }

		public decimal? Price { get; set; }
	}
}