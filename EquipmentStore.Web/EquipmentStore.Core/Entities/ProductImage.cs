using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class ProductImage : Image
    {
        [ForeignKey("Product")]
        public int ProductId {get;set;}

        [Required]
		public virtual Product Product { get; set; }
	}
}
