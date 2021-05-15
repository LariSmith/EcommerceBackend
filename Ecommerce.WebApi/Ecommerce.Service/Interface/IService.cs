using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Service.Interface
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> Listar();
    }
}
