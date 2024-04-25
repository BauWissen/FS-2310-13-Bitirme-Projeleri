using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TigrisApp.Shared.ViewModels
{
    public class AddSupplierViewModel
    {
        [Display(Name = "Tedarikçi Adı")]
        [Required(ErrorMessage = "Bu alanı boş bırakmayınız")]
        public string Name { get; set; }
        [Display(Name = "Tedarikçi Açıklama")]
        [Required(ErrorMessage = "Bu alanı boş bırakmayınız")]
        public string Description { get; set; }
    }
}