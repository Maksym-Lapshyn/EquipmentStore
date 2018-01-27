using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class Product : BaseEntity
	{
		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

        [ForeignKey("ProductSubCategory")]
        public int ProductSubCategoryId { get; set; }

        public virtual ProductImage ProductImage { get; set; }

        [Required]
        public virtual ProductSubCategory ProductSubCategory { get; set; }
	}
}
