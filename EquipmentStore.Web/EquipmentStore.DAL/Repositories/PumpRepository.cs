using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
    public class PumpRepository : Repository<Pump>, IExtendingRepository<Pump>
    {
        private readonly EquipmentStoreContext _context;

        public PumpRepository(EquipmentStoreContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteRange(Expression<Func<Pump, bool>> expression)
        {
            var pumps = _context.Pumps.Where(expression);

            _context.Pumps.RemoveRange(pumps);
        }
    }
}
