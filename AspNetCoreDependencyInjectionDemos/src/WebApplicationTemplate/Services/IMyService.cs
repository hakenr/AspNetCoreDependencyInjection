using System;

namespace WebApplicationTemplate.Services
{
	public interface IMyService
	{
		Guid ServiceId { get; }
	}

	public class MyService : IMyServiceTransient, IMyServiceInstance, IMyServiceScoped, IMyServiceSingleton
	{
		public Guid ServiceId { get; }

		public MyService()
		{
			ServiceId = Guid.NewGuid();
		}
		public MyService(Guid guid)
		{
			ServiceId = guid;
		}
	}

	public interface IMyServiceTransient : IMyService
	{
	}


	public interface IMyServiceScoped : IMyService
	{
	}

	public interface IMyServiceSingleton : IMyService
	{
	}

	public interface IMyServiceInstance : IMyService
	{
	}
}