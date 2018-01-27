using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class Pump : BaseEntity
	{
		public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Characteristics { get; set; }

        public string Heads { get; set; }

        public string Tubes { get; set; }

        public string Costs { get; set; }

        public double Weight { get; set; }

        [ForeignKey("PumpCategory")]
        public int PumpCategoryId { get; set; }

        public virtual PumpImage PumpImage { get; set; }

        [Required]
        public virtual PumpCategory PumpCategory { get; set; }
	}
}
