using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
	public class MachineRepository : IRepository<Machine>
	{
		private readonly MachineStoreContext _context;

		public MachineRepository(MachineStoreContext context)
		{
			_context = context;
		}

		public void Add(Machine entity)
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

		public IEnumerable<Machine> GetAll()
		{
			return _context.Machines;
		}

		public Machine GetSingleOrDefault(int id)
		{
			var product = _context.Machines.Include(m => m.Images).SingleOrDefault(m => m.Id == id);

			return product;
		}

		public void Update(Machine entity)
		{
			throw new NotImplementedException();
		}
	}
}
