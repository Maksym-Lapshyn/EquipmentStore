using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EquipmentStore.Web.Models
{
	public class PumpViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите название")]
		[DisplayName("Название")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Укажите описание")]
		[DisplayName("Описание")]
		public string Description { get; set; }

        public int MainImageId { get; set; }

		[DisplayName("Главное изображение")]
		public ImageViewModel MainImage { get; set; }

		[DisplayName("Главное изображение")]
		public HttpPostedFileBase ImageInput { get; set; }
	}
}