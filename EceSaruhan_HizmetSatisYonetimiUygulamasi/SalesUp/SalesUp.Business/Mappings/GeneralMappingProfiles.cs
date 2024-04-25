using AutoMapper;
using SalesUp.Entity;
using SalesUp.Entity.Identity;
using SalesUp.Shared.ViewModels;
using SalesUp.Shared.ViewModels.Customer;
using SalesUp.Shared.ViewModels.IdentityModels;
using SalesUp.Shared.ViewModels.Product;
using SalesUp.Shared.ViewModels.Sale;
using SalesUp.Shared.ViewModels.STask;
using SalesUp.Shared.ViewModels.Subscription;

namespace SalesUp.Business.Mappings;

public class GeneralMappingProfiles : Profile
{
    public GeneralMappingProfiles()
    {
        CreateMap<Customer, AddCustomerViewModel>().ReverseMap();
        CreateMap<Customer, CustomerViewModel>().ReverseMap();
        CreateMap<Customer, EditCustomerViewModel>().ReverseMap();

        CreateMap<Product, ProductViewModel>().ReverseMap();
        CreateMap<Product, AddProductViewModel>().ReverseMap();
        CreateMap<Product, EditProductViewModel>().ReverseMap();


        CreateMap<Sale, SaleViewModel>().ReverseMap();
        CreateMap<Sale, AddSaleViewModel>().ReverseMap();
        CreateMap<Sale, EditSaleViewModel>().ReverseMap();


        CreateMap<STask, STaskViewModel>().ReverseMap();
        CreateMap<STask, AddSTaskViewModel>().ReverseMap();
        CreateMap<STask, EditSTaskViewModel>().ReverseMap();

        CreateMap<Order, OrderViewModel>().ReverseMap();
        CreateMap<Order, AdminOrderViewModel>().ReverseMap();

        CreateMap<Message, MessageViewModel>().ReverseMap();

        CreateMap<Subscription, SubscriptionViewModel>().ReverseMap();
        CreateMap<Subscription, AddSubscriptionViewModel>().ReverseMap();
        CreateMap<Subscription, EditSubscriptionViewModel>().ReverseMap();

        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<User, UserProfileViewModel>().ReverseMap();

        CreateMap<ContactUs, ContactUsViewModel>().ReverseMap();
    }
}