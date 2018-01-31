using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("error/notfound")]
        public ViewResult NotFoundHandler()
        {
            Response.StatusCode = 404;

            return View();
        }

        [HttpGet]
        [Route("error/general")]
        public ViewResult GeneralHandler()
        {
            Response.StatusCode = 500;

            return View();
        }
    }
}