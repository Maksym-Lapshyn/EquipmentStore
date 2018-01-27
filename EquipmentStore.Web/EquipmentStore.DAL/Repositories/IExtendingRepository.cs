using System;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
    public interface IExtendingRepository<T> : IRepository<T>
    {
        void DeleteRange(Expression<Func<T, bool>> expression);
    }
}
