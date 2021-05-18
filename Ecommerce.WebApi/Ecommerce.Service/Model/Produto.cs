using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Model
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public float preco { get; set; }
        public string descricao { get; set; }
        public int estoque { get; set; }
    }
}
