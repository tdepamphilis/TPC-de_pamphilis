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
    public partial class GestionPendientes : System.Web.UI.Page
    {

        public FacturaBusiness facturaBusiness = new FacturaBusiness();
        public List<Factura> facturas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!login())
                Response.Redirect("MainPage.aspx");
            facturas = facturaBusiness.listarPendientesCode("");

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

        public string stringPago(Factura factura)
        {
            if (factura.pago)
                return "pago";
            else
                return "no pago";
        }
            


    }
}