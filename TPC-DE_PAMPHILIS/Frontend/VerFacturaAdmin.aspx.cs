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
        public FacturaBusiness facturaBusiness = new FacturaBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!login())
                Response.Redirect("MainPage.aspx");
            loadFactura();
        }

        private bool login()
        {
            AdminBusiness adminBusiness = new AdminBusiness();
            if (Session["adminmail"] == null || Session["adminpass"] == null)
                return false;
            if (adminBusiness.checkAdmin((string)Session["adminmail"], (string)Session["adminpass"]) == 0)
                return false;
            return true;
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