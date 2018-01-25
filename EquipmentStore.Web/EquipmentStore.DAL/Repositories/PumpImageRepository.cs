using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
	public class PumpImageRepository : IImageRepository<PumpImage>
	{
		private readonly EquipmentStoreContext _context;

		public PumpImageRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public void Add(PumpImage entity)
		{
			_context.PumpImages.Add(entity);
		}

		public void Delete(int id)
		{
			var image = _context.PumpImages.SingleOrDefault(l => l.Id == id);

			if (image == null)
			{
				throw new ArgumentException("Image with such id does not exist");
			}

			_context.PumpImages.Remove(image);
		}

		public void DeleteRange(Expression<Func<PumpImage, bool>> expression)
		{
			var entities = _context.PumpImages.Where(expression);

			_context.PumpImages.RemoveRange(entities);
		}
	}
}
