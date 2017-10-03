using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		[Route("")]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[Route("contacts")]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}