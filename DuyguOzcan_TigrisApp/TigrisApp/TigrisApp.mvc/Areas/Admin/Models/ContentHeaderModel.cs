using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigrisApp.mvc.Areas.Admin.Models
{
    public class ContentHeaderModel
    {
        public string PageTitle { get; set; }
        public string ControllerName { get; set; }
        public string ButtonText { get; set; }
    }
}