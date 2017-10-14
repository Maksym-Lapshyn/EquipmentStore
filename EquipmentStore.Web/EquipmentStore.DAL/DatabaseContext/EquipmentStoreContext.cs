using EquipmentStore.Core.Entities;
using System.Data.Entity;

namespace EquipmentStore.DAL.DatabaseContext
{
	public class EquipmentStoreContext : DbContext
	{
		public DbSet<Machine> Machines { get; set; }

		public DbSet<Labour> Labours { get; set; }

		public DbSet<Output> Outputs { get; set; }

		public DbSet<MachineImage> MachineImages { get; set; }

		public DbSet<LabourImage> LabourImages { get; set; }

		public DbSet<OutputImage> OutputImages { get; set; }
	}
}
