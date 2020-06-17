using Business;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class DetalleOrden : System.Web.UI.Page
    {

        public Carrito carrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            carrito = loadChart();
            
            if(!IsPostBack)
            {
                del();
                take();
                add();
            }
        }

        private Carrito loadChart()
        {
            if (Session["chart"] == null)
                Session["chart"] = new Carrito();


            Carrito rtn = (Carrito)Session["chart"];
            return rtn;
        }

        private void add()
        {
            string code;
            code = Request.QueryString["add"];
            if(code != null)
            {
                foreach(ItemCarrito item in carrito.items)
                {
                    if (item.code == code)
                        item.ammount++;
                }
            }
        }
        
        private void take()
        {
            string code;
            code = Request.QueryString["take"];
            if(code != null)
            {
                int remove = -1;
                int index = 0;
                foreach(ItemCarrito item in carrito.items)
                {
                    if(item.code == code)
                    {
                        item.ammount--;
                        remove = index;
                        
                    }
                    index++;
                }

                if (remove != -1)
                    carrito.items.RemoveAt(remove);
            }

        }

        private void del()
        {
            string code;
            code = Request.QueryString["del"];
            if(code != null)
            {
                int index = 0;
                int selected = 1;

                foreach(ItemCarrito item in carrito.items)
                {
                    if(item.code == code)
                    {
                        selected = index;
                    }
                    index++;
                }
                carrito.items.RemoveAt(selected);
                
            }
        }

        protected void ButtonComprar_Click(object sender, EventArgs e)
        {
            
            FacturaBusiness facturaBusiness = new FacturaBusiness();
            Carrito carro = loadChart();     
            Factura factura = carro.GenerarFactura();
            facturaBusiness.SaveFactura(factura);
        }
    }
}