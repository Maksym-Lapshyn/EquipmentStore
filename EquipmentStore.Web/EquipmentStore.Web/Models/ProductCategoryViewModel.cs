using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EquipmentStore.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название категории")]
        [DisplayName("Название категории")]
        public string Name { get; set; }

        public List<ProductSubCategoryViewModel> ProductSubCategories { get; set; }
    }
}