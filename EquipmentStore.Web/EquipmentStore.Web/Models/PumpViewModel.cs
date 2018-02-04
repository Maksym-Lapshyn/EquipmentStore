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

        [Required(ErrorMessage = "Укажите четвертые используемые головки")]
        [DisplayName("Четвертые спользуемые головки")]
        public string Heads4 { get; set; }

        [Required(ErrorMessage = "Укажите используемые трубки для головок 4")]
        [DisplayName("Используемые трубки для головок 4")]
        public string Tubes4 { get; set; }

        [Required(ErrorMessage = "Укажите диапазон расходов для головок 4")]
        [DisplayName("Диапазон расходов для головок 4, мл/мин")]
        public string Costs4 { get; set; }

        [Required(ErrorMessage = "Укажите вес для головок 4")]
        [DisplayName("Вес для головок 4, кг")]
        public double Weight4 { get; set; }

        [Required(ErrorMessage = "Укажите вторые используемые головки")]
        [DisplayName("Вторые используемые головки")]
        public string Heads2 { get; set; }

        [Required(ErrorMessage = "Укажите используемые трубки для головок 2")]
        [DisplayName("Используемые трубки для головок 2")]
        public string Tubes2 { get; set; }

        [Required(ErrorMessage = "Укажите диапазон расходов для головок 2")]
        [DisplayName("Диапазон расходов для головок 2, мл/мин")]
        public string Costs2 { get; set; }

        [Required(ErrorMessage = "Укажите вес для головок 2")]
        [DisplayName("Вес для головок 2, кг")]
        public double Weight2 { get; set; }

        [Required(ErrorMessage = "Укажите третие используемые головки")]
        [DisplayName("Третие используемые головки")]
        public string Heads3 { get; set; }

        [Required(ErrorMessage = "Укажите используемые трубки для головки 3")]
        [DisplayName("Используемые трубки для головки 3")]
        public string Tubes3 { get; set; }

        [Required(ErrorMessage = "Укажите диапазон расходов для головки 3")]
        [DisplayName("Диапазон расходов для головки 3, мл/мин")]
        public string Costs3 { get; set; }

        [Required(ErrorMessage = "Укажите вес для головки 3")]
        [DisplayName("Вес для головки 3, кг")]
        public double Weight3 { get; set; }

        public int PumpCategoryId { get; set; }

		[DisplayName("Главное изображение")]
		public ImageViewModel PumpImage { get; set; }

		[DisplayName("Главное изображение")]
		public HttpPostedFileBase ImageInput { get; set; }

        public PumpCategoryViewModel PumpCategory { get; set; }
    }
}