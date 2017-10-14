using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using EquipmentStore.DAL.Repositories;
using System;

namespace EquipmentStore.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly EquipmentStoreContext _context;
		private readonly Lazy<IMachineRepository> _machineRepository;
		private readonly Lazy<IRepository<Labour>> _labourRepository;
		private readonly Lazy<IRepository<Output>> _outputRepository;
		private readonly Lazy<IImageRepository<MachineImage>> _machineImageRepository;
		private readonly Lazy<IImageRepository<LabourImage>> _labourImageRepository;
		private readonly Lazy<IImageRepository<OutputImage>> _outputImageRepository;

		public UnitOfWork(EquipmentStoreContext context)
		{
			_context = context;
			_machineRepository = new Lazy<IMachineRepository>(() => new MachineRepository(_context));
			_labourRepository = new Lazy<IRepository<Labour>>(() => new LabourRepository(_context));
			_outputRepository = new Lazy<IRepository<Output>>(() => new OutputRepository(_context));
			_machineImageRepository = new Lazy<IImageRepository<MachineImage>>(() => new MachineImageRepository(_context));
			_labourImageRepository = new Lazy<IImageRepository<LabourImage>>(() => new LabourImageRepository(_context));
			_outputImageRepository = new Lazy<IImageRepository<OutputImage>>(() => new OutputImageRepository(_context));
		}

		public IMachineRepository MachineRepository => _machineRepository.Value;

		public IRepository<Labour> LabourRepository => _labourRepository.Value;

		public IRepository<Output> OutputRepository => _outputRepository.Value;

		public IImageRepository<MachineImage> MachineImageRepository => _machineImageRepository.Value;

		public IImageRepository<LabourImage> LabourImageRepository => _labourImageRepository.Value;

		public IImageRepository<OutputImage> OutputImageRepository => _outputImageRepository.Value;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
