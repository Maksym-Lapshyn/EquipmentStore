using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.Repositories;

namespace EquipmentStore.DAL.UnitOfWork
{
	public interface IUnitOfWork
	{
		IRepository<Machine> MachineRepository { get; }

		IRepository<Labour> LabourRepository { get; }

		IRepository<Output> OutputRepository { get; }

		IImageRepository<MachineImage> MachineImageRepository { get; }

		IImageRepository<LabourImage> LabourImageRepository { get; }

		IImageRepository<OutputImage> OutputImageRepository { get; }

		void Save();
	}
}
