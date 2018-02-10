using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using ExpressMapper;
using System;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
    public class PumpService : IService<Pump>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMappingServiceProvider _mapper;

		public PumpService(IUnitOfWork unitOfWork,
            IMappingServiceProvider mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public Pump GetSingleOrDefault(int id)
		{
			var pump = _unitOfWork.PumpRepository.GetSingleOrDefault(id);

			return pump;
		}

		public IEnumerable<Pump> GetAll()
		{
			var pumps = _unitOfWork.PumpRepository.GetAll();

			return pumps;
		}

		public void Add(Pump pump)
		{
            var pumpCategory = _unitOfWork.PumpCategoryRepository.GetSingleOrDefault(pump.PumpCategoryId);
            pump.PumpCategory = pumpCategory ?? throw new InvalidOperationException("There is no such category in the database");

            _unitOfWork.PumpRepository.Add(pump);
            _unitOfWork.Save();
		}

        public void Update(Pump pump)
        {
            var oldPump = _unitOfWork.PumpRepository.GetSingleOrDefault(pump.Id);
            oldPump = _mapper.Map(pump, oldPump);

            var pumpCategory = _unitOfWork.PumpCategoryRepository.GetSingleOrDefault(pump.PumpCategoryId);
            oldPump.PumpCategory = pumpCategory ?? throw new InvalidOperationException("There is no such category in the database");

            _unitOfWork.PumpRepository.Update(oldPump);

            var oldImage = _unitOfWork.PumpImageRepository.GetSingleOrDefault(pump.Id);
            oldImage = _mapper.Map(pump.PumpImage, oldImage);

            _unitOfWork.PumpImageRepository.Update(oldImage);

            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.PumpRepository.Delete(id);
            _unitOfWork.PumpImageRepository.Delete(id);
            _unitOfWork.Save();
        }

        public bool CheckIfExists(int id)
        {
            return _unitOfWork.PumpRepository.Exists(id);
        }
    }
}
