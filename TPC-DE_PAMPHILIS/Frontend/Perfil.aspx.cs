using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class Perfil : System.Web.UI.Page
    {
        public Carrito carrito;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            carrito = loadChart();

        }

        private Carrito loadChart()
        {
            if (Session["chart"] == null)
                Session["chart"] = new Carrito();


            Carrito rtn = (Carrito)Session["chart"];
            return rtn;
        }
    }
}