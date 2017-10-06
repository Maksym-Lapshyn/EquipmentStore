namespace EquipmentStore.BLL.Dtos
{
	public class OutputDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public OutputImageDto MainImage { get; set; }
	}
}
