using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.Repositories;

namespace EquipmentStore.DAL.UnitOfWork
{
    public interface IUnitOfWork
	{
		IRepository<Product> ProductRepository { get; }

		IRepository<Pump> PumpRepository { get; }

		IRepository<Output> OutputRepository { get; }

		IImageRepository<ProductImage> ProductImageRepository { get; }

		IImageRepository<PumpImage> PumpImageRepository { get; }

		IImageRepository<OutputImage> OutputImageRepository { get; }

        IRepository<ProductCategory> ProductCategoryRepository { get; }

        IRepository<PumpCategory> PumpCategoryRepository { get; }

        IRepository<ProductSubCategory> ProductSubCategoryRepository { get; }

        void Save();
	}
}
