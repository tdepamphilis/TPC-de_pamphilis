using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Business;

namespace Frontend
{
    public partial class Tienda : System.Web.UI.Page
    {
        public List<Producto> productos;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoBusiness productoBusiness = new ProductoBusiness();
            productos = productoBusiness.listar("");
        }
    }
}