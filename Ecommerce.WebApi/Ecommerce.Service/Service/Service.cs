using Ecommerce.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Service.Service
{
    public class Service<T> : IService<T> where T : class
    {

        private IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> Listar()
        {
            var query = repository.ObterQueryEntidade();

            var lista = (from d in query select d).AsNoTracking().ToList();

            return lista;
        }
    }
}
