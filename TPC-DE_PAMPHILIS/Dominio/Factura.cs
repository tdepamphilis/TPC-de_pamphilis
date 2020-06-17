using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {

        public string codigo { get; set; }

        public string codigoUsuario { get; set; }

        public DateTime fecha { get; set; }
        public float monto { get; set; }

        public bool estado { get; set; }

        public char modoDePago { get; set; }

        public List<ItemCarrito> items { get; set; }
    }
}
