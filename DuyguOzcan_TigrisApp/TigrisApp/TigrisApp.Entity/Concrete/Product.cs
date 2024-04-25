using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Entity.Abstract;

namespace TigrisApp.Entity.Concrete
{
    public class Product : BaseEntity, IBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ColourId { get; set; }
        public Colour Colour { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool IsActive { get; set; }
        public List<ProductGender> ProductGenders { get; set; }
    }
}