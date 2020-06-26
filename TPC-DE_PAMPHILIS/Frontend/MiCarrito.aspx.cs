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
    public partial class MiCarrito : System.Web.UI.Page
    {

        public Carrito carrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = loadchart();
            isPlus1();
            isPlus10();
            istake1();
            istake10();

        }

        private Carrito loadchart()
        {

            if (Session["chart"] == null)
                Session["chart"] = new Carrito();


            Carrito rtn = (Carrito)Session["chart"];
            return rtn;
        }

        //----------BOTONES DE ITEM------------
        private void isPlus10()
        {
            string code = Request.QueryString["add10"];
            if (code != null)
            {
                foreach(ItemCarrito item in carrito.items)
                {
                    if(item.code == code)
                    {
                        item.ammount += 10;
                    }
                }
            }
        }
        private void isPlus1()
        {
            string code = Request.QueryString["add1"];
            if (code != null)
            {
                foreach (ItemCarrito item in carrito.items)
                {
                    if (item.code == code)
                    {
                        item.ammount++;
                    }
                }
            }
        }
        private void istake10()
        {
            string code = Request.QueryString["-10"];
            if (code != null)
            {
                int deletat = -1;
                int x = 0;
                foreach (ItemCarrito item in carrito.items)
                {
                    if (item.code == code)
                    {
                        item.ammount -= 10;
                       if (item.ammount < 1)
                           deletat = x;

                    }
                    x++;
                }
                if(deletat != -1)
                {
                    carrito.items.RemoveAt(deletat);
                }

            }
        }
        private void istake1()
        {
            string code = Request.QueryString["-1"];
            if (code != null)
            {
                int deletat = -1;
                int x = 0;
                foreach (ItemCarrito item in carrito.items)
                {
                    if (item.code == code)
                    {
                        item.ammount -= 1;
                       if (item.ammount < 1)
                           deletat = x;

                    }
                    x++;
                }
                if (deletat != -1)
                {
                    carrito.items.RemoveAt(deletat);
                }

            }
        }

        protected void ButtonContinuar_Click(object sender, EventArgs e)
        {

            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            
     //       string mail = (string)Session["UserMail"];
       //     string pass = (string)Session["UserPass"];
        //    if (mail == null)
         //       Response.Redirect("MainPage.aspx");
          //  if (usuarioBusiness.CheckAlta(mail, pass) == 0)
            //    Response.Redirect("MainPage.aspx");
            Session["chart"] = carrito;
            Response.Redirect("Checkout.aspx");


        }
    }
}