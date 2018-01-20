using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class Output
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

        [ForeignKey("MainIMage")]
        public int MainImageId { get; set; }

		public virtual OutputImage MainImage { get; set; }
	}
}
