using System.Collections.Generic;

namespace EquipmentStore.Web.Models
{
	public class CompositeViewModel
	{
		public List<PumpViewModel> Labours { get; set; }

		public List<ProductViewModel> Machines { get; set; }

		public List<OutputViewModel> Outputs { get; set; }
	}
}