using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentStore.Core.Entities
{
    public class Output : BaseEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }

        [ForeignKey("MainImage")]
        public int MainImageId { get; set; }

		public virtual OutputImage MainImage { get; set; }
	}
}
