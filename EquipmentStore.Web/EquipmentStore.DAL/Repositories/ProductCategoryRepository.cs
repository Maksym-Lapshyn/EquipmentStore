using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
    class ProductCategoryRepository : IRepository<ProductCategory>
    {
        private readonly EquipmentStoreContext _context;

        public ProductCategoryRepository(EquipmentStoreContext context)
        {
            _context = context;
        }

        public void Add(ProductCategory entity)
        {
            _context.ProductCategories.Add(entity);
        }

        public void Delete(int id)
        {
            var productCategory = _context.ProductCategories.SingleOrDefault(p => p.Id == id);

            if (productCategory == null)
            {
                throw new ArgumentException("Product category with such id does not exist");
            }

            _context.ProductCategories.Remove(productCategory);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _context.ProductCategories.ToList();
        }

        public ProductCategory GetSingleOrDefault(int id)
        {
            var productCategory = _context.ProductCategories.SingleOrDefault(m => m.Id == id);

            return productCategory;
        }

        public void Update(ProductCategory productCategory)
        {
            _context.Entry(productCategory).State = EntityState.Modified;
        }
    }
}
