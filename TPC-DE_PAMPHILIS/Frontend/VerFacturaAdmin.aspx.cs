using Business;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class VerFacturaAdmin : System.Web.UI.Page
    {

        public Factura factura = new Factura();
        private FacturaBusiness facturaBusiness = new FacturaBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            loadFactura();
        }

        private void loadFactura()
        {
            string code = Request.QueryString["fac"];
            if (code == null)
                Response.Redirect("FacturacionAdmin.aspx");
            factura = facturaBusiness.buscarId(code);
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerFacturaAdmin.aspx");
        }

        protected void Buttondel_Click(object sender, EventArgs e)
        {
            facturaBusiness.anularFactura(factura.codigo);
            Response.Redirect("FacturacionAdmin.aspx");
        }
    }
}