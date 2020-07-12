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
    public partial class MisCompras : System.Web.UI.Page
    {

        public Carrito carrito;
        private FacturaBusiness facturaBusiness = new FacturaBusiness();
        public List<Factura> facturas = new List<Factura>();
        private Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = loadchart();
            login();
            facturas = facturaBusiness.listarFacturas(usuario.code);

        }


        private Carrito loadchart()
        {
            if (Session["chart"] == null)
            {
                
                return new Carrito();
                
            }
            return (Carrito)Session["chart"];
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
        public string estado(int estado)
        {
            if (estado == 0)
                return "Pendiente";
            else if (estado == 1)
                return "Confirmado";
            else
                return "Entregado";
        }


        



    }
}