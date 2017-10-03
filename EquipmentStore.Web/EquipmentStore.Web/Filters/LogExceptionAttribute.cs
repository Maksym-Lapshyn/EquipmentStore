using Microsoft.Owin.Logging;
using System.Web.Mvc;

namespace EquipmentStore.Web.Filters
{
	public class LogExceptionAttribute : HandleErrorAttribute
	{
		private readonly ILogger _logger;

		public LogExceptionAttribute()
		{
			_logger = (ILogger)DependencyResolver.Current.GetService(typeof(ILogger));
		}

		public override void OnException(ExceptionContext filterContext)
		{
			_logger.LogFatal(filterContext.Exception, string.Empty);
		}
	}
}