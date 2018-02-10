using EquipmentStore.Core.Entities;
using EquipmentStore.Web.Models;
using ExpressMapper;

namespace EquipmentStore.Web.App_Start
{
    public class MappingConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Register<Product, ProductViewModel>();
            Mapper.Register<ProductViewModel, Product>();

            Mapper.Register<Pump, PumpViewModel>();
            Mapper.Register<PumpViewModel, Pump>();

            Mapper.Register<Output, OutputViewModel>();
            Mapper.Register<OutputViewModel, Output>();

            Mapper.Register<ProductImage, ImageViewModel>();
            Mapper.Register<ImageViewModel, ProductImage>();

            Mapper.Register<PumpImage, ImageViewModel>();
            Mapper.Register<ImageViewModel, PumpImage>();

            Mapper.Register<OutputImage, ImageViewModel>();
            Mapper.Register<ImageViewModel, OutputImage>();

            Mapper.Register<ProductCategory, ProductCategoryViewModel>();
            Mapper.Register<ProductCategoryViewModel, ProductCategory>();

            Mapper.Register<ProductSubCategory, ProductSubCategoryViewModel>();
            Mapper.Register<ProductSubCategoryViewModel, ProductSubCategory>();

            Mapper.Register<PumpCategory, PumpCategoryViewModel>();
            Mapper.Register<PumpCategoryViewModel, PumpCategory>();
        }
    }
}