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

        public FacturaBusiness facturaBusiness = new FacturaBusiness();
        public List<Categoria> categorias;
        public Producto producto;
        public ProductoBusiness productoBusiness = new ProductoBusiness();
        public CategoriaBusiness CategoriaBusiness = new CategoriaBusiness();
        public StockBusiness stockBusiness = new StockBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Session["PreviousPageUrl"] = Request.UrlReferrer.ToString();
            loadCategories();
            loadProduct();

            if (!IsPostBack)
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
            Response.Redirect("TiendaAdmin.aspx?search=" + TextBox1.Text);
        }

        protected void ButtonStock_Click(object sender, EventArgs e)
        {
            if (TextPrice.Text != "" && TextAmmount.Text != "")
            {
                StockBusiness stockBusiness = new StockBusiness();
                int newammount = producto.stock.ammount + int.Parse(TextAmmount.Text);
                decimal newprice = Decimal.Parse(TextPrice.Text);
                stockBusiness.updatestock(producto.code, newammount, newprice);
                Response.Redirect("VerProductoAdmin.aspx?prod=" + producto.code);
            }
        }

        protected void ButtonDel_Click(object sender, EventArgs e)
        {
            productoBusiness.delete(producto.code);
            productoBusiness.clearcategories(producto.code);
            stockBusiness.deleteData(producto.code);
            Response.Redirect("TiendaAdmin.aspx");


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["PreviousPageUrl"]);
        }
    }
}