using Ecommerce.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.ViewModel
{
    public class PedidoViewModel
    {
        public Cliente cliente { get; set; }
        public List<ItemViewModel> itens { get; set; }
    }
}
