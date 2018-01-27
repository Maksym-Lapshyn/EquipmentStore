using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
	public class ProductImageRepository : IImageRepository<ProductImage>
	{
		private readonly EquipmentStoreContext _context;

		public ProductImageRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public void Add(ProductImage entity)
		{
			_context.ProductImages.Add(entity);
		}

		public void Delete(int id)
		{
			var image = _context.ProductImages.SingleOrDefault(pi => pi.Id == id);

			if (image == null)
			{
				throw new ArgumentException("Image with such id does not exist");
			}

			_context.ProductImages.Remove(image);
		}

		public void DeleteRange(Expression<Func<ProductImage, bool>> expression)
		{
			var entities = _context.ProductImages.Where(expression);

			_context.ProductImages.RemoveRange(entities);
		}

        public ProductImage GetSingleOrDefault(int id)
        {
            var entity = _context.ProductImages.SingleOrDefault(pi => pi.Id == id);

            return entity;
        }

        public void Update(ProductImage entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
