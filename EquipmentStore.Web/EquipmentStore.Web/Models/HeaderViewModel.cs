using System.Collections.Generic;

namespace EquipmentStore.Web.Models
{
    public class HeaderViewModel
    {
        public List<ProductCategoryViewModel> ProductCategories { get; set; }

        public List<PumpCategoryViewModel> PumpCategories { get; set; }
    }
}