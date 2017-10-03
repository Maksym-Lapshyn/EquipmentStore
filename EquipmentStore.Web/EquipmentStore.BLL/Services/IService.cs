using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentStore.BLL.Services
{
	public interface IService<T>
	{
		T GetSingleOrDefault(int id);

		IEnumerable<T> GetAll();

		void Add(T dto);

		void Update(T dto);

		void Delete(int id);
	}
}
