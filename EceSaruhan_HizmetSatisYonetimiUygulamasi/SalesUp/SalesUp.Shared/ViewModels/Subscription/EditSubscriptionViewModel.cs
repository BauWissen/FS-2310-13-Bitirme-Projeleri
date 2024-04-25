using System.ComponentModel;
using Newtonsoft.Json;
using SalesUp.Shared.ComplexTypes;

namespace SalesUp.Shared.ViewModels.Subscription;

public class EditSubscriptionViewModel
{
    public int Id { get; set; }
    
    [JsonProperty("Name")]
    [DisplayName("Abonelik")]
    public string Name { get; set; }
    
    [JsonProperty("Description")]
    [DisplayName("Abonelik Açıklaması")]
    public string Description { get; set; }
    
    [JsonProperty("Price")]
    [DisplayName("Birim Fiyat")]
    public decimal Price { get; set; }
    
    [JsonProperty("Duration")]
    [DisplayName("Abonelik Süresi")]
    public int Duration { get; set; }
    
    [JsonProperty("DurationUnit")]
    [DisplayName("Abonelik Birimi")]
    public string DurationUnit { get; set; }
    
    [JsonProperty("SubscriptionType")]
    [DisplayName("Abonelik Türü")]
    public SubscriptionType SubscriptionType { get; set; }
}