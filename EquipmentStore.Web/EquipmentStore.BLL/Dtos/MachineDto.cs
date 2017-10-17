using EquipmentStore.Core.Enums;

namespace EquipmentStore.BLL.Dtos
{
	public class MachineDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

		public EquipmentCategory Category { get; set; }

		public MachineImageDto MainImage { get; set; }
	}
}
