using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.Repositories;
using EquipmentStore.DAL.UnitOfWork;
using System.Collections.Generic;

namespace EquipmentStore.BLL.Services
{
	public class MachineService : IService<MachineDto>
	{
		private readonly IRepository<Machine> _machineRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IImageRepository<MachineImage> _imageRepository;
		private readonly IMapper _mapper;

		public MachineService(IRepository<Machine> machineRepository,
			IUnitOfWork unitOfWork,
			IImageRepository<MachineImage> imageRepository,
			IMapper mapper)
		{
			_machineRepository = machineRepository;
			_unitOfWork = unitOfWork;
			_imageRepository = imageRepository;
			_mapper = mapper;
		}

		public MachineDto GetSingleOrDefault(int id)
		{
			var entity = _machineRepository.GetSingleOrDefault(id);
			var dto = _mapper.Map<Machine, MachineDto>(entity);

			return dto;
		}

		public IEnumerable<MachineDto> GetAll()
		{
			var entities = _machineRepository.GetAll();
			var dtos = _mapper.Map<IEnumerable<Machine>, List<MachineDto>>(entities);

			return dtos;
		}

		public void Add(MachineDto dto)
		{
			var entity = _mapper.Map<MachineDto, Machine>(dto);

			_machineRepository.Add(entity);
			_unitOfWork.Save();
		}

		public void Update(MachineDto dto)
		{
			var entity = _machineRepository.GetSingleOrDefault(dto.Id);
			entity = _mapper.Map(dto, entity);

			_machineRepository.Update(entity);
			_unitOfWork.Save();
		}

		public void Delete(int id)
		{
			_machineRepository.Delete(id);
			_imageRepository.DeleteRange(i => i.Machine.Id == id);
			_unitOfWork.Save();
		}
	}
}
