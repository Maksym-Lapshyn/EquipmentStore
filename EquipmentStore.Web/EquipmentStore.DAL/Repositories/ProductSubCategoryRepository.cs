using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
    public class ProductSubCategoryRepository : IRepository<ProductSubCategory>
    {
        private readonly EquipmentStoreContext _context;

        public ProductSubCategoryRepository(EquipmentStoreContext context)
        {
            _context = context;
        }

        public void Add(ProductSubCategory entity)
        {
            _context.ProductSubCategories.Add(entity);
        }

        public void Delete(int id)
        {
            var productSubCategory = _context.ProductSubCategories.SingleOrDefault(p => p.Id == id);

            if (productSubCategory == null)
            {
                throw new ArgumentException("Product subcategory with such id does not exist");
            }

            _context.ProductSubCategories.Remove(productSubCategory);
        }

        public IEnumerable<ProductSubCategory> GetAll()
        {
            return _context.ProductSubCategories.ToList();
        }

        public ProductSubCategory GetSingleOrDefault(int id)
        {
            var productSubCategory = _context.ProductSubCategories.SingleOrDefault(m => m.Id == id);

            return productSubCategory;
        }

        public void Update(ProductSubCategory productSubCategory)
        {
            _context.Entry(productSubCategory).State = EntityState.Modified;
        }
    }
}
