using EquipmentStore.BLL.Services;
using EquipmentStore.Core.Entities;
using Ninject.Modules;

namespace EquipmentStore.Common.NinjectModules
{
    public class BllModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IService<Pump>>().To<PumpService>();
			Bind<IService<Product>>().To<ProductService>();
			Bind<IService<Output>>().To<OutputService>();
            Bind<IService<ProductCategory>>().To<ProductCategoryService>();
            Bind<IService<PumpCategory>>().To<PumpCategoryService>();
            Bind<IService<ProductCategory>>().To<ProductCategoryService>();
        }
	}
}
