using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Business;
namespace Frontend
{
    public partial class FacturasEnviadas : System.Web.UI.Page
    {

        public FacturaBusiness facturaBusiness = new FacturaBusiness();
        public List<Factura> facturas;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                loadOptions();
            }
            loadFacturas();

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
                facturas = facturaBusiness.listarCompletasCode(TextSearch.Text);
            }
            else if (DropDown.SelectedValue == "1")
            {

                facturas = facturaBusiness.listarCompletasUserCode(TextSearch.Text);
            }
            else if (DropDown.SelectedValue == "2")
            {
                facturas = facturaBusiness.listarCompletasUserName(TextSearch.Text);
            }
        }

    }
}