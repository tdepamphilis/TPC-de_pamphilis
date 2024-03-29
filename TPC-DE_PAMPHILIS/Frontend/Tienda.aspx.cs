﻿using System;
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
        private bool showingfavs = false;
        public int page;
        private int productperpage = 4;
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        public List<Producto> productos;
        public List<Producto> productosShow;
        public List<Categoria> categorias;
        public Carrito carrito = new Carrito();
        ProductoBusiness productoBusiness = new ProductoBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {

         //   if (!IsPostBack)
                //  page = 0;

                checkSearch();
            categorias = categoriaBusiness.listar();
            loadproducts();

            if (!IsPostBack)
            {
                Additem();
            }
            loadPage();

            carrito = readChart();
            if (page > productos.Count() / productperpage)
                page = 0;

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
            if (true)
            {
                page = 0;
                Session["page"] = 0;
            }

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
                    page = findProductPage();


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


        private void loadPage()
        {
            productosShow = new List<Producto>();
            if (Session["page"] == null)
            {
                Session["page"] = 0;
                page = 0;
            }
            else
            {
                page = (int)Session["page"];

            }

            int i = page * productperpage;
            for (int x = 0; x < productperpage; x++)
            {
                if (i < productos.Count())
                {
                    productosShow.Add(productos[i]);
                }

                i++;
            }

        }

        private int findProductPage()
        {
            int result = 0;
            int index = 0;
            foreach (Producto item in productos)
            {

                if (Request.QueryString["ART"] == item.code)
                {
                    if (index == 0)
                        return result;
                    return index / productperpage;
                }
                index++;
            }
            return 0;
        }

        public List<Producto> leerFavoritos(List<string> lista)
        {
            List<Producto> productos = new List<Producto>();
            foreach (string code in lista)
            {
                Producto x = new Producto();
                x = productoBusiness.buscarid(code);
                productos.Add(x);
            }
            return productos;
        }

        protected void ButtonFavs_Click(object sender, EventArgs e)
        {
     //       Response.Redirect("VerFavoritos.aspx");
        }

        protected void Buttonnext_Click(object sender, EventArgs e)
        {
            if (page + 1 <= productos.Count / productperpage)
            {
                page++;
                Session["page"] = page;

            }
            loadPage();

        }

        protected void Buttonprev_Click(object sender, EventArgs e)
        {
            if (page > 0)
            {
                page--;
                Session["page"] = page;

            }
            loadPage();
        }
    }
}