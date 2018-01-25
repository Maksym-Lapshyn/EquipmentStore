using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
    public class OutputRepository : IRepository<Output>
	{
		private readonly EquipmentStoreContext _context;

		public OutputRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public Output GetSingleOrDefault(int id)
		{
			return _context.Outputs.SingleOrDefault(o => o.Id == id);
		}

		public IEnumerable<Output> GetAll()
		{
			return _context.Outputs.ToList();
		}

		public void Add(Output entity)
		{
			_context.Outputs.Add(entity);
		}

		public void Update(Output entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			var output = _context.Outputs.SingleOrDefault(o => o.Id == id);

			if (output == null)
			{
				throw new ArgumentException("Output with such id does not exist");
			}

			_context.Outputs.Remove(output);
		}
	}
}
