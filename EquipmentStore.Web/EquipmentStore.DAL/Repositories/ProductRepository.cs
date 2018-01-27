using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IExtendingRepository<Product>
    {
        private readonly EquipmentStoreContext _context;

        public ProductRepository(EquipmentStoreContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteRange(Expression<Func<Product, bool>> expression)
        {
            var products = _context.Products.Where(expression);

            _context.Products.RemoveRange(products);
        }
    }
}
