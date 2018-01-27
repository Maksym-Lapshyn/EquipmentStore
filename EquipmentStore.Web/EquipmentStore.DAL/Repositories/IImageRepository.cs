using System;
using System.Linq.Expressions;

namespace EquipmentStore.DAL.Repositories
{
	public interface IImageRepository<T>
	{
		void Add(T entity);

		void Delete(int id);

        T GetSingleOrDefault(int id);

        void Update(T entity);

		void DeleteRange(Expression<Func<T, bool>> expression);
	}
}
