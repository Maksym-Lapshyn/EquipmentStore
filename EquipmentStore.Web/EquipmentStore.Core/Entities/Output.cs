namespace EquipmentStore.Core.Entities
{
    public class Output : BaseEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public virtual OutputImage OutputImage { get; set; }
	}
}
