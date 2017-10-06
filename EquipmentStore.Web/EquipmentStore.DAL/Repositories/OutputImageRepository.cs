using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
	public class OutputImageRepository : IImageRepository<OutputImage>
	{
		private readonly EquipmentStoreContext _context;

		public OutputImageRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public void Add(OutputImage entity)
		{
			_context.OutputImages.Add(entity);
		}

		public void Delete(int id)
		{
			var image = _context.OutputImages.SingleOrDefault(l => l.Id == id);

			if (image == null)
			{
				throw new ArgumentException("Image with such id does not exist");
			}

			_context.OutputImages.Remove(image);
		}

		public void DeleteRange(Expression<Func<OutputImage, bool>> expression)
		{
			var images = _context.OutputImages.Where(expression).ToList();

			_context.OutputImages.RemoveRange(images);
		}
	}
}
