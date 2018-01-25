using System.Collections.Generic;

namespace EquipmentStore.Core.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<ProductSubCategory> SubCategories { get; set; }
    }
}
