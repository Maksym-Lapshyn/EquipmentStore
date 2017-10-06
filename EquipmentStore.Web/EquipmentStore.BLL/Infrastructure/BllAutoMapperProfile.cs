using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;

namespace EquipmentStore.BLL.Infrastructure
{
	public class BllAutomapperProfile : Profile
	{
		public BllAutomapperProfile()
		{
			CreateMap<Machine, MachineDto>().ReverseMap();
			CreateMap<Labour, LabourDto>().ReverseMap();
			CreateMap<Output, OutputDto>().ReverseMap();
			CreateMap<LabourImage, LabourImageDto>().ReverseMap();
			CreateMap<MachineImage, MachineImageDto>().ReverseMap();
			CreateMap<OutputImage, OutputImageDto>().ReverseMap();
		}
	}
}
