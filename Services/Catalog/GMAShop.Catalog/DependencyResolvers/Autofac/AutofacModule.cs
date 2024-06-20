using Autofac;
using GMAShop.Catalog.Services.AboutServices;
using GMAShop.Catalog.Services.BrandServices;
using GMAShop.Catalog.Services.CategoryServices;
using GMAShop.Catalog.Services.ContactServices;
using GMAShop.Catalog.Services.FeatureServices;
using GMAShop.Catalog.Services.FeatureSliderServices;
using GMAShop.Catalog.Services.OfferDiscountServices;
using GMAShop.Catalog.Services.ProductDetailServices;
using GMAShop.Catalog.Services.ProductImageServices;
using GMAShop.Catalog.Services.ProductServices;
using GMAShop.Catalog.Services.SpecialOfferServices;
using GMAShop.Catalog.Services.StatisticServices;


namespace GMAShop.Catalog.DependencyResolvers.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutService>().As<IAboutService>().SingleInstance();
            builder.RegisterType<StatisticService>().As<IStatisticService>().SingleInstance();

            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();

            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();

            builder.RegisterType<ProductDetailService>().As<IProductDetailService>().SingleInstance();

            builder.RegisterType<ProductImageService>().As<IProductImageService>().SingleInstance();

            builder.RegisterType<FeatureSliderService>().As<IFeatureSliderService>().SingleInstance();

            builder.RegisterType<SpecialOfferService>().As<ISpecialOfferService>().SingleInstance();

            builder.RegisterType<FeatureService>().As<IFeatureService>().SingleInstance();

            builder.RegisterType<OfferDiscountService>().As<IOfferDiscountService>().SingleInstance();

            builder.RegisterType<BrandService>().As<IBrandService>().SingleInstance();

            builder.RegisterType<AboutService>().As<IAboutService>().SingleInstance();

            builder.RegisterType<ContactService>().As<IContactService>().SingleInstance();
        }
    }
}