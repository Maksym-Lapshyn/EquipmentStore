using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.Repositories;

namespace EquipmentStore.DAL.UnitOfWork
{
    public interface IUnitOfWork
	{
		IExtendingRepository<Product> ProductRepository { get; }

        IExtendingRepository<Pump> PumpRepository { get; }

		IRepository<Output> OutputRepository { get; }

		IImageRepository<ProductImage> ProductImageRepository { get; }

		IImageRepository<PumpImage> PumpImageRepository { get; }

		IImageRepository<OutputImage> OutputImageRepository { get; }

        IRepository<ProductCategory> ProductCategoryRepository { get; }

        IRepository<PumpCategory> PumpCategoryRepository { get; }

        IExtendingRepository<ProductSubCategory> ProductSubCategoryRepository { get; }

        void Save();
	}
}
