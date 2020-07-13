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
    public partial class DetalleUsuariosAdmin : System.Web.UI.Page
    {

        public List<Usuario> usuarios;
        public UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            usuarios = usuarioBusiness.listar();
        }
    }
}