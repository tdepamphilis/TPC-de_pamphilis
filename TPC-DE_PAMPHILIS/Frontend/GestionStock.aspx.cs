using Business;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Frontend
{
    public partial class GestionStock : System.Web.UI.Page
    {
        private ProductoBusiness productoBusiness = new ProductoBusiness();

        public List<Producto> productos = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                LoadOptions();
            }
                loadProducts();
        }

        private void loadProducts()
        {
            if (Textstock.Text == "")
            {
                productos = productoBusiness.listar(TextBoxname.Text);
            }
            else 
            {
                productos = productoBusiness.listar(TextBoxname.Text, DropDown.SelectedValue, Textstock.Text);
            }
        }

        private void LoadOptions()
        {
            ListItem item = new ListItem("Menos que", "<", true);
            DropDown.Items.Add(item);
            item = new ListItem("Mas que", ">");
            DropDown.Items.Add(item);
        }

    }
}