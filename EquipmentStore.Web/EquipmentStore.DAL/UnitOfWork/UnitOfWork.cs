using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using EquipmentStore.DAL.Repositories;
using System;

namespace EquipmentStore.DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EquipmentStoreContext _context;
		private readonly Lazy<IRepository<Machine>> _machineRepository;
		private readonly Lazy<IRepository<Labour>> _labourRepository;
		private readonly Lazy<IImageRepository<MachineImage>> _machineImageRepository;
		private readonly Lazy<IImageRepository<LabourImage>> _labourImageRepository;

		public UnitOfWork(EquipmentStoreContext context)
		{
			_context = context;
			_machineRepository = new Lazy<IRepository<Machine>>(() => new MachineRepository(_context));
			_labourRepository = new Lazy<IRepository<Labour>>(() => new LabourRepository(_context));
			_machineImageRepository = new Lazy<IImageRepository<MachineImage>>(() => new MachineImageRepository(_context));
			_labourImageRepository = new Lazy<IImageRepository<LabourImage>>(() => new LabourImageRepository(_context));
		}

		public IRepository<Machine> MachineRepository => _machineRepository.Value;

		public IRepository<Labour> LabourRepository => _labourRepository.Value;

		public IImageRepository<MachineImage> MachineImageRepository => _machineImageRepository.Value;

		public IImageRepository<LabourImage> LabourImageRepository => _labourImageRepository.Value;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
