using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using EquipmentStore.DAL.Repositories;
using System;

namespace EquipmentStore.DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MachineStoreContext _context;
		private readonly Lazy<IRepository<Machine>> _productRepository;
		private readonly Lazy<IRepository<Labour>> _labourRepository;

		public UnitOfWork(MachineStoreContext context)
		{
			_context = context;
			_productRepository = new Lazy<IRepository<Machine>>(() => new MachineRepository(_context));
			_labourRepository = new Lazy<IRepository<Labour>>(() => new LabourRepository(_context));
		}

		public IRepository<Machine> ProductRepository => _productRepository.Value;

		public IRepository<Labour> LabourRepository => _labourRepository.Value;

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
