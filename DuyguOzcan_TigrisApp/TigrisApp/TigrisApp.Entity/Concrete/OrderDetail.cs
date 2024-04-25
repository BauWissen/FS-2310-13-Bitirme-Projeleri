using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigrisApp.Entity.Concrete
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}