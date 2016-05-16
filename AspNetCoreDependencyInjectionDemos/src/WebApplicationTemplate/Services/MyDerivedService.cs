namespace WebApplicationTemplate.Services
{
	public class MyDerivedService
	{
		public IMyServiceTransient MyServiceTransient { get; set; }

		public IMyServiceScoped MyServiceScoped { get; set; }

		public IMyServiceSingleton MyServiceSingleton { get; set; }

		public IMyServiceInstance MyServiceInstance { get; set; }

		public MyDerivedService(
			IMyServiceTransient myServiceTransient,
			IMyServiceScoped myServiceScoped,
			IMyServiceSingleton myServiceSingleton,
			IMyServiceInstance myServiceInstance)
		{
			MyServiceTransient = myServiceTransient;
			MyServiceScoped = myServiceScoped;
			MyServiceSingleton = myServiceSingleton;
			MyServiceInstance = myServiceInstance;
		}
	}
}