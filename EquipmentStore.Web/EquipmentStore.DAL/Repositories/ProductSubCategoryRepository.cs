using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
    public class ProductSubCategoryRepository : Repository<ProductSubCategory>, IExtendingRepository<ProductSubCategory>
    {
        private readonly EquipmentStoreContext _context;

        public ProductSubCategoryRepository(EquipmentStoreContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteRange(Expression<Func<ProductSubCategory, bool>> expression)
        {
            var productSubCategories = _context.ProductSubCategories.Where(expression);

            _context.ProductSubCategories.RemoveRange(productSubCategories);
        }
    }
}
