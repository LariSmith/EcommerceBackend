using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Service.Data.Context;
using Ecommerce.Service.Model;
using Ecommerce.WebApi.ViewModel;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public ClientesController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet("listar-cliente")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            return await _context.cliente.ToListAsync();
        }

        [HttpGet("lista-compras-cliente")]
        public async Task<ItemPedidoViewModel> GetComprasCliente(int idCliente)
        {
            var itensPedidos = await _context.produto
                .Join(
                    _context.item,
                    produto => produto.id,
                    item => item.produtoId,
                    (produto, item) => new { produto, item }
                    )
                .Join(
                    _context.pedido,
                    combineEntry => combineEntry.item.pedidoId,
                    pedido => pedido.id,
                    (combineEntry, pedido) => new { combineEntry, pedido }
                    )
                .Join(
                    _context.cliente,
                    combineEntry_2 => combineEntry_2.pedido.clienteId,
                    cliente => cliente.id,
                    (combineEntry_2, cliente) => new PedidosClienteViewModel
                    {
                        cliente = cliente,
                        dataPedido = combineEntry_2.pedido.dataPedido,
                        produto = combineEntry_2.combineEntry.produto,
                        quantidade = combineEntry_2.combineEntry.item.quantidade
                    }
                ).Where(x => x.cliente.id == idCliente).ToListAsync();

            ItemPedidoViewModel pedido = new ItemPedidoViewModel();
            pedido.pedido = new Pedido();
            pedido.itens = new List<ItemViewModel>();

            pedido.pedido.cliente = itensPedidos.Select(x => x.cliente).FirstOrDefault();
            pedido.pedido.dataPedido = itensPedidos.Select(x => x.dataPedido).FirstOrDefault();
            foreach (PedidosClienteViewModel item in itensPedidos)
            {
                ItemViewModel itemViewModel = new ItemViewModel();
                itemViewModel.produto = item.produto;
                itemViewModel.quantidade = item.quantidade;

                pedido.itens.Add(itemViewModel);
            }

            return pedido;
        }

    }
}
