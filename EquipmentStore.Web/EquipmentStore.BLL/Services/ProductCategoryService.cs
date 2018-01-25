using AutoMapper;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
    public class ProductCategoryService : IService<ProductCategory>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCategoryService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductCategory GetSingleOrDefault(int id)
        {
            var productCategory = _unitOfWork.ProductCategoryRepository.GetSingleOrDefault(id);

            return productCategory;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            var productCategories = _unitOfWork.ProductCategoryRepository.GetAll();

            return productCategories;
        }

        public void Add(ProductCategory productCategory)
        {
            _unitOfWork.ProductCategoryRepository.Add(productCategory);
            _unitOfWork.Save();
        }

        public void Update(ProductCategory productCategory)
        {
            var oldProductCategory = _unitOfWork.ProductCategoryRepository.GetSingleOrDefault(productCategory.Id);
            oldProductCategory = _mapper.Map(productCategory, oldProductCategory);

            _unitOfWork.ProductCategoryRepository.Update(oldProductCategory);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.ProductCategoryRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
