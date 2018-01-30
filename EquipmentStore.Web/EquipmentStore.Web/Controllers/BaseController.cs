using EquipmentStore.Core.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            if (filterContext.HttpContext.Response.StatusCode == 500)
            {
                filterContext.Result = RedirectToAction("Error", "InternalErrorHandler");
            }

            else if (filterContext.HttpContext.Response.StatusCode == 404)
            {
                filterContext.Result = RedirectToAction("Error", "NotFoundHandler");
            }

        }
    }
}