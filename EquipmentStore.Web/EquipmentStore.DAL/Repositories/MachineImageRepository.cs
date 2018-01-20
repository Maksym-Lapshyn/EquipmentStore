using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
	public class MachineImageRepository : IImageRepository<ProductImage>
	{
		private readonly EquipmentStoreContext _context;

		public MachineImageRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public void Add(ProductImage entity)
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

		public void DeleteRange(Expression<Func<ProductImage, bool>> expression)
		{
			var entities = _context.MachineImages.Where(expression);

			_context.MachineImages.RemoveRange(entities);
		}
	}
}
