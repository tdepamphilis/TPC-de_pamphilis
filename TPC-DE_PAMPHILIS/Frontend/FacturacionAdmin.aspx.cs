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
    public partial class FacturacionAdmin : System.Web.UI.Page
    {

        public List<Factura> facturas = new List<Factura>();
        private FacturaBusiness facturaBusiness = new FacturaBusiness();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!login())
                Response.Redirect("MainPage.aspx");
            
            if (!IsPostBack)
            {
                loadOptions();
            }
            loadFacturas();
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
        private void loadOptions()
        {
            ListItem item = new ListItem("Codigo orden", "0", true);
            DropDown.Items.Add(item);
            item = new ListItem("Cliente codigo", "1");
            DropDown.Items.Add(item);
            item = new ListItem("Cliente Nombre", "2");
            DropDown.Items.Add(item);
        }

        private void loadFacturas()
        {
            if (DropDown.SelectedValue == "0")
            {
                facturas = facturaBusiness.listarFacturasCode(TextSearch.Text);
            }
            else if(DropDown.SelectedValue == "1")
            {
                
                facturas = facturaBusiness.listarFacturasUserCode(TextSearch.Text);
            }
            else if (DropDown.SelectedValue == "2")
            {
                facturas = facturaBusiness.listarFacturasUserName(TextSearch.Text);
            }
        }
    }
}