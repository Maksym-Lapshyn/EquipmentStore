using System.Collections.Generic;

namespace EquipmentStore.Core.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Machines { get; set; }
    }
}
