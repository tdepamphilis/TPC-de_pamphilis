﻿using Business;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class Checkout : System.Web.UI.Page
    {
        public Carrito carrito;
        private Usuario usuario;
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        private FacturaBusiness facturaBusiness = new FacturaBusiness();
        public float availableCredits;
        protected void Page_Load(object sender, EventArgs e)
        {

            carrito = loadchart();
            usuario = usuarioBusiness.login((string)Session["usermail"], (string)Session["userpass"]);

            if (!IsPostBack)
            {
                loadPayMethods();
                loadDeliveryOptions();
            }
            if (usuario.credito <= 0 || DropDownMetodo.SelectedValue == "0")
            {
                CheckBoxCredito.Enabled = false;
                CheckBoxCredito.Checked = false;
            }
            else if (usuario.credito > 0 && DropDownMetodo.SelectedValue == "1")
                CheckBoxCredito.Enabled = true;

            if ((float)usuario.credito >= carrito.totalPrice())
                availableCredits = carrito.totalPrice();
            else
                availableCredits = (float)usuario.credito;

        }

        private Carrito loadchart()
        {
            if (Session["chart"] == null)
            {

                Response.Redirect("Tienda.aspx");
            }
            return (Carrito)Session["chart"];
        }

        private void loadPayMethods()
        {
            ListItem item = new ListItem("Efectivo", "0", true);
            DropDownMetodo.Items.Add(item);
            item = new ListItem("Tarjeta", "1");
            DropDownMetodo.Items.Add(item);
        }

        private void loadDeliveryOptions()
        {
            ListItem item = new ListItem("De usuario", "0", true);

            DropDownListDelivery.Items.Add(item);
            item = new ListItem("De facturacion", "1");
            DropDownListDelivery.Items.Add(item);
            item = new ListItem("Otra", "2");
            DropDownListDelivery.Items.Add(item);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Factura factura = carrito.GenerarFactura();






            // set dir
            if ((DropDownListDelivery.SelectedValue == "0") || (DropDownListDelivery.SelectedValue == "1" && DropDownMetodo.SelectedValue == "0"))
                factura.dir = usuario.direccion;
            else if (DropDownListDelivery.SelectedValue == "1")
                factura.dir = TextFacDir.Text;
            else
                factura.dir = TextOtherAdress.Text;
            // set paymode

            if (DropDownMetodo.SelectedValue == "0")
                factura.modoDePago = 'E';
            else
                factura.modoDePago = 'T';
            factura.codigoUsuario = usuario.code;
            factura.fecha = DateTime.Now;
            if (factura.modoDePago == 'E')
                factura.pago = false;
            else
                factura.pago = true;
            factura.estadoEntrega = 0;
            facturaBusiness.GenerarCompra(factura);
            if (CheckBoxCredito.Checked == true)
                usuarioBusiness.creditTransaction(-availableCredits, usuario.code);
            Session["chart"] = new Carrito();
            Response.Redirect("OrdenHecha.aspx");




        }
    }
}