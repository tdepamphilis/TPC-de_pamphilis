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
    public partial class VerProductoAdmin : System.Web.UI.Page
    {

        public List<Categoria> categorias;
        public Producto producto;
        public ProductoBusiness productoBusiness = new ProductoBusiness();
        public CategoriaBusiness CategoriaBusiness = new CategoriaBusiness();
        public StockBusiness stockBusiness = new StockBusiness();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
                loadCategories();
                loadProduct();    
            
            if(!IsPostBack)
            {
            }
            
        }

        private void loadCategories()
        {
            categorias = CategoriaBusiness.listar(); 
        }

        private void loadProduct()
        {
            string code = Request.QueryString["prod"];
            if (code == null)
                Response.Redirect("TiendaAdmin");
            producto = productoBusiness.buscarid(code);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonStock_Click(object sender, EventArgs e)
        {
            TextAmmount.Text = TextPrice.Text;
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            productoBusiness.delete(producto.code);
            productoBusiness.clearcategories(producto.code);
            stockBusiness.deleteData(producto.code);
            Response.Redirect("TiendaAdmin.aspx");

            
        }
    }
}