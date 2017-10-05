using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Web.Models.Enums
{
	public enum FeedbackTopic
	{
		[Display(Name = "Оборудование")]
		Product,

		[Display(Name = "Услуги")]
		Service
	}
}