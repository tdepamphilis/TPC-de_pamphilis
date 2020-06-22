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
    public partial class MainPage : System.Web.UI.Page
    {

        private AdminBusiness adminBusiness = new AdminBusiness();
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (adminBusiness.checkAdmin(TextUser.Text, TextPass.Text) != 0)
            {
                Admin admin = new Admin();
                admin = adminBusiness.login(TextUser.Text, TextPass.Text);
                Response.Redirect("TiendaAdmin.aspx");
            }
            else if (usuarioBusiness.CheckAlta(TextUser.Text, TextPass.Text) != 0)
            {
                Usuario usuario = new Usuario();
                usuario = usuarioBusiness.login(TextUser.Text, TextPass.Text);
                Response.Redirect("Tienda.aspx");
            }
            else
            {
                Response.Redirect("MainPage.aspx?error=404");
            }

        }
    }
}