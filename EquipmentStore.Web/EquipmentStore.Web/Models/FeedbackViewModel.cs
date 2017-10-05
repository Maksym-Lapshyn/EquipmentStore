using EquipmentStore.Web.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Web.Models
{
	public class FeedbackViewModel
	{
		[DisplayName("Тема сообщения")]
		public FeedbackTopic FeedbackTopic { get; set; }

		[Required(ErrorMessage = "Укажите Ваше имя")]
		[DisplayName("Ваше имя")]
		public string Name { get; set; }

		[RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Неверный формат электронной почты")]
		[Required(ErrorMessage = "Укажите Вашу электронную почту")]
		[DisplayName("Ваша электронная почта")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Укажите текст сообщения")]
		[DisplayName("Сообщение")]
		public string Message { get; set; }
	}
}