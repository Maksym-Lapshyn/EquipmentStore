using EquipmentStore.DAL.DatabaseContext;
using EquipmentStore.DAL.UnitOfWork;
using Ninject.Modules;
using Ninject.Web.Common;

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
			Bind<IUnitOfWork>().To<UnitOfWork>();
			Bind<EquipmentStoreContext>().ToSelf().InRequestScope().WithConstructorArgument(_connectionString);
		}
	}
}
