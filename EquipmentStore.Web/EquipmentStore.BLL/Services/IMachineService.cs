using EquipmentStore.BLL.Dtos;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
    public interface IMachineService : IService<MachineDto>
    {
        IEnumerable<MachineDto> GetAll(string categoryName);
    }
}
