using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class ProductImage : Image
    {
        [Key, ForeignKey("Product")]
        public int Id { get; set; }

        [Required]
		public virtual Product Product { get; set; }
	}
}
