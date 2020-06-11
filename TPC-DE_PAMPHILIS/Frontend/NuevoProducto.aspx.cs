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
    public partial class NuevoProducto : System.Web.UI.Page
    {
        MarcaBusiness marcaBusiness = new MarcaBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        ProductoBusiness productoBusiness = new ProductoBusiness();
        List<Marca> marcas;
        List<Categoria> categorias;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                marcas = marcaBusiness.listar();
                BrandSelector.DataSource = marcas;
                BrandSelector.DataBind();
                loadCat();
                generateCode();
            }
        }

        private void loadCat()
        {
            categorias = categoriaBusiness.listar();
            foreach(Categoria x in categorias)
            {
                ListItem aux = new ListItem(x.name,x.id.ToString());
                
                Categorybox.Items.Add(aux);
            
            }
            
        }
        
        private void generateCode()
        {
            TextCode.Text = productoBusiness.generateCode();
        //    TextCode.ReadOnly = true;

        }

    }
}