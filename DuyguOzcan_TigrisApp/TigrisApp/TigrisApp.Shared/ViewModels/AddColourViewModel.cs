using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TigrisApp.Shared.ViewModels
{
    public class AddColourViewModel
    {
        [Display(Name = "Renk")]
        [Required(ErrorMessage = "Bu alanı boş bırakmayınız")]
        public string Name { get; set; }
    }
}