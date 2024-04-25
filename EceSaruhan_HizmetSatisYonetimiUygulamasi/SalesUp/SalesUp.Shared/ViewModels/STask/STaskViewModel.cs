using System.Reflection.Metadata;
using SalesUp.Shared.ViewModels.Customer;
using SalesUp.Shared.ViewModels.IdentityModels;
using SalesUp.Shared.ViewModels.Product;

namespace SalesUp.Shared.ViewModels.STask;

public class STaskViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }=DateTime.Now;
    public DateTime ModifiedDate { get; set; }=DateTime.Now;
    public string CustomerName { get; set; }
    public string ProductName { get; set; }
    public bool IsCompleted { get; set; }
    public string Note { get; set; }
    public string UserId { get; set; }
}