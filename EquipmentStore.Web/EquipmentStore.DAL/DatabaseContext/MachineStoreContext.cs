using EquipmentStore.Core.Entities;
using System.Data.Entity;

namespace EquipmentStore.DAL.DatabaseContext
{
	public class MachineStoreContext : DbContext
	{
		public MachineStoreContext(string connectionString) : base(connectionString)
		{
		}

		public DbSet<Machine> Machines { get; set; }

		public DbSet<Labour> Labours { get; set; }

		public DbSet<MachineImage> MachineImages { get; set; }

		public DbSet<LabourImage> LabourImages { get; set; }
	}
}
