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
    public partial class AltaUsuario : System.Web.UI.Page
    {
        public UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        public ZonaBusiness zonaBusiness = new ZonaBusiness();
        public List<Zona> zonas;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                loadZones();
                checkError();

            }
        }

        public void loadZones()
        {
            DropDownZonas.Items.Clear();
            zonas = zonaBusiness.listar();
            ListItem first = new ListItem("Seleccionar zona", "-1");
            DropDownZonas.Items.Add(first);
            foreach (Zona zona in zonas)
            {

                ListItem item = new ListItem(zona.name, zona.id.ToString());
                DropDownZonas.Items.Add(item);

            }
        }

        private void checkError()
        {
            string code = Request.QueryString["error"];
            if (code == "mail")
            {
                LabelCorreo.Text = "Correo ya registrado";
                LabelCorreo.Attributes.Add("style", "color:red");
            }
        }
        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            if (true)
            {
                Usuario usuario = new Usuario();
                Zona zona = new Zona();
                usuario.name = TextName.Text;
                usuario.apellido = TextApellido.Text;
                if (usuarioBusiness.checkMail(TextMail.Text) != 0)
                    Response.Redirect("AltaUsuario.aspx?error=mail");
                usuario.mail = TextMail.Text;
                usuario.pass = TextPass.Text;
                zona.id = int.Parse(DropDownZonas.SelectedValue);
                usuario.zona = zona;
                usuario.tel = int.Parse(TextTel.Text);
                usuario.code = usuarioBusiness.generateCode();
                usuario.direccion = TextDir.Text;
                usuarioBusiness.nuevoUsuario(usuario);
                if (usuarioBusiness.CheckAlta(usuario.mail, usuario.pass) == 0)
                    Response.Redirect("AltaUsuario.aspx?error=server");
                Session["userCode"] = usuario.code;
                Session["userPass"] = usuario.pass;
                Response.Redirect("Tienda.aspx");
            }


        }
    }
}