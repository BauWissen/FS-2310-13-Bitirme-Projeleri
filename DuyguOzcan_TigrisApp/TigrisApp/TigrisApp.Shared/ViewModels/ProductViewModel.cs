using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigrisApp.Shared.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? Name { get; set; }
        public int ColourId { get; set; }
        public ColourViewModel Colour { get; set; }
        public int MaterialId { get; set; }
        public MaterialViewModel Material { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public int SupplierId { get; set; }
        public SupplierViewModel Supplier { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool IsActive { get; set; }
        public List<GenderViewModel> Genders { get; set; }
    }
}