using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Core.Entities
{
	public class LabourImage : Image
	{
		[Required]
		public virtual Labour Labour { get; set; }
	}
}
