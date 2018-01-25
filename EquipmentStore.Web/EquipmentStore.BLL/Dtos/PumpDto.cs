namespace EquipmentStore.BLL.Dtos
{
	public class PumpDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public PumpImageDto MainImage { get; set; }
	}
}
