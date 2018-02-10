using EquipmentStore.Web.App_Start;
using EquipmentStore.Web.Infrastructure;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EquipmentStore.Web
{
    public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			Database.SetInitializer(new IdentityInitializer());
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
            MappingConfig.RegisterMappings();
		}
	}
}
