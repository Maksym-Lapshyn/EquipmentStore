﻿using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
	public class LabourRepository : IRepository<Labour>
	{
		private readonly EquipmentStoreContext _context;

		public LabourRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public void Add(Labour entity)
		{
			_context.Labours.Add(entity);
		}

		public void Delete(int id)
		{
			var labour = _context.Labours.SingleOrDefault(l => l.Id == id);

			if (labour == null)
			{
				throw new ArgumentException("Labour with such id does not exist");
			}

			_context.Labours.Remove(labour);
		}

		public IEnumerable<Labour> GetAll()
		{
			return _context.Labours;
		}

		public Labour GetSingleOrDefault(int id)
		{
			var labour = _context.Labours.SingleOrDefault(l => l.Id == id);

			return labour;
		}

		public void Update(Labour entity)
		{
			throw new NotImplementedException();
		}
	}
}
