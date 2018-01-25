using System.Collections.Generic;

namespace EquipmentStore.DAL.Repositories
{
    public interface IRepository<T>
	{
		T GetSingleOrDefault(int id);

		IEnumerable<T> GetAll();

		void Add(T entity);

		void Update(T entity);

		void Delete(int id);

        bool Exists(int id);
	}
}
