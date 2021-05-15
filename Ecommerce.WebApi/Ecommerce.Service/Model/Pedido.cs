using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Model
{
    public class Pedido
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public Cliente cliente { get; set; }
        public DateTime dataPedido { get; set; }
    }
}
