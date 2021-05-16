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
using Microsoft.Data.SqlClient;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public PedidosController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet("listar-pedidos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> Getpedido()
        {
            return await _context.pedido.ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("listar-pedidos/{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.pedido.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // POST: api/Pedidos
        [HttpPost("cadastrar-pedido")]
        public async Task<ActionResult<Pedido>> PostPedido(PedidoViewModel pedido)
        {
            _context.cliente.Add(pedido.cliente);
            await _context.SaveChangesAsync();

            var cliente = _context.cliente.OrderByDescending(c => c.id).FirstOrDefault();

            Pedido Pedido = new Pedido();

            Pedido.clienteId = cliente.id;
            Pedido.dataPedido = DateTime.Now.ToString();
            _context.pedido.Add(Pedido);
            await _context.SaveChangesAsync();

            var p = _context.pedido.OrderByDescending(x => x.id).FirstOrDefault();

            foreach (ItemViewModel elemento in pedido.itens)
            {
                Item item = new Item();

                var estoque = elemento.produto.estoque - elemento.quantidade;

                if (estoque < 0)
                {
                    return NotFound();
                }

                elemento.produto.estoque = estoque;

                item.produtoId = elemento.produto.id;
                item.pedidoId = p.id;
                item.quantidade = elemento.quantidade;

                _context.Update(elemento.produto);

                _context.item.Add(item);

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetPedido", new { id = Pedido.id }, Pedido);
        }

    }
}
