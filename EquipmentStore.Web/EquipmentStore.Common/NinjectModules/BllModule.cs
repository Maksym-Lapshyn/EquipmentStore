using EquipmentStore.BLL.Dtos;
using EquipmentStore.BLL.Services;

namespace EquipmentStore.Common.NinjectModules
{
	public class BllModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IService<LabourDto>>().To<LabourService>();
			Bind<IService<MachineDto>>().To<MachineService>();
			Bind<IImageService<MachineImageDto>>().To<MachineImageService>();
			Bind<IImageService<LabourImageDto>>().To<LabourImageService>();
		}
	}
}
