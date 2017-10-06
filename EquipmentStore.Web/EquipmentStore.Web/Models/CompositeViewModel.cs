using System.Collections.Generic;

namespace EquipmentStore.Web.Models
{
	public class CompositeViewModel
	{
		public List<LabourViewModel> Labours { get; set; }

		public List<MachineViewModel> Machines { get; set; }

		public List<OutputViewModel> Outputs { get; set; }
	}
}