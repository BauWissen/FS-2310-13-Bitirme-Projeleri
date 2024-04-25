using Riok.Mapperly.Abstractions;
using SalesUp.Entity;
using SalesUp.Shared.ViewModels;
using SalesUp.Shared.ViewModels.Customer;
using SalesUp.Shared.ViewModels.Product;
using SalesUp.Shared.ViewModels.Sale;
using SalesUp.Shared.ViewModels.STask;
using SalesUp.Shared.ViewModels.Subscription;


namespace SalesUp.Business.Mappings;

[Mapper]
public partial class MapperlyConfig
{
    #region Customer

    public partial CustomerViewModel CustomerToCustomerViewModel(Customer customer);
    public partial AddCustomerViewModel CustomerToAddCustomerViewModel(Customer customer);
    public partial EditCustomerViewModel CustomerToEditCustomerViewModel(Customer customer);
    public partial Customer CustomerViewModelToCustomer(CustomerViewModel customerViewModel);
    public partial Customer AddCustomerViewModelToCustomer(AddCustomerViewModel addCustomerViewModel);
    public partial Customer EditCustomerViewModelToCustomer(EditCustomerViewModel editCustomerViewModel);

    #endregion

    #region Product

    public partial ProductViewModel ProductToProductViewModel(Product product);
    public partial AddProductViewModel ProductToAddProductViewModel(Product product);
    public partial EditProductViewModel ProductToEditProductViewModel(Product product);
    public partial Product ProductViewModelToProduct(ProductViewModel productViewModel);
    public partial Product AddProductViewModelToProduct(AddProductViewModel addProductViewModel);
    public partial Product EditProductViewModelToProduct(EditProductViewModel editProductViewModel);


    #endregion

    #region Sale

    public partial SaleViewModel SaleToSaleViewModel(Sale sale);
    public partial AddSaleViewModel SaleToAddSaleViewModel(Sale sale);
    public partial EditSaleViewModel SaleToEditSaleViewModel(Sale sale);
    public partial Sale SaleViewModelToSale(SaleViewModel saleViewModel);
    public partial Sale AddSaleViewModelToSale(AddSaleViewModel addSaleViewModel);
    public partial Sale EditSaleViewModelToSale(EditSaleViewModel editSaleViewModel);


    #endregion

    #region STask

    public partial STaskViewModel STaskToSTaskViewModel(STask sTask);
    public partial AddSTaskViewModel STaskToAddSTaskViewModel(STask sTask);
    public partial EditSTaskViewModel STaskToEditSTaskViewModel(STask sTask);
    public partial STask STaskViewModelToSTask(STaskViewModel sTaskViewModel);
    public partial STask AddSTaskViewModelToSTask(AddSTaskViewModel addSTaskViewModel);
    public partial STask EditSTaskViewModelToSTask(EditSTaskViewModel editSTaskViewModel);
    public partial List<STask> STaskListViewModelToSTaskList(List<STaskViewModel> sTaskListViewModel);
    public partial List<STaskViewModel> STaskListToSTaskListViewModel(List<STask> sTaskList);
    
    #endregion

    public partial OrderViewModel OrderToOrderViewModel(Order order);
    public partial Order OrderViewModelToOrder(OrderViewModel orderViewModel);
    public partial AdminOrderViewModel OrderToAdminOrderViewModel(Order order);
    public partial Order AdminOrderViewModelToOrder(AdminOrderViewModel adminOrderViewModel);
    public partial MessageViewModel MessageToMessageViewModel(Message message);
    public partial Message MessageViewModelToMessage(MessageViewModel messageViewModel);

    public partial SubscriptionViewModel SubscriptionToSubscriptionViewModel(Subscription subscription);
    public partial Subscription SubscriptionViewModelToSubscription(SubscriptionViewModel subscriptionViewModel);
    
}