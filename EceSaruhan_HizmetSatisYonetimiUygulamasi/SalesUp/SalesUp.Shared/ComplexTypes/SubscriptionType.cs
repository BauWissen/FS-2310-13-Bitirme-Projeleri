using System.ComponentModel.DataAnnotations;

namespace SalesUp.Shared.ComplexTypes;

public enum SubscriptionType
{
    [Display(Name = "6 Aylık")]
    Monthly=0,
    
    [Display(Name = "Yıllık")]
    Year=1,
    
    [Display(Name = "2 Yıllık")]
    TwoYears=2
}