using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Web.Models
{
    public class ProductSubCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название подкатегории")]
        [DisplayName("Название подкатегории")]
        public string Name { get; set; }

        public int ProductCategoryId { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}