using SalesUp.Shared.ViewModels.Product;
using SalesUp.Shared.ViewModels.Subscription;

namespace SalesUp.Shared.ViewModels;

public class AdminOrderViewModel
{
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public List<AdminOrderDetailViewModel> OrderDetails { get; set; }

        public decimal TotalPrice {
            get{ return OrderDetails.Sum(x => x.Quantity * x.Price); }
    }

    public class AdminOrderDetailViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public SubscriptionViewModel Subscription { get; set; }
    }
}