using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;

namespace EquipmentStore.BLL.Services
{
	public class MachineImageService : IImageService<MachineImageDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public MachineImageService(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void Add(MachineImageDto dto)
		{
			var entity = _mapper.Map<MachineImageDto, MachineImage>(dto);

			_unitOfWork.MachineImageRepository.Add(entity);
		}

		public void Delete(int id)
		{
			_unitOfWork.MachineImageRepository.Delete(id);
			_unitOfWork.Save();
		}
	}
}
