using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EquipmentStore.Web.Startup))]
namespace EquipmentStore.Web
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
