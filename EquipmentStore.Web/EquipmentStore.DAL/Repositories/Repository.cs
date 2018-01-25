using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EquipmentStore.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbSet<T> _dbSet;
        private readonly EquipmentStoreContext _context;

        public Repository(EquipmentStoreContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.SingleOrDefault(p => p.Id == id);

            if (entity == null)
            {
                throw new ArgumentException("Entity with such id does not exist");
            }

            _dbSet.Remove(entity);
        }

        public bool Exists(int id)
        {
            return _dbSet.Any(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetSingleOrDefault(int id)
        {
            var entity = _dbSet.SingleOrDefault(m => m.Id == id);

            return entity;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
