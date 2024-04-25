using SalesUp.Entity.Identity;
using SalesUp.Shared.ComplexTypes;

namespace SalesUp.Entity;

public class Order
{
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }=DateTime.Now;
    public string UserId { get; set; }
    public User User { get; set; }
    public string RoleId { get; set; }
    public Role Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Note { get; set; }
    public PaymentType PaymentType { get; set; }
    public string PaymentId { get; set; }
    public string ConversationId { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}