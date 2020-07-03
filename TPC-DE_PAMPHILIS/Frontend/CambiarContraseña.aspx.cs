using Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Textnew.Text = Textnew.Text.Trim();
            if(Textold.Text != (string)Session["userpass"])
            {
                Label1.Text = "Contraseña incorrecta";
                Label2.Text = "Nueva contraseña";
                Label1.ForeColor = Color.Red;
                Label2.ForeColor = Color.Black;
            }
            else if(Textold.Text == Textnew.Text)
            {
                Label1.Text = "Contraseña";
                Label2.Text = "Está ingresando su contraseña actual";
                Label1.ForeColor = Color.Black;
                Label2.ForeColor = Color.Red;

            } else if(Textnew.Text == "")
            {
                Label1.Text = "Contraseña";
                Label2.Text = "Ingrese una contraseña";
                Label1.ForeColor = Color.Black;
                Label2.ForeColor = Color.Red;
            } else
            {
                usuarioBusiness.cambiarPass((string)Session["usermail"], (string)Session["userpass"], Textnew.Text);
                Session["userpass"] = Textnew.Text;
                Response.Redirect("Perfil.aspx");

            }
                
            
        }
    }
}