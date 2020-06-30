using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Business;
using System.Security.Cryptography.X509Certificates;
using System.EnterpriseServices;

namespace Frontend
{
    public partial class Tienda : System.Web.UI.Page
    {
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        public List<Producto> productos;
        public List<Categoria> categorias;
        public Carrito carrito = new Carrito();
        ProductoBusiness productoBusiness = new ProductoBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

            checkSearch();
            loadproducts();
            categorias = categoriaBusiness.listar();
            if (!IsPostBack)
            {
                Additem();
            }
            carrito = readChart();
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

        private void checkSearch()
        {
            string code = Request.QueryString["search"];
            if (code != null)
            {
                TextBox1.Text = code;
            }
        }


        private Carrito readChart()
        {
            if (Session["chart"] == null)
                Session["chart"] = new Carrito();


            Carrito rtn = (Carrito)Session["chart"];
            return rtn;

        }

        private void Additem()
        {
            var comp = new ItemCarrito();
            try
            {


                string code = (string)Request.QueryString["ART"];
                if (code != null)
                {


                    bool nuevo = true;
                    Carrito aux = (Carrito)Session["chart"];
                    foreach (ItemCarrito item in aux.items)
                    {
                        if (item.code == code)
                        {
                            item.ammount++;
                            nuevo = false;
                        }
                    }
                    if (nuevo)
                    {
                        var auxproduct = productoBusiness.buscarid(code);
                        comp.name = auxproduct.name;
                        comp.code = auxproduct.code;
                        comp.ammount = 1;
                        comp.unitPrice = (float)auxproduct.unitPrice();
                        aux.items.Add(comp);
                    }



                    Session.Remove("chart");
                    Session["chart"] = aux;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        

        public List<Producto> leerFavoritos(List<string> lista)
        {
            List<Producto> productos = new List<Producto>();
            foreach(string code in lista)
            {
                Producto x = new Producto();
                x = productoBusiness.buscarid(code);
                productos.Add(x);
            }
            return productos;
        }

        protected void ButtonFavs_Click(object sender, EventArgs e)
        {
            Usuario usuario = usuarioBusiness.login((string)Session["usermail"], (string)Session["userpass"]);

            productos = leerFavoritos(usuario.favoritos);
        }
    }
}