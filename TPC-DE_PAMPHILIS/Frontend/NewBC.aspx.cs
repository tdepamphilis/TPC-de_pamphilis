﻿using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class NewBC : System.Web.UI.Page
    {
        public FacturaBusiness facturaBusiness = new FacturaBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        MarcaBusiness marcaBusiness = new MarcaBusiness();
        public int formtype;
        public string title;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!login())
                Response.Redirect("MainPage.aspx");
            formtype = checkType();
            fillInfo();
        }

        private bool login()
        {
            AdminBusiness adminBusiness = new AdminBusiness();
            if (Session["adminmail"] == null || Session["adminpass"] == null)
                return false;
            if (adminBusiness.checkAdmin((string)Session["adminmail"], (string)Session["adminpass"]) == 0)
                return false;
            return true;
        }
        private int checkType()
        {
            string url = (string)Request.QueryString["type"];
            if(url == "cat")
            {
                return 1;
            } else if(url == "brand")
            {
                return 2;
            }
            Response.Redirect("NewBC.aspx?type=cat");
            return 0;
        }

        private void fillInfo()
        {
            if(formtype == 1)
            {
                title = "categoria";
            } else if(formtype == 2)
            {
                title = "marca";
            }
        }
        protected void Confirm_Click(object sender, EventArgs e)
        {
            if(formtype == 1)
            {
                if(TextBox1.Text != "")
                {
                    categoriaBusiness.create(TextBox1.Text);
                    Response.Redirect("Categorias.aspx");
                }
            } else if(formtype == 2)
            {
                if(TextBox1.Text != "")
                {
                    marcaBusiness.create(TextBox1.Text);
                    Response.Redirect("Marcas.aspx");
                }
            }
        }
    }
}