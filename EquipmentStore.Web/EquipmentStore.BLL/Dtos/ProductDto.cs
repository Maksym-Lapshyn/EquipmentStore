namespace EquipmentStore.BLL.Dtos
{
	public class ProductDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

		public string CuttingFrequency { get; set; }

		public ProductImageDto MainImage { get; set; }
	}
}
