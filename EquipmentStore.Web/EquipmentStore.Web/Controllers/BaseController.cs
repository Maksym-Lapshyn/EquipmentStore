using EquipmentStore.Core.Exceptions;
using EquipmentStore.Core.Loggers;
using System.Web.Mvc;

namespace EquipmentStore.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger _logger;

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            _logger.LogError(filterContext.Exception, filterContext.Exception.Message);

            if (filterContext.Exception.GetType() == typeof(NotFoundException))
            {
                filterContext.Result = RedirectToAction("NotFoundHandler", "Error");
            }
            else
            {
                filterContext.Result = RedirectToAction("GeneralHandler", "Error");
            }
        }
    }
}