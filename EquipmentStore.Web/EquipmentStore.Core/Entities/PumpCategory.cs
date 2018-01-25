using System.Collections.Generic;

namespace EquipmentStore.Core.Entities
{
    public class PumpCategory : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Pump> Pumps { get; set; }
    }
}
