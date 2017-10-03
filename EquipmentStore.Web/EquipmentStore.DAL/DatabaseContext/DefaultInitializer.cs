using EquipmentStore.Core.Entities;
using System.Data.Entity;

namespace EquipmentStore.DAL.DatabaseContext
{
	public class DefaultInitializer : DropCreateDatabaseIfModelChanges<EquipmentStoreContext>
	{
		protected override void Seed(EquipmentStoreContext context)
		{
			var testString = "test";

			var machine = new Machine
			{
				AirCompressor = testString,
				AirPressure = testString,
				CoolingType = testString,
				CuttingFrequency = testString,
				LongDescription = testString,
				ShortDescription = testString,
				MaxMoldingDepth = testString,
				MaximumPackageSize = testString
			};

			context.Machines.Add(machine);
			context.SaveChanges();
			base.Seed(context);
		}
	}
}
