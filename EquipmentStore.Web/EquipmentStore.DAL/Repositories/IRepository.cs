using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
    public interface IRepository<T>
	{
		T GetSingleOrDefault(int id);

		IEnumerable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> expression);

        void Add(T entity);

		void Update(T entity);

		void Delete(int id);

        bool Exists(int id);
	}
}
