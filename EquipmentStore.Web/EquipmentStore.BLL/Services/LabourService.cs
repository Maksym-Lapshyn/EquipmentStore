using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.Repositories;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
	public class LabourService : IService<LabourDto>
	{
		private readonly IRepository<Labour> _labourRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public LabourService(IRepository<Labour> labourRepository,
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_labourRepository = labourRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public LabourDto GetSingleOrDefault(int id)
		{
			var entity = _labourRepository.GetSingleOrDefault(id);
			var dto = _mapper.Map<Labour, LabourDto>(entity);

			return dto;
		}

		public IEnumerable<LabourDto> GetAll()
		{
			var entities = _labourRepository.GetAll();
			var dtos = _mapper.Map<IEnumerable<Labour>, List<LabourDto>>(entities);

			return dtos;
		}

		public void Add(LabourDto dto)
		{
			var entity = _mapper.Map<LabourDto, Labour>(dto);

			_labourRepository.Add(entity);
			_unitOfWork.Save();
		}

		public void Update(LabourDto dto)
		{
			var entity = _labourRepository.GetSingleOrDefault(dto.Id);
			entity = _mapper.Map(dto, entity);

			_labourRepository.Update(entity);
			_unitOfWork.Save();
		}

		public void Delete(int id)
		{
			_labourRepository.Delete(id);
			_unitOfWork.Save();
		}
	}
}
