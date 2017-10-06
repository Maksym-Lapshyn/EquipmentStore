using EquipmentStore.Core.Entities;

namespace EquipmentStore.BLL.Dtos
{
	public class OutputImageDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string MimeType { get; set; }

		public byte[] Data { get; set; }

		public Output Output { get; set; }
	}
}
