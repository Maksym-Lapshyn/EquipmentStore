using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class ProductSubCategory : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public virtual ProductCategory Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
