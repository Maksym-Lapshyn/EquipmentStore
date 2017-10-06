using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using EquipmentStore.Core.Entities;

namespace EquipmentStore.BLL.Services
{
	public class OutputService : IService<OutputDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public OutputService(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public OutputDto GetSingleOrDefault(int id)
		{
			var entity = _unitOfWork.OutputRepository.GetSingleOrDefault(id);
			var dto = _mapper.Map<Output, OutputDto>(entity);

			return dto;
		}

		public IEnumerable<OutputDto> GetAll()
		{
			var entities = _unitOfWork.OutputRepository.GetAll();
			var dtos = _mapper.Map<IEnumerable<Output>, List<OutputDto>>(entities);

			return dtos;
		}

		public void Add(OutputDto dto)
		{
			var entity = _mapper.Map<OutputDto, Output>(dto);

			_unitOfWork.OutputRepository.Add(entity);
			_unitOfWork.Save();
		}

		public void Update(OutputDto dto)
		{
			var entity = _unitOfWork.OutputRepository.GetSingleOrDefault(dto.Id);
			entity = _mapper.Map(dto, entity);

			_unitOfWork.OutputRepository.Update(entity);
			_unitOfWork.Save();
		}

		public void Delete(int id)
		{
			_unitOfWork.OutputRepository.Delete(id);
			_unitOfWork.OutputImageRepository.DeleteRange(i => i.Output.Id == id);
			_unitOfWork.Save();
		}
	}
}
