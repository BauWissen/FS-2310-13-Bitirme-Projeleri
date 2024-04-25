using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TigrisApp.Entity.Concrete;
using TigrisApp.Shared.ViewModels;

namespace TigrisApp.Business.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Region, RegionViewModel>().ReverseMap();
            CreateMap<Region, AddRegionViewModel>().ReverseMap();
            CreateMap<Region, UpdateRegionViewModel>().ReverseMap();

            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, AddCategoryViewModel>().ReverseMap();
            CreateMap<Category, UpdateCategoryViewModel>().ReverseMap();

            CreateMap<Colour, ColourViewModel>().ReverseMap();
            CreateMap<Colour, AddColourViewModel>().ReverseMap();
            CreateMap<Colour, UpdateCategoryViewModel>().ReverseMap();

            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, AddCustomerViewModel>().ReverseMap();
            CreateMap<Customer, UpdateCustomerViewModel>().ReverseMap();
            

            CreateMap<Gender, GenderViewModel>().ReverseMap();

            CreateMap<Material, MaterialViewModel>().ReverseMap();
            CreateMap<Material, AddMaterialViewModel>().ReverseMap();
            CreateMap<Material, UpdateMaterialViewModel>().ReverseMap();

            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, AddProductViewModel>().ReverseMap();
            CreateMap<Product, UpdateProductViewModel>().ReverseMap();

            CreateMap<Region, RegionViewModel>().ReverseMap();
            CreateMap<Region, AddRegionViewModel>().ReverseMap();
            CreateMap<Region, UpdateRegionViewModel>().ReverseMap();

            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Supplier, AddSupplierViewModel>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierViewModel>().ReverseMap();

        }
    }
}