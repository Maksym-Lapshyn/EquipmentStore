using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentStore.BLL.Services
{
	public class LabourService : IService<LabourDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public LabourService(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public LabourDto GetSingleOrDefault(int id)
		{
			var entity = _unitOfWork.LabourRepository.GetSingleOrDefault(id);
			var dto = _mapper.Map<Labour, LabourDto>(entity);

			return dto;
		}

		public IEnumerable<LabourDto> GetAll()
		{
			var entities = _unitOfWork.LabourRepository.GetAll();
			var dtos = _mapper.Map<IEnumerable<Labour>, List<LabourDto>>(entities);

			return dtos;
		}

		public void Add(LabourDto dto)
		{
			var entity = _mapper.Map<LabourDto, Labour>(dto);

			_unitOfWork.LabourRepository.Add(entity);
			_unitOfWork.Save();
		}

		public void Update(LabourDto dto)
		{
			var entity = _unitOfWork.LabourRepository.GetSingleOrDefault(dto.Id);
			entity = _mapper.Map(dto, entity);

			_unitOfWork.LabourRepository.Update(entity);
			_unitOfWork.Save();
		}

		public void Delete(int id)
		{
			_unitOfWork.LabourRepository.Delete(id);
			_unitOfWork.Save();
		}
	}
}
