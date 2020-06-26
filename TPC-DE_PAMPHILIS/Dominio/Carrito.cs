using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
     public class Carrito
    {
        public List<ItemCarrito> items { get; set; }

        

        public Carrito()
        {
            items = new List<ItemCarrito>();
        }
        public float totalPrice()
        {
            float total = 0;
            foreach(ItemCarrito item in items)
            {
                total += item.partialPrice();
            }
            return total;
        }

        public Factura GenerarFactura()
        {
            Factura nueva = new Factura();
            nueva.items = items;
            nueva.monto = totalPrice();
            nueva.estado = true;
        
            nueva.fecha = new DateTime(2005, 5, 5);
                       
            return nueva;
        }

    }
}
