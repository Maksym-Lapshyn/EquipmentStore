﻿using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
	public class MachineImageRepository : IImageRepository<MachineImage>
	{
		private readonly MachineStoreContext _context;

		public MachineImageRepository(MachineStoreContext context)
		{
			_context = context;
		}

		public void Add(MachineImage entity)
		{
			_context.MachineImages.Add(entity);
		}

		public void Delete(int id)
		{
			var image = _context.MachineImages.SingleOrDefault(l => l.Id == id);

			if (image == null)
			{
				throw new ArgumentException("Image with such id does not exist");
			}

			_context.MachineImages.Remove(image);
		}

		public void DeleteRange(Expression<Func<MachineImage, bool>> expression)
		{
			var entities = _context.MachineImages.Where(expression);

			_context.MachineImages.RemoveRange(entities);
		}
	}
}
