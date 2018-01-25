using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class Product : BaseEntity
	{
		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

        [ForeignKey("MainImage")]
        public int MainImageId { get; set; }

        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }

		public virtual ProductImage MainImage { get; set; }

        [Required]
        public virtual ProductSubCategory SubCategory { get; set; }
	}
}
