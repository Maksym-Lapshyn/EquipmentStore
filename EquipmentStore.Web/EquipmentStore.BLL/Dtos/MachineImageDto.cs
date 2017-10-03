namespace EquipmentStore.BLL.Dtos
{
	public class MachineImageDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string MimeType { get; set; }

		public byte[] Data { get; set; }

		public MachineDto Machine { get; set; }
	}
}
