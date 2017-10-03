using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.Repositories;

namespace EquipmentStore.DAL.UnitOfWork
{
	public interface IUnitOfWork
	{
		IRepository<Machine> ProductRepository { get; }

		IRepository<Labour> LabourRepository { get; }

		void Save();
	}
}
