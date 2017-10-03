using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;
using EquipmentStore.DAL.UnitOfWork;

namespace EquipmentStore.BLL.Services
{
	public class LabourImageService : IImageService<LabourImageDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public LabourImageService(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void Add(LabourImageDto dto)
		{
			var entity = _mapper.Map<LabourImageDto, LabourImage>(dto);

			_unitOfWork.LabourImageRepository.Add(entity);
		}

		public void Delete(int id)
		{
			_unitOfWork.LabourImageRepository.Delete(id);
			_unitOfWork.Save();
		}
	}
}
