using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class Pump : BaseEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }

        [ForeignKey("MainImage")]
        public int MainImageId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

		public virtual PumpImage MainImage { get; set; }

        [Required]
        public virtual PumpCategory Category { get; set; }
	}
}
