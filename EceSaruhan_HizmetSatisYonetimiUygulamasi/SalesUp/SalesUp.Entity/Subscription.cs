using SalesUp.Entity.Identity;
using SalesUp.Shared.ComplexTypes;

namespace SalesUp.Entity;

public class Subscription
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public string DurationUnit { get; set; }
    
    public SubscriptionType SubscriptionType { get; set; } 
    
    public List<User> Users { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; }=DateTime.Now;
    public DateTime UpdateDate { get; set; }=DateTime.Now;
}