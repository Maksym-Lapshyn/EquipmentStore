using EquipmentStore.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Core.Entities
{
	public class Machine
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

		public EquipmentCategory Category { get; set; }

		[Required]
		public virtual MachineImage MainImage { get; set; }
	}
}
