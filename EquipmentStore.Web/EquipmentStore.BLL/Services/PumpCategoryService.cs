using AutoMapper;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
    public class PumpCategoryService : IService<PumpCategory>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PumpCategoryService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PumpCategory GetSingleOrDefault(int id)
        {
            var pumpCategory = _unitOfWork.PumpCategoryRepository.GetSingleOrDefault(id);

            return pumpCategory;
        }

        public IEnumerable<PumpCategory> GetAll()
        {
            var pumpCategories = _unitOfWork.PumpCategoryRepository.GetAll();

            return pumpCategories;
        }

        public void Add(PumpCategory pumpCategory)
        {
            _unitOfWork.PumpCategoryRepository.Add(pumpCategory);
            _unitOfWork.Save();
        }

        public void Update(PumpCategory pumpCategory)
        {
            var oldPumpCategory = _unitOfWork.PumpCategoryRepository.GetSingleOrDefault(pumpCategory.Id);
            oldPumpCategory = _mapper.Map(pumpCategory, oldPumpCategory);

            _unitOfWork.PumpCategoryRepository.Update(oldPumpCategory);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.PumpCategoryRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
