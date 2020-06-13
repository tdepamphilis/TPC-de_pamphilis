using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Business;
namespace Frontend
{
    public partial class Categorias : System.Web.UI.Page
    {
        public CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        public List<Categoria> categorias;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadcards();
        }

        private void loadcards()
        {
            categorias = categoriaBusiness.buscar(TextSearch.Text);
        }
    }
}