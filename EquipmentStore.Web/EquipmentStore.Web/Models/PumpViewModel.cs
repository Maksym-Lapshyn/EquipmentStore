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

        [Required(ErrorMessage = "Укажите краткое описание")]
        [DisplayName("Краткое описание")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Укажите технические данные")]
        [DisplayName("Технические данные")]
        public string Characteristics { get; set; }

        [Required(ErrorMessage = "Укажите используемые головки")]
        [DisplayName("Используемые головки")]
        public string Heads { get; set; }

        [Required(ErrorMessage = "Укажите используемые трубки")]
        [DisplayName("Используемые трубки")]
        public string Tubes { get; set; }

        [Required(ErrorMessage = "Укажите диапазон расходов")]
        [DisplayName("Диапазон расходов, мл/мин")]
        public string Costs { get; set; }

        [Required(ErrorMessage = "Укажите вес")]
        [DisplayName("Вес, кг")]
        public double Weight { get; set; }

        public int PumpCategoryId { get; set; }

		[DisplayName("Главное изображение")]
		public ImageViewModel PumpImage { get; set; }

		[DisplayName("Главное изображение")]
		public HttpPostedFileBase ImageInput { get; set; }

        public PumpCategoryViewModel PumpCategory { get; set; }
    }
}