using EquipmentStore.Core.Enums;
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

		[Required(ErrorMessage = "Укажите категорию")]
		[DisplayName("Категория")]
		public EquipmentCategory Category { get; set; }
	}
}