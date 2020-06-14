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
    public partial class Categorias : System.Web.UI.Page
    {
        public CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        public List<Categoria> categorias;
        public int action = 0;
        public Categoria selected;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadcards();
            if (isrenaming())
                action = 1;
            else if (isdelete())
                action = 2;


        }

        private void loadcards()
        {
            categorias = categoriaBusiness.buscar(TextSearch.Text);
        }

        private bool isrenaming()
        {
            string code = (string)Request.QueryString["rnm"];
            if (code == null)
                return false;
            selected = categoriaBusiness.buscarid(int.Parse(code));
            return true;

        }

        private bool isdelete()
        {
            string code = (string)Request.QueryString["del"];
            if (code == null)
                return false;
            selected = categoriaBusiness.buscarid(int.Parse(code));
            return true;
        }
        protected void Confirmar_Click(object sender, EventArgs e)
        {
            if(TextRename.Text != "")
            {
                categoriaBusiness.rename(selected.id, TextRename.Text);
                Response.Redirect("Categorias.aspx");
            }
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            categoriaBusiness.delete(selected.id);
            Response.Redirect("Categorias.aspx");
        }
    }
}