using EquipmentStore.Core.Loggers;
using System.Web.Mvc;

namespace EquipmentStore.Web.Filters
{
	public class LogEventAttribute : ActionFilterAttribute
	{
		private readonly ILogger _logger;

		public LogEventAttribute()
		{
			_logger = (ILogger)DependencyResolver.Current.GetService(typeof(ILogger));
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			_logger.LogInfo(string.Empty);
		}
	}
}