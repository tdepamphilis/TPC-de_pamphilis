using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string code { get; set; }
        public string name { get; set; }
        public string apellido { get; set; }

        public string mail { get; set; }
        public string pass { get; set; }
        public string direccion { get; set; }


        public int dni { get; set; }
        public int tel { get; set; }

        public Zona zona { get; set; }

        public List<string> favoritos { get; set; }

        public decimal credito { get; set; }


    }
}
