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
    public partial class TiendaAdmin : System.Web.UI.Page
    {
        public List<Producto> productos;
        public List<Categoria> categorias;
        public Producto producto;
        public ProductoBusiness productoBusiness = new ProductoBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        public int action;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = 0;
            loadproducts();
            categorias = categoriaBusiness.listar();
            if (isdel())
                action = 1;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //-------------FUNCIONES DE CARGA--------------

        private void loadproducts()
        {
            string strcatid = Request.QueryString["cat"];
            if (strcatid == null)
            {
                productos = productoBusiness.listar(TextBox1.Text);
                return;
            }
            int catid;
            int.TryParse(strcatid, out catid);
            productos = productoBusiness.listarxcat(TextBox1.Text, catid);

        }

        private bool isdel()
        {
            string code = Request.QueryString["del"];
            if (code == null)
                return false;
            producto = productoBusiness.buscarid(code);
            return true;

        }

        //-----------------BOTONES---------------------
        protected void Buttondel_Click(object sender, EventArgs e)
        {
            productoBusiness.delete(producto.code);
            productoBusiness.clearcategories(producto.code);
            Response.Redirect("TiendaAdmin.aspx");
        }
    }
}