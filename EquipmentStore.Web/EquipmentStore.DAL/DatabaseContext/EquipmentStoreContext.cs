using EquipmentStore.Core.Entities;
using System.Data.Entity;

namespace EquipmentStore.DAL.DatabaseContext
{
	public class EquipmentStoreContext : DbContext
	{
		public EquipmentStoreContext(string connectionString) : base(connectionString)
		{
		}

		public DbSet<Product> Machines { get; set; }

		public DbSet<Pump> Labours { get; set; }

		public DbSet<Output> Outputs { get; set; }

		public DbSet<ProductImage> MachineImages { get; set; }

		public DbSet<PumpImage> LabourImages { get; set; }

		public DbSet<OutputImage> OutputImages { get; set; }
    }
}
