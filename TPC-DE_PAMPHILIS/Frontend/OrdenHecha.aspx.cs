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
    public partial class OrdenHecha : System.Web.UI.Page
    {
        public Carrito carrito;
        private Usuario user;
        public string facturaCode;
        private FacturaBusiness facturaBusiness = new FacturaBusiness();
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = loadChart();
            login();
            facturaCode = getCode();
        }
        private Carrito loadChart()
        {
            if (Session["chart"] == null)
                Session["chart"] = new Carrito();


            Carrito rtn = (Carrito)Session["chart"];
            return rtn;
        }

        private string getCode()
        {
            return facturaBusiness.getLastCode(user.code);
        }
        private void login()
        {
            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            if ((string)Session["usermail"] == null || (string)Session["userpass"] == null)
                Response.Redirect("MainPage.aspx");

            if (usuarioBusiness.CheckAlta((string)Session["usermail"], (string)Session["userpass"]) == 0)
                Response.Redirect("MainPage.aspx");

            user = usuarioBusiness.login((string)Session["usermail"], (string)Session["userpass"]);

        }

    }
}