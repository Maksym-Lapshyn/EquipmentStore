using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
	public class ProductRepository : IRepository<Product>
	{
		private readonly EquipmentStoreContext _context;

		public ProductRepository(EquipmentStoreContext context)
		{
			_context = context;
		}

		public void Add(Product entity)
		{
			_context.Products.Add(entity);
		}

		public void Delete(int id)
		{
			var machine = _context.Products.SingleOrDefault(p => p.Id == id);

			if (machine == null)
			{
				throw new ArgumentException("Product with such id does not exist");
			}

			_context.Products.Remove(machine);
		}

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
		{
			return _context.Products.ToList();
		}

		public Product GetSingleOrDefault(int id)
		{
			var product = _context.Products.SingleOrDefault(m => m.Id == id);

			return product;
		}

		public void Update(Product entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}
	}
}
