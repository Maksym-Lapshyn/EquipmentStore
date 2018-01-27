using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class OutputImage : Image
	{
        [Key, ForeignKey("Output")]
        public int Id { get; set; }

        [Required]
		public virtual Output Output { get; set; }
	}
}
