using SalesUp.Shared.ViewModels.IdentityModels;

namespace SalesUp.Shared.ViewModels.Sale;

public class SaleViewModel
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime CompletedDate { get; set; } = DateTime.Now;
    public decimal Amount { get; set; }
    public string Unit { get; set; }
    public decimal UnitPrice { get; set; }
    public string ProductName { get; set; }
    public bool IsCompleted { get; set; }
    public string UserId { get; set; }
    public string Note { get; set; }

    public decimal TotalPrice
    {
        get { return UnitPrice * Amount; }
    }
}