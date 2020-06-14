using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public string code { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string urlimagen { get; set; }
        public int margin { get; set; }
        public Marca marca { get; set; }
        
        public List<Categoria> categorias { get; set; }


    }
}
