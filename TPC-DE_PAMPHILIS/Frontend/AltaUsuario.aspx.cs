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
        public ZonaBusiness zonaBusiness = new ZonaBusiness();
        public List<Zona> zonas;
        protected void Page_Load(object sender, EventArgs e)
        {

            zonas = zonaBusiness.listar();
            DropDownZonas.DataSource = zonas;
            DropDownZonas.DataBind();
            if(!IsPostBack)
            {

            }    
        }
    }
}