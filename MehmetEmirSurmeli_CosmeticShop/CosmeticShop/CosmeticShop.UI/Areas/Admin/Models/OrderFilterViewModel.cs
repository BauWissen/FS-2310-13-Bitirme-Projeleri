using CosmeticShop.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CosmeticShop.UI.Areas.Admin.Models
{
    public class OrderFilterViewModel
    {
        public List<AdminOrderViewModel> Orders { get; set; }
        public List<SelectListItem> ProductListItems { get; set; }
    }
}
