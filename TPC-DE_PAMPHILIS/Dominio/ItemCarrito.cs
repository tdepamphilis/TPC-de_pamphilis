using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ItemCarrito
    {

        public string name { get; set; }
        public string desc { get; set; }
        public string code{ get; set; }
        public float unitPrice { get; set; }
        public int ammount { get; set; }

        public float partialPrice()
        {
            return ammount * unitPrice;
        }

    }
}
