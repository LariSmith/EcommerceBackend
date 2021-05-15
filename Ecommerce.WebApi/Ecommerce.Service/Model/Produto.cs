using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Model
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string preco { get; set; }
        public string descricao { get; set; }
    }
}
