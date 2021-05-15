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
    public class ItemsController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public ItemsController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet("listar-itens")]
        public async Task<ActionResult<IEnumerable<Item>>> Getitem()
        {
            return await _context.item.ToListAsync();
        }

    }
}
