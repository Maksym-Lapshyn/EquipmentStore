using System.Collections.Generic;

namespace EquipmentStore.Web.Models
{
    public class ProductSubCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название подкатегории")]
        [DisplayName("Название подкатегории")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public ProductCategoryViewModel Category { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}