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

        public string Heads4 { get; set; }

        public string Tubes4 { get; set; }

        public string Costs4 { get; set; }

        public double Weight4 { get; set; }

        public string Heads2 { get; set; }

        public string Tubes2 { get; set; }

        public string Costs2 { get; set; }

        public double Weight2 { get; set; }

        public string Heads3 { get; set; }

        public string Tubes3 { get; set; }

        public string Costs3 { get; set; }

        public double Weight3 { get; set; }

        [ForeignKey("PumpCategory")]
        public int PumpCategoryId { get; set; }

        public virtual PumpImage PumpImage { get; set; }

        [Required]
        public virtual PumpCategory PumpCategory { get; set; }
	}
}
