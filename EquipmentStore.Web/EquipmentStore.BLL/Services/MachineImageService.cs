using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.Repositories;
using EquipmentStore.DAL.UnitOfWork;

namespace EquipmentStore.BLL.Services
{
	public class MachineImageService : IImageService<MachineImageDto>
	{
		private readonly IImageRepository<MachineImage> _imageRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public MachineImageService(IImageRepository<MachineImage> imageRepository,
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_imageRepository = imageRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void Add(MachineImageDto dto)
		{
			var entity = _mapper.Map<MachineImageDto, MachineImage>(dto);

			_imageRepository.Add(entity);
		}

		public void Delete(int id)
		{
			_imageRepository.Delete(id);
			_unitOfWork.Save();
		}
	}
}
