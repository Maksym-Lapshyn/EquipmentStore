using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.Repositories;

namespace EquipmentStore.DAL.UnitOfWork
{
	public interface IUnitOfWork
	{
		IRepository<Product> MachineRepository { get; }

		IRepository<Pump> LabourRepository { get; }

		IRepository<Output> OutputRepository { get; }

		IImageRepository<ProductImage> MachineImageRepository { get; }

		IImageRepository<PumpImage> LabourImageRepository { get; }

		IImageRepository<OutputImage> OutputImageRepository { get; }

		void Save();
	}
}
