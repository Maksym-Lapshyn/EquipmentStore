using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Core.Entities;

namespace EquipmentStore.BLL.Infrastructure
{
	public class BllAutomapperProfile : Profile
	{
		public BllAutomapperProfile()
		{
			CreateMap<Product, MachineDto>().ReverseMap();
			CreateMap<Pump, LabourDto>().ReverseMap();
			CreateMap<Output, OutputDto>().ReverseMap();
			CreateMap<PumpImage, LabourImageDto>().ReverseMap();
			CreateMap<ProductImage, MachineImageDto>().ReverseMap();
			CreateMap<OutputImage, OutputImageDto>().ReverseMap();
		}
	}
}
