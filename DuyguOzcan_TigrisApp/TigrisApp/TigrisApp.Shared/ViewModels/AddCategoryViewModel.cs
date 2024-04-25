using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TigrisApp.Shared.ViewModels
{
    public class AddCategoryViewModel
    {
        [Display(Name ="Kategori Adı")]
        [Required(ErrorMessage = "Lütfen bu alanı boş bırakmayınız.")]
        public string? Name { get; set; }
        [Display(Name ="Kategori Açıklama")]
        [Required(ErrorMessage = "Lütfen bu alanı boş bırakmayınız.")]
        public required string Description { get; set; }
        
    }
}