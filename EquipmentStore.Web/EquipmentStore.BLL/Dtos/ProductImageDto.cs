namespace EquipmentStore.BLL.Dtos
{
	public class ProductImageDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string MimeType { get; set; }

		public byte[] Data { get; set; }

		public ProductDto Machine { get; set; }
	}
}
