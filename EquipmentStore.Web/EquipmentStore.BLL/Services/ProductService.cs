using AutoMapper;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
    public class ProductService : IService<Product>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductService(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public Product GetSingleOrDefault(int id)
		{
			var product = _unitOfWork.ProductRepository.GetSingleOrDefault(id);

			return product;
		}

		public IEnumerable<Product> GetAll()
		{
			var products = _unitOfWork.ProductRepository.GetAll();

			return products;
		}

		public void Add(Product product)
		{
            var subCategory = _unitOfWork.ProductSubCategoryRepository.GetSingleOrDefault(product.ProductSubCategoryId);
            product.ProductSubCategory = subCategory ?? throw new InvalidOperationException("Subcategory with such id does not exist");

			_unitOfWork.ProductRepository.Add(product);
			_unitOfWork.Save();
		}

		public void Update(Product product)
		{
            var oldProduct = _unitOfWork.ProductRepository.GetSingleOrDefault(product.Id);
            oldProduct = _mapper.Map(product, oldProduct);

            var subCategory = _unitOfWork.ProductSubCategoryRepository.GetSingleOrDefault(product.ProductSubCategoryId);
            oldProduct.ProductSubCategory = subCategory ?? throw new InvalidOperationException("Subcategory with such id does not exist");

            _unitOfWork.ProductRepository.Update(oldProduct);

            var oldImage = _unitOfWork.ProductImageRepository.GetSingleOrDefault(product.Id);
            oldImage = _mapper.Map(product.ProductImage, oldImage);

            _unitOfWork.ProductImageRepository.Update(oldImage);

            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.ProductRepository.Delete(id);
            _unitOfWork.ProductImageRepository.Delete(id);
            _unitOfWork.Save();
        }

        public bool CheckIfExists(int id)
        {
            return _unitOfWork.ProductRepository.Exists(id);
        }
    }
}
