using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class Product
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

        [ForeignKey("MainImage")]
        public int MainImageId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

		public virtual ProductImage MainImage { get; set; }

        [Required]
        public virtual ProductCategory Category { get; set; }
	}
}
