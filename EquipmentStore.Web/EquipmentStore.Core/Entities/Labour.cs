using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Core.Entities
{
	public class Labour
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		[Required]
		public virtual LabourImage MainImage { get; set; }
	}
}
