using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Core.Entities
{
	public class PumpImage : Image
	{
        [Required]
		public virtual Pump Pump { get; set; }
	}
}
