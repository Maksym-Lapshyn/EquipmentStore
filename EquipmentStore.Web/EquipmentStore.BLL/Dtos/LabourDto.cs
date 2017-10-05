namespace EquipmentStore.BLL.Dtos
{
	public class LabourDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

		public LabourImageDto MainImage { get; set; }
	}
}
