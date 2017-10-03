using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.Repositories;
using EquipmentStore.DAL.UnitOfWork;

namespace EquipmentStore.BLL.Services
{
	public class LabourImageService : IImageService<LabourImageDto>
	{
		private readonly IImageRepository<LabourImage> _imageRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public LabourImageService(IImageRepository<LabourImage> imageRepository,
			IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_imageRepository = imageRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void Add(LabourImageDto dto)
		{
			var entity = _mapper.Map<LabourImageDto, LabourImage>(dto);

			_imageRepository.Add(entity);
		}

		public void Delete(int id)
		{
			_imageRepository.Delete(id);
			_unitOfWork.Save();
		}
	}
}
