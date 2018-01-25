using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
    public class PumpCategoryRepository : IRepository<PumpCategory>
    {
        private readonly EquipmentStoreContext _context;

        public PumpCategoryRepository(EquipmentStoreContext context)
        {
            _context = context;
        }

        public void Add(PumpCategory entity)
        {
            _context.PumpCategories.Add(entity);
        }

        public void Delete(int id)
        {
            var pumpCategory = _context.PumpCategories.SingleOrDefault(p => p.Id == id);

            if (pumpCategory == null)
            {
                throw new ArgumentException("Pump category with such id does not exist");
            }

            _context.PumpCategories.Remove(pumpCategory);
        }

        public IEnumerable<PumpCategory> GetAll()
        {
            return _context.PumpCategories.ToList();
        }

        public PumpCategory GetSingleOrDefault(int id)
        {
            var pumpCategory = _context.PumpCategories.SingleOrDefault(m => m.Id == id);

            return pumpCategory;
        }

        public void Update(PumpCategory pumpCategory)
        {
            _context.Entry(pumpCategory).State = EntityState.Modified;
        }
    }
}
