using Microsoft.Build.Framework;

namespace EquipmentStore.Core.Entities
{
	public class MachineImage : Image
	{
		[Required]
		public virtual Machine Machine { get; set; }
	}
}
