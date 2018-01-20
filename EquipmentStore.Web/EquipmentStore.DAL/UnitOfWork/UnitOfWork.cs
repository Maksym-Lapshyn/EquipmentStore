using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using EquipmentStore.DAL.Repositories;
using System;

namespace EquipmentStore.DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EquipmentStoreContext _context;
		private readonly Lazy<IRepository<Product>> _machineRepository;
		private readonly Lazy<IRepository<Pump>> _labourRepository;
		private readonly Lazy<IRepository<Output>> _outputRepository;
		private readonly Lazy<IImageRepository<ProductImage>> _machineImageRepository;
		private readonly Lazy<IImageRepository<PumpImage>> _labourImageRepository;
		private readonly Lazy<IImageRepository<OutputImage>> _outputImageRepository;

		public UnitOfWork(EquipmentStoreContext context)
		{
			_context = context;
			_machineRepository = new Lazy<IRepository<Product>>(() => new MachineRepository(_context));
			_labourRepository = new Lazy<IRepository<Pump>>(() => new LabourRepository(_context));
			_outputRepository = new Lazy<IRepository<Output>>(() => new OutputRepository(_context));
			_machineImageRepository = new Lazy<IImageRepository<ProductImage>>(() => new MachineImageRepository(_context));
			_labourImageRepository = new Lazy<IImageRepository<PumpImage>>(() => new LabourImageRepository(_context));
			_outputImageRepository = new Lazy<IImageRepository<OutputImage>>(() => new OutputImageRepository(_context));
		}

		public IRepository<Product> MachineRepository => _machineRepository.Value;

		public IRepository<Pump> LabourRepository => _labourRepository.Value;

		public IRepository<Output> OutputRepository => _outputRepository.Value;

		public IImageRepository<ProductImage> MachineImageRepository => _machineImageRepository.Value;

		public IImageRepository<PumpImage> LabourImageRepository => _labourImageRepository.Value;

		public IImageRepository<OutputImage> OutputImageRepository => _outputImageRepository.Value;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
