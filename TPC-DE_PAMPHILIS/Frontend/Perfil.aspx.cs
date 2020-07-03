using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business;
namespace Frontend
{
    public partial class Perfil : System.Web.UI.Page
    {
        public Carrito carrito;
        public Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            carrito = loadChart();
            login();

        }




        private Carrito loadChart()
        {
            if (Session["chart"] == null)
                Session["chart"] = new Carrito();


            Carrito rtn = (Carrito)Session["chart"];
            return rtn;
        }

        protected void ButtonPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContraseña.aspx");
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


    }
}