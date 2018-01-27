using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class ProductSubCategory : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }

        [Required]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
