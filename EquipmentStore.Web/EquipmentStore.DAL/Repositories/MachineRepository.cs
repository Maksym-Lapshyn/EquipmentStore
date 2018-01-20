using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
	public class MachineRepository : IRepository<Product>
	{
		private readonly EquipmentStoreContext _context;

		public MachineRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public void Add(Product entity)
		{
			_context.Machines.Add(entity);
		}

		public void Delete(int id)
		{
			var machine = _context.Machines.SingleOrDefault(p => p.Id == id);

			if (machine == null)
			{
				throw new ArgumentException("Machine with such id does not exist");
			}

			_context.Machines.Remove(machine);
		}

		public IEnumerable<Product> GetAll()
		{
			return _context.Machines.ToList();
		}

		public Product GetSingleOrDefault(int id)
		{
			var product = _context.Machines.SingleOrDefault(m => m.Id == id);

			return product;
		}

		public void Update(Product entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}
	}
}
