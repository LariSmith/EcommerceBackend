using Ecommerce.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.ViewModel
{
    public class ItemViewModel
    {
        public Produto produto { get; set; }
        public int quantidade { get; set; }
    }
}
