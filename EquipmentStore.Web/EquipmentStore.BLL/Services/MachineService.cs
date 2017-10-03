using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
	public class MachineService : IService<MachineDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public MachineService(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public MachineDto GetSingleOrDefault(int id)
		{
			var entity = _unitOfWork.MachineRepository.GetSingleOrDefault(id);
			var dto = _mapper.Map<Machine, MachineDto>(entity);

			return dto;
		}

		public IEnumerable<MachineDto> GetAll()
		{
			var entities = _unitOfWork.MachineRepository.GetAll();
			var dtos = _mapper.Map<IEnumerable<Machine>, List<MachineDto>>(entities);

			return dtos;
		}

		public void Add(MachineDto dto)
		{
			var entity = _mapper.Map<MachineDto, Machine>(dto);
			entity.MainImage.Machine = entity;

			_unitOfWork.MachineRepository.Add(entity);
			_unitOfWork.Save();
		}

		public void Update(MachineDto dto)
		{
			var entity = _unitOfWork.MachineRepository.GetSingleOrDefault(dto.Id);
			entity = _mapper.Map(dto, entity);

			_unitOfWork.MachineRepository.Update(entity);
			_unitOfWork.Save();
		}

		public void Delete(int id)
		{
			_unitOfWork.MachineRepository.Delete(id);
			_unitOfWork.MachineImageRepository.DeleteRange(i => i.Machine.Id == id);
			_unitOfWork.Save();
		}
	}
}
