using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
	public interface IService<T>
	{
		T GetSingleOrDefault(int id);

		IEnumerable<T> GetAll();

		void Add(T dto);

		void Update(T dto);

		void Delete(int id);

        bool CheckIfExists(int id);
	}
}
