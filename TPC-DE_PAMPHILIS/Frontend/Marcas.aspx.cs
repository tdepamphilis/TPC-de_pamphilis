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
    public partial class Marcas : System.Web.UI.Page
    {
        public MarcaBusiness marcaBusiness = new MarcaBusiness();
        public List<Marca> marcas;
        protected void Page_Load(object sender, EventArgs e)
        {
            fillcards();
        }
        private void fillcards()
        {
            marcas = marcaBusiness.buscar(TextSearch.Text);
        }
    }
}