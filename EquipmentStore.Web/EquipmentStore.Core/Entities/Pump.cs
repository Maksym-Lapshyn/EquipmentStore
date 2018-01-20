namespace EquipmentStore.Core.Entities
{
    public class Pump
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

        public int MainImageId { get; set; }

        public int CategoryId { get; set; }

		public virtual PumpImage MainImage { get; set; }

        public virtual PumpCategory Category { get; set; }
	}
}
