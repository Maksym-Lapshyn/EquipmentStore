using AutoMapper;
using EquipmentStore.Core.Entities;
using EquipmentStore.Web.Models;

namespace EquipmentStore.Web.Infrastructure
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();

            CreateMap<Pump, PumpViewModel>().ReverseMap();

            CreateMap<Output, OutputViewModel>().ReverseMap();

            CreateMap<ProductImage, ImageViewModel>().ReverseMap();

            CreateMap<PumpImage, ImageViewModel>().ReverseMap();

            CreateMap<OutputImage, ImageViewModel>().ReverseMap();

            CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();

            CreateMap<ProductSubCategory, ProductSubCategoryViewModel>().ReverseMap();

            CreateMap<PumpCategory, PumpCategoryViewModel>().ReverseMap();
        }
    }
}