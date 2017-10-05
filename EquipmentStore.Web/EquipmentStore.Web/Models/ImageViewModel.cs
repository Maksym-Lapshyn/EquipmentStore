namespace EquipmentStore.Web.Models
{
	public class ImageViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string MimeType { get; set; }

		public byte[] Data { get; set; }
	}
}