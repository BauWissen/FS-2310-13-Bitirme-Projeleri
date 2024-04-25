namespace SalesUp.Entity;

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
}