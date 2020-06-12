﻿using System;
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
        ProductoBusiness productoBusiness = new ProductoBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {

            loadproducts();
            categorias = categoriaBusiness.listar();
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
    }
}