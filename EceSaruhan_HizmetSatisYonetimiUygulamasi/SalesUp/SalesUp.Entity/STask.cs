using SalesUp.Entity.Identity;
using SalesUp.Shared.ComplexTypes;

namespace SalesUp.Entity;

public class STask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }=DateTime.Now;
    public DateTime ModifiedDate { get; set; }=DateTime.Now;
    public string UserId { get; set; }
    public User User { get; set; }

    public string CustomerName { get; set; }
    public string ProductName { get; set; }
    public bool IsCompleted { get; set; }
    public string Note { get; set; }
}