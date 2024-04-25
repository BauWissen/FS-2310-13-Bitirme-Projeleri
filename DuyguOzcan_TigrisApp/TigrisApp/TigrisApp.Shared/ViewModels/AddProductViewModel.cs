using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TigrisApp.Shared.ViewModels
{
    public class AddProductViewModel
    {
        [DisplayName("Ürün İsmi")]
        [Required(ErrorMessage = "Bu alanı boş bırakmayınız")]
        public string? Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        [Required(ErrorMessage ="Bu alanı boş bırakmayınız")]
        public string? Description { get; set; }
        [DisplayName("Renk")]
        public int ColourId { get; set; }
        [DisplayName("Malzeme")]
        public int MaterialId { get; set; }
        [DisplayName("Kategori")]
        public int CategoryId { get; set; }
        [DisplayName("Tedarikçi")]
        public int SupplierId { get; set; }
        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Bu alanı boş bırakmayınız")]
        public decimal Price { get; set; }
        [DisplayName("Stok")]
        [Required(ErrorMessage = "Bu alanı boş bırakmayınız")]
        public int Amount { get; set; }
        [DisplayName("Aktif Ürün")]
        public bool IsActive { get; set; }
        [DisplayName("Cinsiyet")]
        public List<int> GenderIds { get; set; } = new();


        
        public List<SelectListItem> ColourList { get; set; } = new();
        public List<SelectListItem> MaterialList { get; set; } = new();
        public List<SelectListItem> CategoryList { get; set; } = new();
        public List<SelectListItem> SupplierList { get; set; } = new();
        public List<SelectListItem> GenderList { get; set; } = new();

    }
}