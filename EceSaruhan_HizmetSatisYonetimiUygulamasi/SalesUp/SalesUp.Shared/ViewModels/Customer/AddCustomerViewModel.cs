using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SalesUp.Shared.ViewModels.Customer;

public class AddCustomerViewModel
{

    [JsonPropertyName("FirstName")]
    [DisplayName("İsim")]
    public string FirstName { get; set; }


    [JsonPropertyName("LastName")]
    [DisplayName("Soyisim")]
    public string LastName { get; set; }


    [JsonPropertyName("CompanyName")]
    [DisplayName("Şirket")]
    public string? CompanyName { get; set; }


    [JsonPropertyName("Title")]
    [DisplayName("Unvan")]
    public string? Title { get; set; }


    [JsonPropertyName("Email")]
    [DisplayName("E-mail")]
    public string Email { get; set; }


    [JsonPropertyName("PhoneNumber")]
    [DisplayName("Telefon Numarası")]
    public string PhoneNumber { get; set; }


    [JsonPropertyName("Address")]
    [DisplayName("Adres")]
    public string Address { get; set; }


    [JsonPropertyName("CreatedDate")]
    [DisplayName("Oluşturulma Tarihi")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;


    [JsonPropertyName("ModifiedDate")]
    [DisplayName("Güncellenme Tarihi")]
    public DateTime ModifiedDate { get; set; } = DateTime.Now;


    [JsonPropertyName("UserId")]
    [DisplayName("Kullanıcı Id")]
    public string UserId { get; set; }
}