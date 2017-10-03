using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using EquipmentStore.DAL.Repositories;
using EquipmentStore.DAL.UnitOfWork;

namespace EquipmentStore.Common.NinjectModules
{
	public class DalModule : NinjectModule
	{
		private readonly string _connectionString;

		public DalModule(string connectionString)
		{
			_connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IRepository<Labour>>().To<LabourRepository>();
			Bind<IRepository<Machine>>().To<MachineRepository>();
			Bind<IImageRepository<MachineImage>>().To<MachineImageRepository>();
			Bind<IImageRepository<LabourImage>>().To<LabourImageRepository>();
			Bind<IUnitOfWork>().To<UnitOfWork>();
			Bind<MachineStoreContext>().ToSelf().WithConstructorArgument(_connectionString);
		}
	}
}
