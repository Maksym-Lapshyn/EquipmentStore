using AutoMapper;
using EquipmentStore.BLL.Dtos;
using EquipmentStore.Web.Models;

namespace EquipmentStore.Web.Infrastructure
{
	public class WebAutoMapperProfile : Profile
	{
		public WebAutoMapperProfile()
		{
			CreateMap<ProductDto, ProductViewModel>()
				.ForMember(viewModel => viewModel.ImageData, opt => opt.MapFrom(dto => dto.MainImage))
				.ReverseMap();
			CreateMap<PumpDto, PumpViewModel>()
				.ForMember(viewModel => viewModel.ImageData, opt => opt.MapFrom(dto => dto.MainImage))
				.ReverseMap();
			CreateMap<OutputDto, OutputViewModel>()
				.ForMember(viewModel => viewModel.ImageData, opt => opt.MapFrom(dto => dto.MainImage))
				.ReverseMap();
			CreateMap<ProductImageDto, ImageViewModel>().ReverseMap();
			CreateMap<PumpImageDto, ImageViewModel>().ReverseMap();
			CreateMap<OutputImageDto, ImageViewModel>().ReverseMap();
		}
	}
}