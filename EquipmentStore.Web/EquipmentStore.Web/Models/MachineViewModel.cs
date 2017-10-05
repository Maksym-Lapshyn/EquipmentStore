using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EquipmentStore.Web.Models
{
	public class MachineViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите название")]
		[DisplayName("Название")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Укажите краткое описание")]
		[DisplayName("Краткое описание")]
		public string ShortDescription { get; set; }

		[Required(ErrorMessage = "Укажите полное описание")]
		[DisplayName("Подробное описание")]
		public string LongDescription { get; set; }

		[DisplayName("Главное изображение")]
		public ImageViewModel ImageData { get; set; }

		[DisplayName("Главное изображение")]
		public HttpPostedFileBase ImageInput { get; set; }

		[Required(ErrorMessage = "Укажите частоту вырубки")]
		[DisplayName("Частота вырубки (раз/мин)")]
		public string CuttingFrequency { get; set; }

		[Required(ErrorMessage = "Укажите максимальный размер упаковки")]
		[DisplayName("Максимальный размер упаковки (мм)")]
		public string MaximumPackageSize { get; set; }

		[Required(ErrorMessage = "Укажите упаковочный материал")]
		[DisplayName("Упаковочный материал")]
		public string PackageMaterial { get; set; }

		[Required(ErrorMessage = "Укажите максимальнаю глубину формования")]
		[DisplayName("Максимальная глубина формования (мм)")]
		public string MaxMoldingDepth { get; set; }

		[Required(ErrorMessage = "Укажите напряжение")]
		[DisplayName("Напряжение")]
		public string Voltage { get; set; }

		[Required(ErrorMessage = "Укажите размер")]
		[DisplayName("Размер (мм)")]
		public string Size { get; set; }

		[Required(ErrorMessage = "Укажите вес")]
		[DisplayName("Вес")]
		public int Weight { get; set; }
	}
}