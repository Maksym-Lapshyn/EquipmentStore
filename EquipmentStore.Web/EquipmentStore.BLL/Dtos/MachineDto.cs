using System.Collections.Generic;

namespace EquipmentStore.BLL.Dtos
{
	public class MachineDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

		public string CuttingFrequency { get; set; }

		public string MaximumPackageSize { get; set; }

		public string MaxMoldingDepth { get; set; }

		public string AirPressure { get; set; }

		public string CoolingType { get; set; }

		public string AirCompressor { get; set; }

		public string Size { get; set; }

		public int Weight { get; set; }

		public MachineImageDto MainImage { get; set; }

		public List<MachineImageDto> Images { get; set; }
	}
}
