using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Service.Interface;
using Ecommerce.Service.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IService<Produto> service;

        public ProdutosController(IService<Produto> service)
        {
            this.service = service;
        }

        public IEnumerable<Produto> ListarProdutos()
        {
            return service.Listar();
        }
    }
}
