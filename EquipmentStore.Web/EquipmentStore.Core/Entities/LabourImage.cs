using Microsoft.Build.Framework;

namespace EquipmentStore.Core.Entities
{
	public class LabourImage : Image
	{
		[Required]
		public virtual Labour Labour { get; set; }
	}
}
