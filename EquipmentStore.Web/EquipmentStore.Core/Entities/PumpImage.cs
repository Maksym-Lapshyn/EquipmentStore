using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class PumpImage : Image
	{
        [Key, ForeignKey("Pump")]
        public int Id { get; set; }

        [Required]
		public virtual Pump Pump { get; set; }
	}
}
