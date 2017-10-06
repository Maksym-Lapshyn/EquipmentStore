using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Core.Entities
{
	public class Output
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		[Required]
		public virtual OutputImage MainImage { get; set; }
	}
}
