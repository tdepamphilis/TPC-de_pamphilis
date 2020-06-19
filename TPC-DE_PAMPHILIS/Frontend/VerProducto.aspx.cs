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
    public partial class VerProducto : System.Web.UI.Page
    {
        ProductoBusiness productoBusiness = new ProductoBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        public List<Categoria> categorias;
        public Producto producto;
        public Carrito carrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                carrito = readchart();
                categorias = categoriaBusiness.listar();
            
            if (!IsPostBack)
            {
                TextCuantity.Text = "1";
            }
                readproduct();

        }

        private Carrito readchart()
        {
            if (Session["chart"] == null)
                Session["chart"] = new Carrito();


            Carrito rtn = (Carrito)Session["chart"];
            return rtn;

        }

        private void readproduct()
        {
            string code = Request.QueryString["prod"];
            if (code == null)
                Response.Redirect("Tienda.aspx");
            producto = productoBusiness.buscarid(code);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect("Tienda.aspx?search=" + TextBox1.Text);
        }

        protected void Buttonup_Click(object sender, EventArgs e)
        {
            int number = 0;
            if (int.TryParse(TextCuantity.Text,out  number))
            {
                number++;
                TextCuantity.Text = number.ToString();

            }


        }

        protected void ButtonUpTen_Click(object sender, EventArgs e)
        {
            int number = 0;
            if (int.TryParse(TextCuantity.Text, out number))
            {
                number+= 10;
                TextCuantity.Text = number.ToString();

            }


        }

        protected void ButtonDown_Click(object sender, EventArgs e)
        {
            int number = 0;
            if (int.TryParse(TextCuantity.Text, out number))
            {
                number --;
                TextCuantity.Text = number.ToString();

            }

        }

        protected void ButtonDownTen_Click(object sender, EventArgs e)
        {
            int number = 0;
            if (int.TryParse(TextCuantity.Text, out number))
            {
                number -= 10;
                TextCuantity.Text = number.ToString();

            }

        }
    }
}