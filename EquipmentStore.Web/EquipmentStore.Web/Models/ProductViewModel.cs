using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EquipmentStore.Web.Models
{
    public class ProductViewModel
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

        public int SubCategoryId { get; set; }

        public int MainImageId { get; set; }

        [DisplayName("Главное изображение")]
        public ImageViewModel MainImage { get; set; }

        [DisplayName("Главное изображение")]
        public HttpPostedFileBase ImageInput { get; set; }

        public ProductCategoryViewModel SubCategory { get; set; }
	}
}