using EquipmentStore.BLL.Dtos;
using EquipmentStore.BLL.Services;
using Ninject.Modules;

namespace EquipmentStore.Common.NinjectModules
{
	public class BllModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IService<LabourDto>>().To<LabourService>();
			Bind<IMachineService>().To<MachineService>();
			Bind<IService<OutputDto>>().To<OutputService>();
		}
	}
}
