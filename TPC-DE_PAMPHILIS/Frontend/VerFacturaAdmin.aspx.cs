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
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!login())
                Response.Redirect("MainPage.aspx");
            loadFactura();
            loadbuttons();
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

        private void loadbuttons()
        {
            if (factura.estadoEntrega == 0)
            {
                ButtonDown.Visible = false;
                ButtonUp.Text = "Confirmar";
            }
            if (factura.estadoEntrega == 2)
            {
                ButtonUp.Visible = false;
                ButtonDown.Text = "Marcar como no enviada";
            }
            if (factura.estadoEntrega == 1)
            {
                ButtonDown.Text = "Marcar como no confirmada";
                ButtonUp.Text = "Marcar como enviada";
            }
        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerFacturaAdmin.aspx");
        }

        protected void Buttondel_Click(object sender, EventArgs e)
        {
            facturaBusiness.anularFactura(factura.codigo);
            if (factura.pago == true)
                usuarioBusiness.creditTransaction(factura.monto, factura.codigoUsuario);
            Response.Redirect("FacturacionAdmin.aspx");
        }

        protected void ButtonDown_Click(object sender, EventArgs e)
        {
            facturaBusiness.downEnvio(factura.codigo);
            if (factura.estadoEntrega == 0)
                Response.Redirect("GestionPendientes.aspx");
            else if (factura.estadoEntrega == 1)
                Response.Redirect("FacturacionAdmin.aspx");
            else if (factura.estadoEntrega == 2)
                Response.Redirect("FacturasEnviadas.aspx");
        }

        protected void ButtonUp_Click(object sender, EventArgs e)
        {
            facturaBusiness.upEnvio(factura.codigo);
            if (factura.estadoEntrega == 0)
                Response.Redirect("GestionPendientes.aspx");
            else if (factura.estadoEntrega == 1)
                Response.Redirect("FacturacionAdmin.aspx");
            else if (factura.estadoEntrega == 2)
                Response.Redirect("FacturasEnviadas.aspx");
        }


    }
}