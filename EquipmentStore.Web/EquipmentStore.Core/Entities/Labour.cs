namespace EquipmentStore.Core.Entities
{
	public class Labour
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

		public virtual LabourImage MainImage { get; set; }
	}
}
