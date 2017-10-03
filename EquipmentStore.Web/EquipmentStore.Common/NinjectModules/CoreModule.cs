using EquipmentStore.Core.Loggers;

namespace EquipmentStore.Common.NinjectModules
{
	public class CoreModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ILogger>().To<NLogLogger>();
		}
	}
}
