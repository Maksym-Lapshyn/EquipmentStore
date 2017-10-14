using EquipmentStore.Core.Entities;
using System.Collections.Generic;

namespace EquipmentStore.DAL.Repositories
{
    public interface IMachineRepository : IRepository<Machine>
    {
        IEnumerable<Machine> GetAll(string categoryName);
    }
}
