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
        public FacturaBusiness facturaBusiness = new FacturaBusiness();
        public List<Producto> productos;
        public List<Categoria> categorias;
        public Producto producto;
        public ProductoBusiness productoBusiness = new ProductoBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        public int action;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!login())
                Response.Redirect("MainPage.aspx");
            action = 0;
            loadproducts();
            categorias = categoriaBusiness.listar();
            if (isdel())
                action = 1;
            if (isstock())
                action = 2;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //-------------FUNCIONES DE CARGA--------------

        private bool login()
        {
            AdminBusiness adminBusiness = new AdminBusiness();
            if (Session["adminmail"] == null || Session["adminpass"] == null)
                return false;
            if (adminBusiness.checkAdmin((string)Session["adminmail"], (string)Session["adminpass"]) == 0)
                return false;
            return true;
        }


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

        private bool isstock()
        {
            string code = Request.QueryString["stk"];
            if (code == null)
                return false;
            producto = productoBusiness.buscarid(code);
            return true;

        }
        //-----------------BOTONES---------------------


        protected void TextAmmount_TextChanged(object sender, EventArgs e)
        {

            
        }
    }
}