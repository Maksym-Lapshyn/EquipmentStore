using EquipmentStore.Web.Filters;
using System.Web.Mvc;

namespace EquipmentStore.Web
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new LogEventAttribute());
			filters.Add(new LogExceptionAttribute());
		}
	}
}
