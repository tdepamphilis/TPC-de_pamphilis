using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        public string name { get; set; }
        public int id { get; set; }
        public int productAmmount { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
