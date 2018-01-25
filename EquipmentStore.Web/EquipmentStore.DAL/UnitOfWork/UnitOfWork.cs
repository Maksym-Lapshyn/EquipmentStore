using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.DatabaseContext;
using EquipmentStore.DAL.Repositories;
using System;

namespace EquipmentStore.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly EquipmentStoreContext _context;
		private readonly Lazy<IRepository<Product>> _productRepository;
		private readonly Lazy<IRepository<Pump>> _pumpRepository;
		private readonly Lazy<IRepository<Output>> _outputRepository;
		private readonly Lazy<IImageRepository<ProductImage>> _productImageRepository;
		private readonly Lazy<IImageRepository<PumpImage>> _pumpImageRepository;
		private readonly Lazy<IImageRepository<OutputImage>> _outputImageRepository;
        private readonly Lazy<IRepository<ProductCategory>> _productCategoryRepository;
        private readonly Lazy<IRepository<PumpCategory>> _pumpCategoryRepository;
        private readonly Lazy<IRepository<ProductSubCategory>> _productSubCategoryRepository;

        public UnitOfWork(EquipmentStoreContext context)
		{
			_context = context;
			_productRepository = new Lazy<IRepository<Product>>(() => new Repository<Product>(_context));
			_pumpRepository = new Lazy<IRepository<Pump>>(() => new Repository<Pump>(_context));
			_outputRepository = new Lazy<IRepository<Output>>(() => new Repository<Output>(_context));
			_productImageRepository = new Lazy<IImageRepository<ProductImage>>(() => new ProductImageRepository(_context));
			_pumpImageRepository = new Lazy<IImageRepository<PumpImage>>(() => new PumpImageRepository(_context));
			_outputImageRepository = new Lazy<IImageRepository<OutputImage>>(() => new OutputImageRepository(_context));
            _productCategoryRepository = new Lazy<IRepository<ProductCategory>>(() => new Repository<ProductCategory>(_context));
            _pumpCategoryRepository = new Lazy<IRepository<PumpCategory>>(() => new Repository<PumpCategory>(_context));
            _productSubCategoryRepository = new Lazy<IRepository<ProductSubCategory>>(() => new Repository<ProductSubCategory>(_context));
        }

		public IRepository<Product> ProductRepository => _productRepository.Value;

		public IRepository<Pump> PumpRepository => _pumpRepository.Value;

		public IRepository<Output> OutputRepository => _outputRepository.Value;

		public IImageRepository<ProductImage> ProductImageRepository => _productImageRepository.Value;

		public IImageRepository<PumpImage> PumpImageRepository => _pumpImageRepository.Value;

		public IImageRepository<OutputImage> OutputImageRepository => _outputImageRepository.Value;

        public IRepository<ProductCategory> ProductCategoryRepository => _productCategoryRepository.Value;

        public IRepository<PumpCategory> PumpCategoryRepository => _pumpCategoryRepository.Value;

        public IRepository<ProductSubCategory> ProductSubCategoryRepository => _productSubCategoryRepository.Value;

        public void Save()
		{
			_context.SaveChanges();
		}
	}
}
