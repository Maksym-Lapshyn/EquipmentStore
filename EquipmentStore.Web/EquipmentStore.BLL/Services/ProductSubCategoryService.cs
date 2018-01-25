using AutoMapper;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;

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
            _unitOfWork.ProductSubCategoryRepository.Add(productSubCategory);
            _unitOfWork.Save();
        }

        public void Update(ProductSubCategory productSubCategory)
        {
            var oldProductSubCategory = _unitOfWork.ProductSubCategoryRepository.GetSingleOrDefault(productSubCategory.Id);
            oldProductSubCategory = _mapper.Map(productSubCategory, oldProductSubCategory);

            _unitOfWork.ProductSubCategoryRepository.Update(oldProductSubCategory);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.ProductSubCategoryRepository.Delete(id);
            _unitOfWork.Save();
        }

        public bool CheckIfExists(int id)
        {
            return _unitOfWork.ProductSubCategoryRepository.Exists(id);
        }
    }
}
