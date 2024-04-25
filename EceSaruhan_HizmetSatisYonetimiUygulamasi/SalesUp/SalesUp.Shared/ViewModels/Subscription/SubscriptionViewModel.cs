using SalesUp.Shared.ComplexTypes;

namespace SalesUp.Shared.ViewModels.Subscription;

public class SubscriptionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public decimal TotalPrice
    {
        get { return Price * Duration; }
    }
    public int Duration { get; set; }
    public string DurationUnit { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public DateTime CreatedDate { get; set; }=DateTime.Now;
    public DateTime UpdateDate { get; set; }=DateTime.Now;
}