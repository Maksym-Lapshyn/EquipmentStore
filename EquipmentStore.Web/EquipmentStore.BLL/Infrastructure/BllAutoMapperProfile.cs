using AutoMapper;
using EquipmentStore.Core.Entities;

namespace EquipmentStore.BLL.Infrastructure
{
    public class BllAutomapperProfile : Profile
	{
		public BllAutomapperProfile()
		{
            CreateMap<Product, Product>();
            CreateMap<Pump, Pump>();
            CreateMap<Output, Output>();
            CreateMap<ProductCategory, ProductCategory>();
            CreateMap<ProductSubCategory, ProductSubCategory>();
            CreateMap<PumpCategory, PumpCategory>();
            CreateMap<OutputImage, OutputImage>();
            CreateMap<PumpImage, PumpImage>();
            CreateMap<ProductImage, ProductImage>();
        }
	}
}
