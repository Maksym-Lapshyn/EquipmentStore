using AutoMapper;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentStore.BLL.Services
{
    public class ProductSubCategoryService : IService<ProductSubCategory>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductSubCategoryService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductSubCategory GetSingleOrDefault(int id)
        {
            var productSubCategory = _unitOfWork.ProductSubCategoryRepository.GetSingleOrDefault(id);

            return productSubCategory;
        }

        public IEnumerable<ProductSubCategory> GetAll()
        {
            var productSubCategories = _unitOfWork.ProductSubCategoryRepository.GetAll();

            return productSubCategories;
        }

        public void Add(ProductSubCategory productSubCategory)
        {
            var productCategory = _unitOfWork.ProductCategoryRepository.GetSingleOrDefault(productSubCategory.ProductCategoryId);
            productSubCategory.ProductCategory = productCategory ?? throw new InvalidOperationException("Product category with such id does not exist");

            _unitOfWork.ProductSubCategoryRepository.Add(productSubCategory);
            _unitOfWork.Save();
        }

        public void Update(ProductSubCategory productSubCategory)
        {
            var oldProductSubCategory = _unitOfWork.ProductSubCategoryRepository.GetSingleOrDefault(productSubCategory.Id);
            oldProductSubCategory = _mapper.Map(productSubCategory, oldProductSubCategory);

            var productCategory = _unitOfWork.ProductCategoryRepository.GetSingleOrDefault(productSubCategory.ProductCategoryId);
            oldProductSubCategory.ProductCategory = productCategory ?? throw new InvalidOperationException("Product category with such id does not exist");

            var products = _unitOfWork.ProductRepository.Get(p => p.ProductSubCategoryId == oldProductSubCategory.Id).ToList();
            oldProductSubCategory.Products = products;

            _unitOfWork.ProductSubCategoryRepository.Update(oldProductSubCategory);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.ProductImageRepository.DeleteRange(pi => pi.Product.ProductSubCategoryId == id);
            _unitOfWork.ProductRepository.DeleteRange(p => p.ProductSubCategoryId == id);
            _unitOfWork.ProductSubCategoryRepository.Delete(id);
            _unitOfWork.Save();
        }

        public bool CheckIfExists(int id)
        {
            return _unitOfWork.ProductSubCategoryRepository.Exists(id);
        }
    }
}
