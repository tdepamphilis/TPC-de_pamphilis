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

        public string dir { get; set; }

        public string ApellidoNombre { get; set; }

        public bool pago { get; set; }
        public int estadoEntrega { get; set; }
        public Factura()
        {
            dir = "none";
            items = new List<ItemCarrito>();
        }
        
        public float totalPrice()
        {
            float total = 0;
            foreach (ItemCarrito item in items)
            {
                total += item.partialPrice();
            }
            return total;
        }
    }
}
