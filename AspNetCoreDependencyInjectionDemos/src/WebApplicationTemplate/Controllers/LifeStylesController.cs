using Microsoft.AspNetCore.Mvc;
using WebApplicationTemplate.Services;

namespace WebApplicationTemplate.Controllers
{
	public class LifeStylesController : Controller
	{
		public ActionResult Index(
			[FromServices] IMyServiceTransient myServiceTransient,
			[FromServices] IMyServiceScoped myServiceScoped,
			[FromServices] IMyServiceSingleton myServiceSingleton,
			[FromServices] IMyServiceInstance myServiceInstance,
			[FromServices] MyDerivedService myDerivedService)
		{
			ViewBag.MyServiceTransientId = myServiceTransient.ServiceId;
			ViewBag.MyServiceScopedId = myServiceScoped.ServiceId;
			ViewBag.MyServiceSingletonId = myServiceSingleton.ServiceId;
			ViewBag.MyServiceInstanceId = myServiceInstance.ServiceId;

			ViewBag.MyDerivedServiceTransientId = myDerivedService.MyServiceTransient.ServiceId;
			ViewBag.MyDerivedServiceScopedId = myDerivedService.MyServiceScoped.ServiceId;
			ViewBag.MyDerivedServiceSingletonId = myDerivedService.MyServiceSingleton.ServiceId;
			ViewBag.MyDerivedServiceInstanceId = myDerivedService.MyServiceInstance.ServiceId;

			return View();
		}
	}
}