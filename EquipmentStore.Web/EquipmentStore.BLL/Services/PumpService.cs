using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
    public class PumpService : IService<Pump>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public PumpService(IUnitOfWork unitOfWork,
			IMapper mapper)
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
			_unitOfWork.PumpRepository.Add(pump);
			_unitOfWork.Save();
		}

		public void Update(Pump pump)
		{
			var oldPump = _unitOfWork.PumpRepository.GetSingleOrDefault(pump.Id);
			oldPump = _mapper.Map(pump, oldPump);

			_unitOfWork.PumpRepository.Update(oldPump);
			_unitOfWork.Save();
		}

		public void Delete(int id)
		{
			_unitOfWork.PumpRepository.Delete(id);
			_unitOfWork.Save();
		}

        public bool CheckIfExists(int id)
        {
            return _unitOfWork.PumpRepository.Exists(id);
        }
    }
}
