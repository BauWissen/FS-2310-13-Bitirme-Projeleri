using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigrisApp.Shared.ViewModels
{
    public class CategoryViewModel
    {
        public string? Name { get; set; }
        public required string Description { get; set; }
        public  int Id { get; set; }
    }
}