using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Core.Entities
{
	public class MachineImage : Image
	{
		[Required]
		public virtual Machine Machine { get; set; }
	}
}
