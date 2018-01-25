using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class PumpImage : Image
	{
        [ForeignKey("Pump")]
        public int PumpId { get; set; }

        [Required]
		public virtual Pump Pump { get; set; }
	}
}
