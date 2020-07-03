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
        public bool isfavorite = false;
        public bool islogged = false;
        private Usuario usuario;
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                Session["PreviousPageUrl"] = Request.UrlReferrer.ToString();
            checklogged();
            carrito = readchart();
            categorias = categoriaBusiness.listar();
            readproduct();
            if (islogged == true)
                isfavorite = checkFav();

            if (!IsPostBack)
            {
                TextCuantity.Text = "1";
            }

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

        private bool checkFav()
        {
            bool check = false;
            usuario = usuarioBusiness.login((string)Session["usermail"], (string)Session["userpass"]);
            foreach (string code in usuario.favoritos)
            {
                if (code == producto.code)
                    check = true;
            }
            return check;
        }

        private void checklogged()
        {

            if (Session["usermail"] != null && Session["userpass"] != null)
            {
                if (usuarioBusiness.CheckAlta((string)Session["usermail"], (string)Session["userpass"]) != 0)
                    islogged = true;
                else
                    islogged = false;

            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect("Tienda.aspx?search=" + TextBox1.Text);
        }

        protected void Buttonup_Click(object sender, EventArgs e)
        {
            int number = 0;
            if (int.TryParse(TextCuantity.Text, out number))
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
                number += 10;
                TextCuantity.Text = number.ToString();

            }


        }

        protected void ButtonDown_Click(object sender, EventArgs e)
        {
            int number = 0;
            if (int.TryParse(TextCuantity.Text, out number))
            {
                number--;
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

        protected void ButtonRemoveFav_Click(object sender, ImageClickEventArgs e)
        {
            usuario = usuarioBusiness.login((string)Session["usermail"], (string)Session["userpass"]);
            usuarioBusiness.removeFav(producto.code, usuario.code);
            isfavorite = checkFav();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            usuario = usuarioBusiness.login((string)Session["usermail"], (string)Session["userpass"]);
            usuarioBusiness.addFav(producto.code, usuario.code);
            isfavorite = checkFav();
        }

        protected void ButtonAddChart_Click(object sender, EventArgs e)
        {
            var comp = new ItemCarrito();
            try
            {
                bool nuevo = true;
                Carrito aux = (Carrito)Session["chart"];
                foreach (ItemCarrito item in aux.items)
                {
                    if (item.code == producto.code)
                    {
                        item.ammount += int.Parse(TextCuantity.Text);
                        nuevo = false;
                    }
                }
                if (nuevo)
                {
                    var auxproduct = productoBusiness.buscarid(producto.code);
                    comp.name = auxproduct.name;
                    comp.code = auxproduct.code;
                    comp.ammount = int.Parse(TextCuantity.Text);
                    comp.unitPrice = (float)auxproduct.unitPrice();
                    aux.items.Add(comp);
                }



                Session.Remove("chart");
                Session["chart"] = aux;


            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)Session["PreviousPageUrl"]);
        }
    }
}