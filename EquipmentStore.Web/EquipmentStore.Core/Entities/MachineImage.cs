namespace EquipmentStore.Core.Entities
{
	public class MachineImage : Image
	{
		public virtual Machine Machine { get; set; }
	}
}
