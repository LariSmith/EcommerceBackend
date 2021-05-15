using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Service.Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ObterQueryEntidade();
    }
}
