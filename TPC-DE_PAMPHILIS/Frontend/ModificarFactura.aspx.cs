using Business;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Frontend
{
    public partial class ModificarFactura : System.Web.UI.Page
    {

        public FacturaBusiness facturaBusiness = new FacturaBusiness();
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        public Factura factura;
        public float originalPrice;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarFactura();
            }
            factura = (Factura)Session["facturamod"];
            originalPrice = (float)Session["originalPrice"];
            if(!IsPostBack)
            {
                checkItemButtons();
            }
        }

        private void cargarFactura()
        {
            if (Request.QueryString["fac"] != null)
            {
                Factura aux = new Factura();
                aux = facturaBusiness.buscarId((string)Request.QueryString["fac"]);
                Session["facturamod"] = aux;
                Session["originalPrice"] = aux.monto;
                List<string> codigosIniciales = new List<string>();
                foreach (ItemCarrito item in aux.items)
                    codigosIniciales.Add(item.code);
                Session["itemsIniciales"] = codigosIniciales;
            }
        }

        private void login()
        {
            
        }

        private void checkItemButtons()
        {
            istake1();
            istake10();
            isremove();
            factura.monto = factura.totalPrice();
            Session["facturamod"] = factura;
        }

        private void istake10()
        {
            string code = Request.QueryString["-10"];
            if (code != null)
            {
                int deletat = -1;
                int x = 0;
                foreach (ItemCarrito item in factura.items)
                {
                    if (item.code == code)
                    {
                        item.ammount -= 10;
                        if (item.ammount < 1)
                            deletat = x;

                    }
                    x++;
                }
                if (deletat != -1)
                {
                    factura.items.RemoveAt(deletat);
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
                foreach (ItemCarrito item in factura.items)
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
                    factura.items.RemoveAt(deletat);
                }

            }
        }

        private void isremove()
        {
            string code = Request.QueryString["rmv"];
            if (code != null)
            {
                int deletat = -1;
                int x = 0;
                foreach (ItemCarrito item in factura.items)
                {
                    if (item.code == code)
                    {
                        
                            deletat = x;

                    }
                    x++;
                }
                if (deletat != -1)
                {
                    factura.items.RemoveAt(deletat);
                }

            }
        }


        protected void buttonConfirm_Click(object sender, EventArgs e)
        {
            factura = (Factura)Session["facturamod"];
            facturaBusiness.changePrice(factura);
            facturaBusiness.updateFacturaItems(factura, (List<string>)Session["itemsIniciales"]);
            
            if (factura.pago == true )
            {
                float diferencia = (float)Session["originalPrice"] - factura.monto;
                usuarioBusiness.creditTransaction(diferencia,factura.codigoUsuario);

            }
            Session.Remove("facturamod");
            Session.Remove("itemsIniciales");
            Session.Remove("originalPrice");            
            Response.Redirect("VerFacturaAdmin.aspx?fac=" + factura.codigo);

           
        }
    }
}