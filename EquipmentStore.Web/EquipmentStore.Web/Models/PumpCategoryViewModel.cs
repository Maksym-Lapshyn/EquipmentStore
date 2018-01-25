using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Web.Models
{
    public class PumpCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название категории")]
        [DisplayName("Название категории")]
        public string Name { get; set; }

        public List<PumpViewModel> Pumps { get; set; }
    }
}