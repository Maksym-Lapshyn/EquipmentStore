using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
	public class LabourImageRepository : IImageRepository<PumpImage>
	{
		private readonly EquipmentStoreContext _context;

		public LabourImageRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public void Add(PumpImage entity)
		{
			_context.LabourImages.Add(entity);
		}

		public void Delete(int id)
		{
			var image = _context.LabourImages.SingleOrDefault(l => l.Id == id);

			if (image == null)
			{
				throw new ArgumentException("Image with such id does not exist");
			}

			_context.LabourImages.Remove(image);
		}

		public void DeleteRange(Expression<Func<PumpImage, bool>> expression)
		{
			var entities = _context.LabourImages.Where(expression);

			_context.LabourImages.RemoveRange(entities);
		}
	}
}
