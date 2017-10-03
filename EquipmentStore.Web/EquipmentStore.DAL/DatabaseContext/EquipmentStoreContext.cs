using EquipmentStore.Core.Entities;
using System.Data.Entity;

namespace EquipmentStore.DAL.DatabaseContext
{
	public class EquipmentStoreContext : DbContext
	{
		public EquipmentStoreContext(string connectionString) : base(connectionString)
		{
		}

		/*static EquipmentStoreContext()
		{
			Database.SetInitializer(new DefaultInitializer());
		}*/

		public DbSet<Machine> Machines { get; set; }

		public DbSet<Labour> Labours { get; set; }

		public DbSet<MachineImage> MachineImages { get; set; }

		public DbSet<LabourImage> LabourImages { get; set; }
	}
}
