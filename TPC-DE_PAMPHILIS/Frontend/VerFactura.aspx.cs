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
    public partial class VerFactura : System.Web.UI.Page
    {

        public Carrito carrito;
        public Factura factura = new Factura();
        private FacturaBusiness facturaBusiness = new FacturaBusiness();
        private Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = loadchart();
            login();
            loadfactura();
        }

        private Carrito loadchart()
        {
            if (Session["chart"] == null)
            {

                return new Carrito();
                
            }
            return (Carrito)Session["chart"];
        }

        private void loadfactura()
        {
            string code = Request.QueryString["fac"];
            if (code == null)
                Response.Redirect("MisCompras");
            factura = facturaBusiness.buscarId(code);
            if (factura.codigoUsuario != usuario.code)
                Response.Redirect("MainPage.aspx");
        }

        private void login()
        {
            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            if ((string)Session["usermail"] == null || (string)Session["userpass"] == null)
                Response.Redirect("MainPage.aspx");

            if (usuarioBusiness.CheckAlta((string)Session["usermail"], (string)Session["userpass"]) == 0)
                Response.Redirect("MainPage.aspx");

            usuario = usuarioBusiness.login((string)Session["usermail"], (string)Session["userpass"]);

        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {

        }
    }
}