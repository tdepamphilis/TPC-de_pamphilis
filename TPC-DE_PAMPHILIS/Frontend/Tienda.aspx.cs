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
    public partial class Tienda : System.Web.UI.Page
    {
        public List<Producto> productos;
        public List<Categoria> categorias;
        public Carrito carrito = new Carrito();
        ProductoBusiness productoBusiness = new ProductoBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

            loadproducts();
            categorias = categoriaBusiness.listar();
            if(!IsPostBack)
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
    }
}