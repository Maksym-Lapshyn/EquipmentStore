using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("error/notfound")]
        public ViewResult NotFoundHandler(string aspxerrorpath = null)
        {
            Response.StatusCode = 404;

            return View();
        }

        [HttpGet]
        [Route("error/general")]
        public ViewResult GeneralHandler(string aspxerrorpath = null)
        {
            Response.StatusCode = 500;

            return View();
        }
    }
}