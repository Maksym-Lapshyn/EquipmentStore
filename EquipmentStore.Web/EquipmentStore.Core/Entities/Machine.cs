using System.Collections.Generic;

namespace EquipmentStore.Core.Entities
{
	public class Machine
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

		public virtual MachineImage MainImage { get; set; }

		public ICollection<MachineImage> Images { get; set; }
	}
}
