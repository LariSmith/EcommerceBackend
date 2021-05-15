﻿using System;
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

    }
}
