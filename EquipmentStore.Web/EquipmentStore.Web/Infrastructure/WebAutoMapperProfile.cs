using EquipmentStore.BLL.Dtos;
using EquipmentStore.Web.Models;

namespace EquipmentStore.Web.Infrastructure
{
	public class WebAutoMapperProfile : Profile
	{
		public WebAutomapperProfile()
		{
			CreateMap<MachineDto, MachineViewModel>()
				.ForMember(viewModel => viewModel.ImageData, opt => opt.MapFrom(dto => dto.MainImage))
				.ReverseMap();
			CreateMap<LabourDto, LabourViewModel>()
				.ForMember(viewModel => viewModel.ImageData, opt => opt.MapFrom(dto => dto.MainImage))
				.ReverseMap();
			CreateMap<MachineImageDto, ImageViewModel>().ReverseMap();
			CreateMap<LabourImageDto, ImageViewModel>().ReverseMap();
		}
	}
}