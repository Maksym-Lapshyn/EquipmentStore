using EquipmentStore.DAL.DatabaseContext;
using EquipmentStore.DAL.UnitOfWork;
using Ninject.Modules;

namespace EquipmentStore.Common.NinjectModules
{
    public class DalModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<EquipmentStoreContext>().ToSelf();
		}
	}
}
