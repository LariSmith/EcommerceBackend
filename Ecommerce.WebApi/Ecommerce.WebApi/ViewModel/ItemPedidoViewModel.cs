using Ecommerce.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.ViewModel
{
    public class ItemPedidoViewModel
    {
        public Pedido pedido { get; set; }
        public List<ItemViewModel> itens { get; set; }
    }
}
