using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SalesUp.Shared.ViewModels.Product;

public class EditProductViewModel
{
    public int Id { get; set; }


    [JsonPropertyName("IsActive")]
    [DisplayName("Aktiflik Durumu")]
    public bool IsActive { get; set; }

    [JsonPropertyName("CreatedDate")]
    [DisplayName("Oluşturulma Tarihi")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [JsonPropertyName("ModifiedDate")]
    [DisplayName("Güncellenme Tarihi")]
    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    [JsonPropertyName("Name")]
    [DisplayName("Ürün")]
    public string Name { get; set; }

    [JsonPropertyName("Properties")]
    [DisplayName("Ürün Özellikleri")]
    public string Properties { get; set; }

    [JsonPropertyName("UnitPrice")]
    [DisplayName("Birim Fiyatı")]
    public decimal UnitPrice { get; set; }

    [JsonPropertyName("Quantity")]
    [DisplayName("Miktar")]
    public decimal Quantity { get; set; }

    [JsonPropertyName("Unit")]
    [DisplayName("Birim")]
    public string Unit { get; set; }

    [JsonPropertyName("UserId")]
    [DisplayName("Kullanıcı Id")]
    public string UserId { get; set; }
}