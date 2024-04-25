namespace SalesUp.Shared.ViewModels.Product;

public class ProductViewModel
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public string Name { get; set; }
    public string Properties { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }
    public string UserId { get; set; }

    public decimal TotalPrice
    {
        get { return UnitPrice * Quantity; }
    }

}