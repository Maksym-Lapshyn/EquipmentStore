using EquipmentStore.Core.Entities;
using System.Data.Entity;

namespace EquipmentStore.DAL.DatabaseContext
{
    public class EquipmentStoreContext : DbContext
	{
		public EquipmentStoreContext(string connectionString) : base(connectionString)
		{
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<Pump> Pumps { get; set; }

		public DbSet<Output> Outputs { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<PumpCategory> PumpCategories { get; set; }

		public DbSet<ProductImage> ProductImages { get; set; }

		public DbSet<PumpImage> PumpImages { get; set; }

		public DbSet<OutputImage> OutputImages { get; set; }

        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
    }
}
