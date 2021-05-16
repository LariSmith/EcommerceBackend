using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Service.Data.Context;
using Ecommerce.Service.Model;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public ProdutosController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet("listar-produtos")]
        public async Task<ActionResult<IEnumerable<Produto>>> Getproduto()
        {
            return await _context.produto.ToListAsync();
        }

        [HttpPost("cadastrar-produto")]
        public async Task<ActionResult<Pedido>> PostProduto(Produto produto)
        {
            _context.produto.Add(produto);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproduto", produto);
        }

    }
}
