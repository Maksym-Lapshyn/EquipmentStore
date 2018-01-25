using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
    public class PumpRepository : IRepository<Pump>
	{
		private readonly EquipmentStoreContext _context;

		public PumpRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public void Add(Pump entity)
		{
			_context.Pumps.Add(entity);
		}

		public void Delete(int id)
		{
			var labour = _context.Pumps.SingleOrDefault(l => l.Id == id);

			if (labour == null)
			{
				throw new ArgumentException("Pump with such id does not exist");
			}

			_context.Pumps.Remove(labour);
		}

		public IEnumerable<Pump> GetAll()
		{
			return _context.Pumps.ToList();
		}

		public Pump GetSingleOrDefault(int id)
		{
			var labour = _context.Pumps.SingleOrDefault(l => l.Id == id);

			return labour;
		}

		public void Update(Pump entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}
	}
}
