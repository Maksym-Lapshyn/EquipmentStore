using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Web.Models.Enums
{
	public enum FeedbackTopic
	{
        [Display(Name = "Перистальтические насосы")]
        Pump,

        [Display(Name = "Оборудование")]
		Product
	}
}