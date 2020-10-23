using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EquivalencyExpression;
using SVFHardwareSystem.DAL.Entities;
using SVFHardwareSystem.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMap
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
                cfg.AllowNullCollections = true;
                cfg.AddCollectionMappers();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>().ForMember(dest => dest.Quantity, act => act.Ignore());
            // ignoring category id for updating entity
            CreateMap<CategoryModel, Category>().ForMember(dest => dest.CategoryID, act => act.Ignore());
            CreateMap<Category, CategoryModel>();
            // ignoring category id for updating entity
            CreateMap<CustomerModel, Customer>().ForMember(dest => dest.CustomerID, act => act.Ignore()); ;
            CreateMap<Customer, CustomerModel>();
            //
            CreateMap<Sale, SaleModel>();
            CreateMap<SaleModel, Sale>();

            //
            CreateMap<SaleProduct, SaleProductModel>();
            CreateMap<SaleProductModel, SaleProduct>();
            CreateMap<SaleProduct, SalesProductModel>();
            CreateMap<Sale, SalesModel>();
            CreateMap<Supplier, SupplierModel>();
            // ignoring category id for updating entity
            CreateMap<SupplierModel, Supplier>();

            CreateMap<PurchaseModel, Purchase>();
            CreateMap<Purchase, PurchaseModel>();

            CreateMap<PurchaseProduct, PurchaseProductModel>();
            CreateMap<PurchaseProductModel, PurchaseProduct>();

            CreateMap<PaymentMethod, PaymentMethodModel>();

            CreateMap<PurchasePayment, PurchasePaymentModel>();
            CreateMap<PurchasePaymentModel, PurchasePayment>();

            CreateMap<Product, PurchaseSaleInventoryProductModel>();
            CreateMap<PurchaseSaleInventoryProductModel, PurchaseSaleInventoryProduct>();
            CreateMap<PurchaseSaleInventoryProduct, PurchaseSaleInventoryProductModel>();

            CreateMap<Sale, CustomerReceivableModel>();
            CreateMap<Customer, CustomerReceivableModel>();
            CreateMap<Supplier, PurchasesPerSupplierModel>();

            CreateMap<Product, PurchaseProductInventoryModel>();
            // Additional mappings here...
        }
    }
}
