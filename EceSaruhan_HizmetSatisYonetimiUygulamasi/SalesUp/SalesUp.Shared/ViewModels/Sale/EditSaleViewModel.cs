using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SalesUp.Shared.ViewModels.Sale;

public class EditSaleViewModel
{
    public int Id { get; set; }

    [JsonPropertyName("CreatedDate")]
    [DisplayName("Oluşturulma Tarihi")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [JsonPropertyName("CompletedDate")]
    [DisplayName("Tamamlanma Tarihi")]
    public DateTime CompletedDate { get; set; } = DateTime.Now;

    [JsonPropertyName("CustomerName")]
    [DisplayName("Müşteri")]
    public string CustomerName { get; set; }

    [JsonPropertyName("ProductName")]
    [DisplayName("Ürün")]
    public string ProductName { get; set; }

    [JsonPropertyName("IsCompleted")]
    [DisplayName("Tamamlanmış Satış")]
    public bool IsCompleted { get; set; }

    [JsonPropertyName("Amount")]
    [DisplayName("Ürün Miktarı")]
    public decimal Amount { get; set; }

    [JsonPropertyName("Unit")]
    [DisplayName("Birim")]
    public string Unit { get; set; }

    [JsonPropertyName("UnitPrice")]
    [DisplayName("Birim Fiyat")]
    public decimal UnitPrice { get; set; }

    [JsonPropertyName("UserId")]
    [DisplayName("Kullanıcı Id")]
    public string UserId { get; set; }

    [JsonPropertyName("Note")]
    [DisplayName("Görev Notları")]
    public string Note { get; set; }
}