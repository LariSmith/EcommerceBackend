using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Model
{
    public class Item
    {
        public int id { get; set; }
        public Pedido pedido { get; set; }
        public Produto Produto { get; set; }
        public int quantidade { get; set; }
    }
}
