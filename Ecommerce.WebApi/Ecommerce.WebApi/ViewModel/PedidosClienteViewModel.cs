using Ecommerce.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.ViewModel
{
    public class PedidosClienteViewModel
    {
        public string dataPedido { get; set; }
        public Cliente cliente { get; set; }
        public Produto produto { get; set; }
        public int quantidade { get; set; }
    }
}
